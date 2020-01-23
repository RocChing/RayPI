﻿//系统包
using System;
using System.Collections.Generic;
using System.IO;
//微软包
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
//三方包
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RayPI.Infrastructure.Swagger
{
    public static class StartupExtension
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Version = "v3.0.0",
                Title = "WebAPI",
                Description = "基于.NET Core3.1的接口框架",
                Contact = new OpenApiContact
                {
                    Name = "Roc",
                    Email = "chengpeng19925@163.com",
                    Url = new Uri("https://github.com/rocching")
                }
            };
            #region 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", apiInfo);

                //添加注释服务
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var apiXmlPath = Path.Combine(basePath, "ApiDoc.xml");//控制器层注释
                var entityXmlPath = Path.Combine(basePath, "EntityDoc.xml");//实体注释
                c.IncludeXmlComments(apiXmlPath, true);//true表示显示控制器注释
                //c.IncludeXmlComments(entityXmlPath);

                //添加控制器注释
                //c.DocumentFilter<SwaggerDocTag>();

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                //var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, Array.Empty<string>() }
                });
            });
            #endregion

            return services;
        }

        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "ApiHelp V3");
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
