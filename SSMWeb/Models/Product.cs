namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        [DisplayName("Fulfilment SKU Id")]
        public int FulfilmentSKUId { get; set; }

        public string Aliases { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        public long? ParentId { get; set; }

        [DisplayName("Is Discontinued")]
        public bool IsDiscontinued { get; set; }

        [DisplayName("Category Id")]
        public int CategoryId { get; set; }

        [DisplayName("Color Id")]
        public int ColorId { get; set; }

        [DisplayName("Size Id")]
        public int SizeId { get; set; }

        [DisplayName("Part Quantity Unit Id")]
        public int PartQtyUnitID { get; set; }

        [DisplayName("Box Capacity")]
        public int BoxCapacity { get; set; }

        public virtual HashSet<COG> COGs { get; set; }

        public virtual QuantityUnit QuantityUnit { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ProductColor ProductColor { get; set; }

        public virtual ProductSize ProductSize { get; set; }

        public virtual FulfilmentSKU FulfilmentSKU { get; set; }

        public virtual HashSet<Box> Boxes { get; set; }

        public virtual HashSet<ShipmentList> ShipmentLists { get; set; }

        public virtual HashSet<DeliveryList> DeliveryLists { get; set; }


    }
}
