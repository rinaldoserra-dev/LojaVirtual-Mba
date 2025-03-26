using AutoMapper;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Mvc.Controllers
{
    [Route("categorias")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaService.List(cancellationToken));
            
            return View(categorias);
        }
    }
}
