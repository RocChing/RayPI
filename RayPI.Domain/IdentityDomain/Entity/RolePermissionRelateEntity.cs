using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.Entity;

namespace RayPI.Domain.IdentityDomain.Entity
{
    public class RolePermissionRelateEntity : EntityBase
    {
        public string RoleCode { get; set; }
        public string PermissionCode { get; set; }
    }
}
