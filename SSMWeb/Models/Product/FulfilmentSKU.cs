namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FulfilmentSKU
    {
        public FulfilmentSKU()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string SKU { get; set; }

        public string Name { get; set; }

        public string SCName { get; set; }

        public string ASIN { get; set; }

        public bool IsDiscontinued { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
