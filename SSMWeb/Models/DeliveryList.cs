namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeliveryList
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BoxQuantity { get; set; }

        public string PartCapOfBox { get; set; }

        public int DeliveryId { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual Product Product { get; set; }

        public virtual HashSet<Box> Boxes { get; set; }

    }
}
