﻿//系统包
using System;
using Microsoft.AspNetCore.Authorization;
//微软包
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//本地项目包
using RayPI.Business;
using RayPI.Domain.Entity;
using RayPI.Infrastructure.Auth.Attributes;
using RayPI.Infrastructure.Auth.Enums;
using RayPI.Infrastructure.Cors.Attributes;
using RayPI.Infrastructure.Cors.Enums;
using RayPI.Infrastructure.RayException;
using RayPI.Infrastructure.Treasury.Models;

namespace RayPI.OpenApi.Controllers
{
    /// <summary>
    /// 学生接口
    /// </summary>
    [Produces("application/json")]
    [Route("api/Student")]
    [RayCors(CorsPolicyEnum.Free)]
    public class StudentController : Controller
    {
        private readonly StudentBusiness _studentBusiness;

        /// <summary>
        /// 
        /// </summary>
        public StudentController(StudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        /// <summary>
        /// 获取学生分页列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">条/页</param>
        /// <returns></returns>
        [HttpGet]
        [RayAuthorize(OperateEnum.Retrieve, ResourceEnum.Student)]
        public JsonResult GetStudentPageList(int pageIndex = 1, int pageSize = 10)
        {
            return Json(_studentBusiness.GetPageList(pageIndex, pageSize));
        }

        /// <summary>
        /// 获取单个学生
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(typeof(StudentEntity), 200)]
        public JsonResult GetStudentById(long id = 0)
        {
            if (id == 0)
                throw new RayAppException("参数id不合法", StatusCodes.Status400BadRequest);
            return Json(_studentBusiness.GetById(id));
        }

        /// <summary>
        /// 根据姓名获取学生
        /// </summary>
        /// <remarks>精确查询</remarks>
        /// <param name="name">学生姓名</param>
        /// <returns></returns>
        [HttpGet("name")]
        [Produces(typeof(StudentEntity))]
        public JsonResult GetByName(string name = null)
        {
            if (name == null)
                throw new ArgumentNullException();
            return Json(_studentBusiness.GetByName(name));
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">学生实体</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Add(StudentEntity entity = null)
        {
            if (entity == null)
                throw new ArgumentNullException();
            return Json(_studentBusiness.Add(entity));
        }
        /// <summary>
        /// 编辑学生
        /// </summary>
        /// <param name="entity">学生实体</param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Update(StudentEntity entity = null)
        {
            if (entity == null)
                throw new ArgumentNullException();
            return Json(_studentBusiness.Update(entity));
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Dels(long[] ids = null)
        {
            if (ids.Length == 0)
                throw new ArgumentNullException();
            return Json(_studentBusiness.Dels(ids));
        }
    }
}