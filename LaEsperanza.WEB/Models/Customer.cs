using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaEsperanza.WEB.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [MaxLength(30, ErrorMessage ="Nombre introducido excede límite de caracteres")]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Favor escribir su nombre.")]
        public string CustomerName { get; set; }

        [MaxLength(40, ErrorMessage = "Apellido introducido excede límite de caracteres")]
        [Display(Name ="Apellido")]
        [Required(ErrorMessage ="Favor escribir su apellido.")]
        public string LastName { get; set; }


        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido.")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(10, ErrorMessage = "Número incorrecto.")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string Phone { get; set; }


        [Display(Name = "Tipo Documento")]
        [ForeignKey("TypeDocument")]
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }


        [MaxLength(20, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Display(Name ="Nombre completo")]
        public string FullName => $"{CustomerName} {LastName}";


    }
}
