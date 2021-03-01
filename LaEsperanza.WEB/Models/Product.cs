using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class Product
    {
        [Key]
        public int ProductiD { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Producto")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [StringLength(200, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Retiros")]
        public string Retiro { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Precio unidad")]
        [DataType(DataType.Currency)]
        public decimal PriceP { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
