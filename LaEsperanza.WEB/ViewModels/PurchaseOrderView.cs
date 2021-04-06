
using LaEsperanza.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.ViewModels
{
    public class PurchaseOrderView
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public PurchaseDetail PurchaseDetail { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }

}
