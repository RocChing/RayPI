using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayPI.Business.Business;
using RayPI.Business.Dto;
using RayPI.Infrastructure.Treasury.Models;

namespace RayPI.OpenApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IdentityAppService _identityAppService;

        public RoleController(IdentityAppService identityAppService)
        {
            _identityAppService = identityAppService;
        }

        [HttpGet]
        public PageResult<RoleDto> GetPageRoles(int pageIndex = 1, int pageSize = 10)
        {
            return _identityAppService.GetPageRoles(pageIndex, pageSize);
        }
    }
}