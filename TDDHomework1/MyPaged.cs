using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TDDHomework1
{
    public class MyPaged
    {
        public List<int> MyPagedValue(List<Order> OrderList, int count, string field) {
            PropertyInfo prop = typeof(Order).GetProperties().Where(x => x.Name == field).First();

            var vList = (from r in OrderList
                    group r by new { filter = prop.GetValue(r) } into gr
                    select new { Filter = gr.Key.filter }).ToList();

            List < int > ResultList = new List<int>();
            int iTmp = 0;
            int iCount = 0;
            int iterators = vList.Count / count == 0 ? vList.Count % count : vList.Count / count + 1;

            for (int i = 0; i < iterators; i++) {
                for (int j = 0; j < count; j++) {
                    int iIndex = i * count + j;

                    if (iCount < OrderList.Count) {
                        iTmp += Convert.ToInt32(vList[iIndex].Filter);
                    }

                    iCount++;
                }

                ResultList.Add(iTmp);
                iTmp = 0;
            }

            return ResultList;
        }

        private List<Order> GetOrderList() {
            return new List<Order>() {
                new Order { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Order { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Order { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new Order { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new Order { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Order { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new Order { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Order { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new Order { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new Order { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Order { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
            };
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }
}
