namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeliveryList
    {
        public int Id { get; set; }

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [DisplayName("Box Quantity")]
        public int BoxQuantity { get; set; }

        [DisplayName("Part Capacity of Box")]
        public int PartCapOfBox { get; set; }

        [DisplayName("Delivery Id")]
        public int DeliveryId { get; set; }

        [DisplayName("Barcodes Printed")]
        public bool BarcodesPrinted { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual Product Product { get; set; }

        public virtual HashSet<Box> Boxes { get; set; }

    }
}
