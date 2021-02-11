using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class OrderSearchLogic
    {
        private OrderDbContext Context;
        public OrderSearchLogic()
        {
            Context = new OrderDbContext();
        }

        public IQueryable<Order> GetProducts(OrderSearchModel searchModel)
        {
            var result = Context.Order.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.OrderNumber))
                    result = result.Where(x => x.Number.Contains(searchModel.OrderNumber));
                if (searchModel.OrderDateFrom.HasValue)
                    result = result.Where(x => x.Date >= searchModel.OrderDateFrom);
                if (searchModel.OrderDateTo.HasValue)
                    result = result.Where(x => x.Date <= searchModel.OrderDateTo);
            }
            return result;
        }
    }
}