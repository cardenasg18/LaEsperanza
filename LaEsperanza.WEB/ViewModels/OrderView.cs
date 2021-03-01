using LaEsperanza.WEB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.ViewModels
{
    public class OrderView
    {
        public Models.Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> Details { get; set; }
    }

}

