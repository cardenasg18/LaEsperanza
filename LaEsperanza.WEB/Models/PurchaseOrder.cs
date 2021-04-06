using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [ForeignKey("CustomerName")]
        public int CustomerID { get; set; }


        [Required]
        [Display(Name = "Metodo de pago")]
        [ForeignKey("CustomerName")]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }


        [Display(Name = "Fecha de la orden")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime OrderTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string comentario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Sub-total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal { get; set; }

        [Display(Name = "Impuesto")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Maximo 18 digitos")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valueimp { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal TotalValue { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
