namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Created On")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Created By")]
        public string CreatedUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Updated On")]
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Updated By")]
        public string UpdatedUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Loaded On")]
        public DateTime? LoadedDate { get; set; }

        [DisplayName("Container Name")]
        public string ContainerName { get; set; }

        [DisplayName("PO Number")]
        public string PONumber { get; set; }

        [DisplayName("Box Quantity")]
        public long? BoxQuantity { get; set; }

        [DisplayName("Destination")]
        public string DestinationCity { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("ETD")]
        public DateTime? ETD { get; set; }

        [DisplayName("Container Type")]
        public string ContainerType { get; set; }

        [DisplayName("Pickup Reference Id")]
        public string PickupReferanceID { get; set; }

        [DisplayName("Vessel Name")]
        public string VesselName { get; set; }

        [DisplayName("Freight Company")]
        public string FreightCompany { get; set; }

        [DisplayName("Is Air Shipment")]
        public bool IsAirShipment { get; set; }

        [DisplayName("Is Customs Cleared")]
        public bool IsCustomsCleared { get; set; }

        [DisplayName("Is Delivered")]
        public bool IsDelivered { get; set; }

        [DisplayName("Is Customs Paid")]
        public bool IsCustomsPaid { get; set; }

        [DisplayName("Is Freight Paid")]
        public bool IsFreightPaid { get; set; }

        [DisplayName("Customs Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        public double? CustomsAmount { get; set; }

        [DisplayName("Freight Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        public double? FreightAmount { get; set; }

        [DisplayName("Handling Fee Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        public double? HandlingFeeAmount { get; set; }

        public virtual HashSet<ShipmentList> ShipmentLists { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
