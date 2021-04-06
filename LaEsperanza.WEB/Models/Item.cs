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

        [Required]
        [Display(Name = "Unidad de medida")]
        [ForeignKey("UnitName")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        [Display(Name = "Fecha vencimiento")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Precio unidad")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Unidades disponibles")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Lote")]
        [MaxLength(20, ErrorMessage = "Límite de caracteres excedido.")]
        public string Lote { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Descripción")]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Suplidor")]
        [ForeignKey("SupplierName")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
