using System.ComponentModel.DataAnnotations;

namespace EfCoreExample.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
		public int? CategoryId { get; set; }
	}
}