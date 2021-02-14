using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        [ForeignKey("ItemType")]
        public int ClasificationId { get; set; }
        public Clasification Clasification { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100, ErrorMessage = "Límite de caracteres excedido")]
        [Display(Name = "Medicamento")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Descripción")]
        public string Comment { get; set; }

    }
}
