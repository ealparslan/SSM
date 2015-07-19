namespace DataLayerPrimitives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Delivery
    {
        public Delivery()
        {
            DeliveryLists = new HashSet<DeliveryList>();
        }

        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int ShipmentId { get; set; }

        public virtual ICollection<DeliveryList> DeliveryLists { get; set; }
    }
}
