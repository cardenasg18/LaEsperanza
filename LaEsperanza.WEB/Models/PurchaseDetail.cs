using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class PurchaseDetail
    {
        [Key]
        public int PurchaseDetailId{ get; set; }

        [Required]
        [Display(Name = "Artículo")]
        [ForeignKey("ItemName")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Cantidad")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Precio unidad")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal TotalValue { get; set; }

        [Required]
        [Display(Name = "Factura")]
        [ForeignKey("PurchaseId")]
        public int PurchaseId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }


    }
}