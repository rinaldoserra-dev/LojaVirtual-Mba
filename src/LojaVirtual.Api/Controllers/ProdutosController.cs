using AutoMapper;
using LojaVirtual.Api.Models;
using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Interfaces;
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
        
        [HttpGet("lista")]        
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            return CustomResponse(HttpStatusCode.OK, _mapper.Map<IEnumerable<ProdutoModel>>(await _produtoService.List(cancellationToken)));
        }
        
        [HttpPost("novo")]
        public async Task<IActionResult> Insert([FromForm] ProdutoModel produtoModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var imagePrefix = Guid.NewGuid() + "_";
            if (!await UploadFile(produtoModel.ImagemUpload, imagePrefix))
            {
                return CustomResponse();
            }
            try
            {
                produtoModel.Imagem = imagePrefix + produtoModel.ImagemUpload.FileName;
                await _produtoService.Insert(_mapper.Map<Produto>(produtoModel), cancellationToken);
                if(!OperacaoValida())
                {
                    DeleteFile(produtoModel.Imagem);
                }                
            }
            catch 
            {
                DeleteFile(produtoModel.Imagem);

            }            
            return CustomResponse(HttpStatusCode.Created);
        }        

        private void DeleteFile(string imageName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

            System.IO.File.Delete(path);            
        }
        private async Task<bool> UploadFile(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                AdicionarErroProcessamento("Forneça uma imagem para este produto!");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                AdicionarErroProcessamento("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
