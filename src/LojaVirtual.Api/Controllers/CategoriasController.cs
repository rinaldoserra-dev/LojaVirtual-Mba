using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Core.Business.Models.Categoria;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LojaVirtual.Api.Controllers
{
    [Route("api/categorias")]
    public class CategoriasController : MainController
    {
        private readonly ICategoriaService _categoriaService;
        private readonly INotifiable _notifiable;
        public CategoriasController(ICategoriaService categoriaService,
                                    INotifiable notifiable)
        {
            _categoriaService = categoriaService;
            _notifiable = notifiable;
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CategoriaRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            
            await _categoriaService.Insert(request, cancellationToken);
            
            if (_notifiable.Valid())
            {
                return CustomResponse(HttpStatusCode.Created);
            }
            return CustomResponse(_notifiable.GetNotifications());
        }

        [HttpGet]
        public async Task<ActionResult> List(CancellationToken cancellationToken)
        {
            return CustomResponse(HttpStatusCode.OK, await _categoriaService.List(cancellationToken));
        }
        
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id, CategoriaRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _categoriaService.Edit(request, cancellationToken);

            if (_notifiable.Valid())
            {
                return CustomResponse(HttpStatusCode.NoContent);
            }
            return CustomResponse(_notifiable.GetNotifications());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaService.GetById(id, cancellationToken);
            if (_notifiable.Invalid())
            {
                return CustomResponse(_notifiable.GetNotifications());
            }
            return CustomResponse(HttpStatusCode.OK, categoria);
        }
        
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Remove(Guid id, CancellationToken cancellationToken)
        {
            await _categoriaService.Remove(id, cancellationToken);
            if (_notifiable.Invalid())
            {
                return CustomResponse(_notifiable.GetNotifications());
            }
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}
