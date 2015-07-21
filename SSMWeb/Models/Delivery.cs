namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Delivery
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public int ShipmentId { get; set; }

        public virtual HashSet<DeliveryList> DeliveryLists { get; set; }

    }
}
