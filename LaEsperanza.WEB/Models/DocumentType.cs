using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Tipo documento")]
        public string TypeDocument { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
