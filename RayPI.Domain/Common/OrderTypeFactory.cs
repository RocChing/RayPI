using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.Domain.Common
{
    public class OrderTypeFactory
    {
        private static Dictionary<OrderType, string> orderTypes;

        static OrderTypeFactory()
        {
            orderTypes = new Dictionary<OrderType, string>();
        }

        public static Dictionary<OrderType, string> GetOrderTypeList()
        {
            if (orderTypes == null || orderTypes.Count < 1)
            {
                orderTypes.Add(OrderType.ZZD, "制作单");
                orderTypes.Add(OrderType.TCD, "退菜单");
                //orderTypes.Add(OrderType.CCD, "催菜单");
                //orderTypes.Add(OrderType.QCD, "起菜单");
                //orderTypes.Add(OrderType.ZCD, "转菜单");
                //orderTypes.Add(OrderType.ZTD, "转台单");

                //orderTypes.Add(OrderType.WMHCL, "外卖后厨联");
                //orderTypes.Add(OrderType.WMCCD, "外面催菜单");
                //orderTypes.Add(OrderType.WMTCD, "外卖退菜单");
            }
            return orderTypes;
        }
    }
}
