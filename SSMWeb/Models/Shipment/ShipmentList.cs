namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShipmentList
    {
        public int Id { get; set; }

        [DisplayName("Product SKU")]
        public int ProductId { get; set; }

        [DisplayName("Box Capacity")]
        public string BoxCapacity { get; set; }

        [DisplayName("Box Quantity")]
        public string BoxQuantity { get; set; }

        [DisplayName("Shipment")]
        public int ShipmentId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}
