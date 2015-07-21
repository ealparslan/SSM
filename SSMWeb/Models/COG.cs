namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COGS")]
    public partial class COG
    {
        public int Id { get; set; }

        public string UnitPrice { get; set; }

        public string PartQtyUnitID { get; set; }

        public string SetPrice { get; set; }

        public virtual HashSet<Product> Products { get; set; }
    }
}
