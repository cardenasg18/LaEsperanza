using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Codigo invalido")]
        [Display(Name = "Unidad de medida")]
        public string UnitName { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
