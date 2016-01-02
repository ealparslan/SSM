namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Box
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [DisplayName("Part Capacity of Box")]
        public int PartCapOfBox { get; set; }

        [DisplayName("Part Quantity Unit Id")]
        public int PartQtyUnitID { get; set; }

        [DisplayName("Part Quantity Left")]
        public int PartQtyLeft { get; set; }

        [DisplayName("Box Unit of Total")]
        public int BoxUnitOfTotal { get; set; }

        [DisplayName("Box Total of Total")]
        public int BoxTotalOfTotal { get; set; }

        public string PONumber { get; set; }

        [DisplayName("Location Id")]
        public int LocationID { get; set; }

        [Required]
        [DisplayName("Delivery List Id")]
        public int DeliveryListId { get; set; }

        [DisplayName("Barcode Type")]
        public string BarcodeType { get; set; }

        [Required]
        [DisplayName("Barcode Id")]
        public string BarcodeId { get; set; }

        [Column(TypeName = "image")]
        [DisplayName("Barcode Img")]
        public byte[] BarcodeImage { get; set; }

        public virtual Product Product { get; set; }

        public virtual Location Location { get; set; }

        public virtual DeliveryList DeliveryList { get; set; }

    }
}
