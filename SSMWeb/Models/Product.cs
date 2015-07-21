namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public int FulfilmentSKUId { get; set; }

        public string Aliases { get; set; }

        public string Name { get; set; }

        public long? ParentId { get; set; }

        public bool? IsDiscontinued { get; set; }

        public int CategoryId { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public int PartQtyUnitID { get; set; }

        public int COGSId { get; set; }

        public virtual COG COG { get; set; }

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
