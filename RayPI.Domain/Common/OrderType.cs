using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Domain.Common
{
    public enum OrderType
    {
        /// <summary>
        /// 未知
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 制作单
        /// </summary>
        ZZD = 1,
        /// <summary>
        /// 退菜单
        /// </summary>
        TCD = 2,
        /// <summary>
        /// 催菜单
        /// </summary>
        CCD = 3,
        /// <summary>
        /// 起菜单
        /// </summary>
        QCD = 4,
        /// <summary>
        /// 转菜单
        /// </summary>
        ZCD = 5,
        /// <summary>
        /// 转台单
        /// </summary>
        ZTD = 6,
        /// <summary>
        /// 外卖后厨联
        /// </summary>
        WMHCL = 100,
        /// <summary>
        /// 外面催菜单
        /// </summary>
        WMCCD = 101,
        /// <summary>
        /// 外卖退菜单
        /// </summary>
        WMTCD = 102
    }
}
