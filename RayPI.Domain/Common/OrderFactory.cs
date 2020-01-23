using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayPI.Domain.Entity;

namespace RayPI.Domain.Common
{
    public class OrderFactory
    {
        private static Encoding encoding = Encoding.GetEncoding("gbk");
        private static Dictionary<OrderType, string> orderTypes = OrderTypeFactory.GetOrderTypeList();

        public static OrderEntity Parse(byte[] bytes)
        {
            List<string> list = GetLines(bytes);
            if (list == null || list.Count < 1) return null;

            string allLine = string.Join("", list);
            Console.WriteLine(allLine);

            string[] lines = allLine.Split('\n');

            OrderEntity order = new OrderEntity(true);
            bool findTitle = false;
            bool findOrderDetail = false;
            bool findOrder = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string item = TryGetListValue(i, lines);
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                if (!findTitle)
                {
                    OrderType orderType = GetOrderType(item);
                    if (orderType != OrderType.NONE)
                    {
                        order.OrderType = (int)orderType;
                        order.OrderTypeName = item;
                        order.DesktopName = GetLineString(TryGetListValue(++i, lines), "桌号:");
                        string customerCount = GetLineString(TryGetListValue(++i, lines), "人数:");
                        if (!string.IsNullOrEmpty(customerCount))
                        {
                            int count = 0;
                            int.TryParse(customerCount, out count);
                            order.CustomerCount = count;
                        }
                        i += 3;
                        findTitle = true;
                        findOrderDetail = true;
                        //跳过 ------
                        //跳过 菜品    数量
                        //跳过 ------
                        continue;
                    }
                }

                if (findOrderDetail)
                {
                    if (item.StartsWith("----"))
                    {
                        findOrder = true;
                        findOrderDetail = false;
                        continue;
                    }

                    OrderDetailEntity orderDetail = GetOrderDetail(item);
                    if (orderDetail != null)
                    {
                        order.OrderDetails.Add(orderDetail);
                    }
                    else
                    {
                        var od = order.OrderDetails.LastOrDefault();
                        if (od != null)
                        {
                            od.GoodsName += item;
                        }
                    }
                }

                if (findOrder)
                {
                    order.OrderNo = GetLineString(TryGetListValue(i, lines), "单号:");
                    order.Operator = GetLineString(TryGetListValue(++i, lines), "操作人:");
                    order.OrderTime = GetLineString(TryGetListValue(++i, lines), "时间:");
                    break;
                }
            }
            return order;
        }

        private static OrderType GetOrderType(string name)
        {
            foreach (var item in orderTypes)
            {
                if (name.Equals(item.Value, StringComparison.OrdinalIgnoreCase))
                {
                    return item.Key;
                }
            }
            return OrderType.NONE;
        }

        private static OrderDetailEntity GetOrderDetail(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }
            string[] lines = line.Split(' ');
            List<string> list = null;
            if (lines != null && lines.Length > 0)
            {
                list = lines.Where(m => !string.IsNullOrEmpty(m)).ToList();
            }
            if (list != null && list.Count > 1)
            {
                string[] array = new string[list.Count - 1];
                list.CopyTo(0, array, 0, list.Count - 1);

                OrderDetailEntity orderDetail = new OrderDetailEntity();
                orderDetail.GoodsName = string.Join(' ', array);

                string[] strs = list[list.Count - 1].Split('/');
                if (strs != null && strs.Length > 1)
                {
                    orderDetail.Unit = strs[1];
                    int number = 0;
                    int.TryParse(strs[0], out number);
                    orderDetail.Number = number;
                    return orderDetail;
                }
            }
            return null;
        }

        private static string GetLineString(string name, string pattern)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            int index = name.IndexOf(pattern);
            if (index > -1)
            {
                return name.Substring(index + pattern.Length).Trim();
            }
            return string.Empty;
        }

        private static string TryGetListValue(int index, List<string> list)
        {
            try
            {
                return list[index];
            }
            catch (Exception e)
            {
                Console.WriteLine($"错误Index:{index}" + e.ToString());
                return string.Empty;
            }
        }

        private static string TryGetListValue(int index, string[] list)
        {
            try
            {
                return list[index].Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine($"错误Index:{index}" + e.ToString());
                return "";
            }
        }

        private static List<string> GetLineString2(List<byte> list)
        {
            string str = encoding.GetString(list.ToArray());
            if (string.IsNullOrEmpty(str)) return null;
            string[] strs = str.Split('\n');
            if (strs != null && strs.Length > 0)
            {
                return strs.Where(m => !string.IsNullOrEmpty(m)).ToList();
            }
            return null;
        }

        private static string GetLineString(List<byte> list)
        {
            return encoding.GetString(list.ToArray());
        }

        private static List<string> GetLines(byte[] bytes)
        {
            int[] array1 = new int[] { 27, 29 };
            int[] array2 = new int[] { 33, 76, 74, 100, 86, 32, 97, 105, 69, 66 };
            int sp_value = 64;

            List<string> result = new List<string>();
            List<byte> list = new List<byte>();
            for (int i = 0; i < bytes.Length; i++)
            {
                byte value = bytes[i];
                if (array1.Contains(value))
                {
                    if (list.Count > 0)
                    {
                        //List<string> lines = GetLineString(list);
                        //if (lines != null && lines.Count > 0)
                        //{
                        //    result.AddRange(lines);
                        //}
                        result.Add(GetLineString(list));
                        list.Clear();
                    }
                    int value_next = bytes[i + 1];
                    if (value_next == sp_value)
                    {
                        i += 1;
                        continue;
                    }
                    if (array2.Contains(value_next))
                    {
                        i += 2;
                        continue;
                    }
                }
                else
                {
                    list.Add(value);
                }
            }
            return result;
        }
    }
}
