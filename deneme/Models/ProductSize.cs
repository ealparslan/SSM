namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductSize
    {
        public ProductSize()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Dimentions { get; set; }

        public string Property1 { get; set; }

        public bool? IsEnabled { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
