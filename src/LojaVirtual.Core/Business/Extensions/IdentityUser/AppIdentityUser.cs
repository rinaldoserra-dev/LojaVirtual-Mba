using LojaVirtual.Core.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LojaVirtual.Core.Business.Extensions.IdentityUser
{
    public class AppIdentityUser : IAppIdentifyUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IVendedorRepository _vendedorRepository;
        public AppIdentityUser(IHttpContextAccessor accessor, IVendedorRepository vendedorRepository)
        {
            _accessor = accessor;
            _vendedorRepository = vendedorRepository;
        }

        public string GetUserId()
        {
            if (!IsAuthenticated()) return string.Empty;

            var claim = _accessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return claim ?? string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User.Identity is { IsAuthenticated: true };
        }

        public string GetNameVendedor()
        {
            if (!IsAuthenticated()) return string.Empty;

            var userId = GetUserId();
            var vendedor = _vendedorRepository.GetById(new Guid(userId), CancellationToken.None).Result;

            return vendedor.Nome;
        }
    }
}
