using AutoMapper;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

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
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var produtos = await _produtoService.ListVitrine(cancellationToken);
            var categorias = await _categoriaService.List(cancellationToken);

            var vitrine = new ProdutoVitrineViewModel()
            {
                Produtos = produtos,
                Categorias = categorias,
                CategoriaId = null
            };
            return View(vitrine);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Index(Guid? categoriaId, CancellationToken cancellationToken)
        {
            var produtos = categoriaId == null ? await _produtoService.ListVitrine(cancellationToken) : await _produtoService.GetWithCategoriaVendedorByCategoria(categoriaId, cancellationToken);
            var categorias = await _categoriaService.List(cancellationToken);
            var vitrine = new ProdutoVitrineViewModel()
            {
                Produtos = produtos,
                Categorias = categorias,
                CategoriaId = categoriaId
            };
            return View(vitrine);
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id, CancellationToken cancellationToken)
        {
            var produto = await _produtoService.GetById(id, cancellationToken);

            return View(_mapper.Map<ProdutoViewModel>(produto));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
