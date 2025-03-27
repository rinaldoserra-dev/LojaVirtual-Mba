using AutoMapper;
using LojaVirtual.Api.Models;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Core.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LojaVirtual.Api.Controllers
{
    [Authorize]
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoService produtoService,
                                    INotifiable notifiable,
                                    IMapper mapper) : base(notifiable)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("vitrine")]
        [AllowAnonymous]
        public async Task<ActionResult> List(CancellationToken cancellationToken)
        {
            return CustomResponse(HttpStatusCode.OK, _mapper.Map<IEnumerable<ProdutoModel>>(await _produtoService.List(cancellationToken)));
        }
    }
}
