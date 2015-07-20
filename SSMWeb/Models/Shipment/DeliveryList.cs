namespace DataLayerPrimitives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeliveryList
    {
        public int Id { get; set; }

        public string ProductId { get; set; }

        public string BoxQuantiy { get; set; }

        public string PartCapOfBox { get; set; }

        public int DeliveryId { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
