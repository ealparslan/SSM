namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderList
    {
        public int Id { get; set; }

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [DisplayName("Order Id")]
        public int OrderId { get; set; }

        [DisplayName("Requested Box Quantity")]
        public int RequestedBoxQuantity { get; set; }

        [DisplayName("Sold Box Quantity")]
        public int SoldBoxQuantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

    }
}
