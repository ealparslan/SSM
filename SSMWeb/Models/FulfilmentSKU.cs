namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FulfilmentSKU
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        [DisplayName("FulfilmentSKU")]
        public string Name { get; set; }

        public string SCName { get; set; }

        public string ASIN { get; set; }

        [DisplayName("Is Discontinued")]
        public bool IsDiscontinued { get; set; }

        public virtual HashSet<Product> Products { get; set; }
    }
}
