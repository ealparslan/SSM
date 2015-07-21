namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Box
    {
        public Box()
        {
            Barcodes = new HashSet<Barcode>();
            OrderLists = new HashSet<OrderList>();
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        [StringLength(10)]
        public string BarcodeId { get; set; }

        public int PartCapOfBox { get; set; }

        public int PartQtyUnitID { get; set; }

        public int PartQtyLeft { get; set; }

        public int BoxUnitOfTotal { get; set; }

        public int BoxTotalOfTotal { get; set; }

        [Required]
        public string PONumber { get; set; }

        public int LocationID { get; set; }

        public int DeliveryId { get; set; }

        public virtual ICollection<Barcode> Barcodes { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<OrderList> OrderLists { get; set; }

        public virtual Product Product { get; set; }
    }
}
