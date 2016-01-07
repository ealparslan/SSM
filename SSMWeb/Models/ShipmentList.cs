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

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Box Capacity")]
        public int BoxCapacity { get; set; }

        [Required]
        [DisplayName("Box Quantity")]
        public int BoxQuantity { get; set; }

        [DisplayName("Shipment Id")]
        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public virtual Product Product { get; set; }
    }
}
