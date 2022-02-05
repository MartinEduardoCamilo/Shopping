using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class Products
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
		public int cantidad { get; set; }


		public Products()
		{
			id = 0;
			title = String.Empty;
			price = 0;
			description = String.Empty;
			category = String.Empty;
			image = String.Empty;
			cantidad = 0;
		}

		public Products(int id, string title, decimal price, string description, string category, string image, int cantidad)
		{
			this.id = id;
			this.title = title ?? throw new ArgumentNullException(nameof(title));
			this.price = price;
			this.description = description ?? throw new ArgumentNullException(nameof(description));
			this.category = category ?? throw new ArgumentNullException(nameof(category));
			this.image = image ?? throw new ArgumentNullException(nameof(image));
			this.cantidad = cantidad;
		}
	}
   
}
