using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Domain.Common
{
    public enum OrderStatus
    {
        /// <summary>
        /// 待备餐
        /// </summary>
        DBC = 1,
        /// <summary>
        /// 备餐中
        /// </summary>
        BCZ = 2,
        /// <summary>
        /// 已备餐
        /// </summary>
        YBC = 3
    }
}
