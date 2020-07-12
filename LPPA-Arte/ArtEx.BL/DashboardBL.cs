using ArtEx.BL.Models;
using ArtEx.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace ArtEx.BL
{

    public partial class BusinessContext
    {
        public List<SalesMonthModel> DashboardSales()
        {
            var sqlMinDate = (DateTime)SqlDateTime.MinValue;
            List<SalesMonthModel> sales = db.Orders
                .GroupBy(x => SqlFunctions.DateAdd("month", SqlFunctions.DateDiff("month", sqlMinDate, x.orderDate), sqlMinDate))
                .Select(x =>
                    new SalesMonthModel()
                    {
                        period = x.Key.ToString().Substring(0, 7),
                        quantity = x.Sum(i => i.itemCount),
                        total = x.Sum(i => i.totalPrice)
                    }
                ).ToList();
            return sales;
        }

        public List<StarCountModel> DashboardStars()
        {
            var sqlMinDate = (DateTime)SqlDateTime.MinValue;
            List<StarCountModel> list = db.Products
                .GroupBy(x => (int)x.avgStars)
                .Select(x =>
                    new StarCountModel()
                    {
                        star = (int)x.Key,
                        quantity = x.Count()
                    }
                ).ToList();
            return list;
        }

    }
}
