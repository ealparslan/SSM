namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductColor
    {
        public int Id { get; set; }

        [DisplayName("Color")]
        public string Name { get; set; }

        [DisplayName("Colur Aliases")]
        public string Aliases { get; set; }

        [DisplayName("Is Enabled")]
        public bool IsEnabled { get; set; }

        public virtual HashSet<Product> Products { get; set; }
    }
}
