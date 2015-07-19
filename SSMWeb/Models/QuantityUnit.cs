namespace DataLayerPrimitives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuantityUnit
    {
        public QuantityUnit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Quantity Unit")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
