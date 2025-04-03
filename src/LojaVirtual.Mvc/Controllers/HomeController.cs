using AutoMapper;
using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace LojaVirtual.Mvc.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public HomeController(ILogger<HomeController> logger,
                              IMapper mapper, 
                              INotifiable notifiable,
                              IProdutoService produtoService,
                              ICategoriaService categoriaService) : base(notifiable)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            return View();
        }        

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Index(Guid? categoriaId, CancellationToken cancellationToken)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoVitrineViewModel>>(await _produtoService.ListVitrine(categoriaId, cancellationToken));
            var _categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaService.List(cancellationToken));
            ViewBag.Categorias = _categorias; // Passar categorias para a view
            
            return View(produtos);
        }
        public async Task<IActionResult> ListaProdutos(Guid? categoriaId, CancellationToken cancellationToken)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoVitrineViewModel>>(await _produtoService.ListVitrine(categoriaId, cancellationToken));

            return PartialView("_ListaProdutos", produtos);
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id, CancellationToken cancellationToken)
        {
            id = Guid.NewGuid();
            var produto = await _produtoService.GetById(id, cancellationToken);

            if (produto == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProdutoViewModel>(produto));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
