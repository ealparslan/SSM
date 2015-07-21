namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShipmentList
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string BoxCapacity { get; set; }

        public string BoxQuantity { get; set; }

        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public virtual Product Product { get; set; }
    }
}
