using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class ItemWithImage
    {
        [Key]
        public int UserProductID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nombre imagen")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Subir archivo")]
        public IFormFile ImageFile { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Producto")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(1000, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Precio unidad")]
        [DataType(DataType.Currency)]
        public decimal PriceP { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Presentación")]
        public string Presentation { get; set; }
    }
}
