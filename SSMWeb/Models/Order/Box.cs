namespace SSMWeb.Models
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
        public int PartCapOfBox { get; set; }

        [Required]
        public int PartQtyUnitID { get; set; }

        [Required]
        public int PartQtyLeft { get; set; }

        [Required]
        public int BoxUnitOfTotal { get; set; }

        [Required]
        public int BoxTotalOfTotal { get; set; }

        [Required]
        public string PONumber { get; set; }

        public int LocationID { get; set; }

        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public virtual Barcode Barcode { get; set; }

        public virtual Location Location { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual OrderList OrderList { get; set; }

    }
}
