using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class SupplierType
    {
        [Key]
        public int SupplierTypeId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Tipo de suplidor")]
        public string Type { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
        
    }
}
