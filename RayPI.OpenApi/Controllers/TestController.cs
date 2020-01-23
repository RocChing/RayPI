//微软包
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//本地项目包
using RayPI.Infrastructure.Auth.Models;
using RayPI.Infrastructure.Auth.Enums;
using RayPI.Infrastructure.Auth.Jwt;
using RayPI.Infrastructure.Auth.Attributes;
using RayPI.Infrastructure.Config;
using RayPI.Infrastructure.RayException;
using RayPI.Infrastructure.Cors.Attributes;
using RayPI.Infrastructure.Cors.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using RayPI.Infrastructure.Security.Models;
using RayPI.Infrastructure.Security.Services;
using System.Text;
using RayPI.Domain.Common;
using RayPI.Domain.Entity;
using RayPI.Business;

namespace RayPI.OpenApi.Controllers
{
    /// <summary>
    /// 系统接口
    /// </summary>
    [Produces("application/json")]
    [Route("api/Test")]
    //[RayCors(CorsPolicyEnum.Free)]
    //[RayAuthorize(AuthPolicyEnum.RequireRoleOfAdminOrClient)]
    public class TestController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AllConfigModel _allConfigModel;
        private readonly OrderBusiness orderBusiness;
        //private readonly IJwtService _jwtService;

        /// <summary>
        /// 
        /// </summary>
        public TestController(//IJwtService jwtService,
            IConfiguration configuration,
            AllConfigModel allConfigModel,
            OrderBusiness orderBusiness
            )
        {
            _config = configuration;
            _allConfigModel = allConfigModel;
            this.orderBusiness = orderBusiness;
            //_jwtService = jwtService;
        }

        [HttpPost]
        [Route("AddOrder")]
        public OrderEntity AddOrder([FromBody] OrderDto model)
        {
            //string str = "27,64,27,97,1,29,33,17,27,69,0,214,198,215,247,181,165,10,27,97,0,215,192,186,197,58,32,208,161,49,54,186,197,215,192,10,200,203,202,253,58,32,49,10,29,33,0,27,69,0,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,10,178,203,198,183,32,32,32,32,32,32,32,32,32,32,32,32,32,32,32,32,27,97,2,32,32,32,32,32,32,32,32,202,253,193,191,10,27,97,0,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,10,29,33,17,27,69,0,190,194,178,203,188,166,181,176,180,243,27,97,2,32,32,49,47,183,221,10,27,97,0,183,221,32,32,32,32,32,32,32,32,27,97,2,29,33,0,27,69,0,32,32,32,32,32,32,32,32,32,32,32,32,10,27,97,0,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,10,181,165,186,197,58,32,48,54,57,53,55,48,49,50,48,48,49,49,57,48,48,48,52,10,178,217,215,247,200,203,58,32,185,220,192,237,212,177,32,40,49,53,54,50,48,55,56,50,48,49,53,41,10,202,177,188,228,58,32,50,48,50,48,45,48,49,45,49,57,32,49,55,58,48,53,58,48,48,10,10,10,10,10,29,86,1,27,66,1,3,27,97,0,27,33,0,10,27,97,0,49,51";
            //string str = "10,27,97,0,29,33,17,42,178,185,180,242,42,29,33,0,199,235,211,235,201,207,210,187,213,197,181,165,190,221,186,203,182,212,202,199,183,241,214,216,184,180,10,10,27,64,27,97,1,29,33,17,27,69,0,214,198,215,247,181,165,10,27,97,0,215,192,186,197,58,32,208,161,57,186,197,215,192,10,200,203,202,253,58,32,49,10,29,33,0,27,69,0,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,10,178,203,198,183,32,32,32,32,32,32,32,32,32,32,32,32,32,32,32,32,27,97,2,32,32,32,32,32,32,32,32,202,253,193,191,10,27,97,0,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,10,29,33,17,27,69,0,200,226,200,253,207,202,208,161,183,221,27,97,2,32,32,49,47,183,221,10,27,97,0,189,180,188,166,215,166,40,184,246,41,27,97,2,32,32,49,47,183,221,10,27,97,0,188,166,178,177,32,32,32,32,32,32,27,97,2,32,32,49,47,183,221,10,27,97,0,206,247,186,236,202,193,188,166,181,176,27,97,2,32,32,49,47,183,221,10,27,97,0,204,192,32,32,32,32,32,32,32,32,27,97,2,29,33,0,27,69,0,32,32,32,32,32,32,32,32,32,32,32,32,10,27,97,0,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,45,10,181,165,186,197,58,32,48,54,57,53,55,48,49,50,48,48,49,49,57,48,48,48,55,10,178,217,215,247,200,203,58,32,185,220,192,237,212,177,32,40,49,53,54,50,48,55,56,50,48,49,53,41,10,202,177,188,228,58,32,50,48,50,48,45,48,49,45,49,57,32,50,48,58,52,54,58,50,55,10,10,10,10,10,29,86,1,27,66,1,3,27,97,0,27,33,0,10,27,97,0,50,48";
            if (string.IsNullOrEmpty(model.Content))
            {
                return null;
            }
            string[] strs = model.Content.Split(',');
            byte[] bytes = new byte[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                bytes[i] = byte.Parse(strs[i]);
            }

            OrderEntity order = OrderFactory.Parse(bytes);
            if (order.IsValid())
            {
                orderBusiness.Add(order);
            }
            return order;
        }

        [HttpGet]
        [Route(nameof(GetOrders))]
        public List<OrderEntity> GetOrders(OrderStatus status)
        {
            return orderBusiness.GetOrderList(status);
        }

        /// <summary>
        /// 模拟登录，获取JWT
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="uname"></param>
        /// <param name="role"></param>
        /// <param name="project"></param>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        //[RayAuthorizeFree]
        public string GetJWTStr(long uid = 1, string uname = "Admin", string role = "Admin", string project = "RayPI", TokenTypeEnum tokenType = TokenTypeEnum.Web)
        {
            var tm = new TokenModel
            {
                Uid = uid,
                Uname = uname,
                Role = role,
                Project = project,
                TokenType = tokenType
            };
            //return _jwtService.IssueJwt(tm);
            return null;
        }

        /// <summary>
        /// 测试异常
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestException")]
        public JsonResult TestException()
        {
            string s = null;
            return Json(s.Length);
        }

        /// <summary>
        /// 测试异常2
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestException2")]
        public JsonResult TestException2()
        {
            throw new System.Exception("测试");
        }

        /// <summary>
        /// 测试异常3
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestException3")]
        public JsonResult TestException3()
        {
            throw new RayAppException();
        }

        /// <summary>
        /// 测试配置1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestConfig1")]
        public string TestConfig1()
        {
            return _allConfigModel.TestConfigModel.Key1;
        }

        /// <summary>
        /// 测试配置2
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestConfig2")]
        public string TestConfig2()
        {
            return _config["Test:Key1"];
        }
    }

    public class OrderDto
    {
        public string Content { get; set; }
    }
}