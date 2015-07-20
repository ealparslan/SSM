namespace DataLayerPrimitives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Box
    {
        public int Id { get; set; }

        public int BarcodeId { get; set; }

        public int ProductId { get; set; }

        [Required]
        public string PartCapOfBox { get; set; }

        [Required]
        public string PartQtyUnitID { get; set; }

        [Required]
        public string PartQtyLeft { get; set; }

        [Required]
        public string BoxUnitOfTotal { get; set; }

        [Required]
        public string BoxTotalOfTotal { get; set; }

        [Required]
        public string PONumber { get; set; }

        [Required]
        public string BoxBrcdID { get; set; }

        public int LocationID { get; set; }

        public int OrderId { get; set; }

        [Required]
        public string DeliveryId { get; set; }

        public virtual Barcode Barcode { get; set; }

        public virtual Location Location { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
