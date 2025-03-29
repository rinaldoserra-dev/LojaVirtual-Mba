using AutoMapper;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaVirtual.Mvc.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public HomeController(ILogger<HomeController> logger,
                              IMapper mapper, 
                              INotifiable notifiable,
                              IProdutoService produtoService) : base(notifiable)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ListVitrine(cancellationToken)));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
