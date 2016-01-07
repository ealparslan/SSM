namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COGS")]
    public partial class COG
    {
        public int Id { get; set; }

        [DisplayName("Unit price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        public double UnitPrice { get; set; }

        [DisplayName("Minimum Quantity")]
        public int MinQty { get; set; }

        [DisplayName("Maximum Quantity")]
        public int MaxQty { get; set; }

        [DisplayName("Set Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        public double SetPrice { get; set; }

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
