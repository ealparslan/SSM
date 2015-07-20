namespace DataLayerPrimitives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductColor
    {
        public ProductColor()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [DisplayName("Product Color")]
        public string Name { get; set; }

        public string Aliases { get; set; }

        [DisplayName("Is Enabled")]
        public bool IsEnabled { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
