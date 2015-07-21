namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Box
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string PartCapOfBox { get; set; }

        public string PartQtyUnitID { get; set; }

        public string PartQtyLeft { get; set; }

        public string BoxUnitOfTotal { get; set; }

        public string BoxTotalOfTotal { get; set; }

        public string PONumber { get; set; }

        public int LocationID { get; set; }

        [Required]
        public int DeliveryListId { get; set; }

        public string BarcodeType { get; set; }

        [Required]
        public string BarcodeId { get; set; }

        [Column(TypeName = "image")]
        public byte[] BarcodeImage { get; set; }

        public virtual Product Product { get; set; }

        public virtual Location Location { get; set; }

        public virtual DeliveryList DeliveryList { get; set; }

    }
}
