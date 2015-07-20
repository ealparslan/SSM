namespace SSMWeb.Models
{
    using SSMWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentLists = new HashSet<ShipmentList>();
        }

        public int Id { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Created User")]
        public string CreatedUserId { get; set; }

        [DisplayName("Updated Date")]
        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Updated User")]
        public string UpdatedUserId { get; set; }

        [DisplayName("Loaded Date")]
        [DataType(DataType.Date)]
        public DateTime? LoadedDate { get; set; }

        [DisplayName("Container Name")]
        public string ContainerName { get; set; }

        [DisplayName("PO Num")]
        public string PONumber { get; set; }

        [DisplayName("Box Qty")]
        public long? BoxQuantity { get; set; }

        [DisplayName("Destination")]
        public string DestinationCity { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ETD { get; set; }

        [DisplayName("Container Type")]
        public string ContainerType { get; set; }

        [DisplayName("Pickup Reference")]
        public string PickupReferanceID { get; set; }

        [DisplayName("Vessel Name")]
        public string VesselName { get; set; }

        [DisplayName("Freight Company")]
        public string FreightCompany { get; set; }

        [DisplayName("Air Ship")]
        public bool IsAirShipment { get; set; }

        [DisplayName("Customs Cleared")]
        public bool IsCustomsCleared { get; set; }

        [DisplayName("Delivered")]
        public bool IsDelivered { get; set; }

        [DisplayName("Customs Paid")]
        public bool IsCustomsPaid { get; set; }

        [DisplayName("Fright Paid")]
        public bool IsFreightPaid { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [DisplayName("Customs Amount")]
        public double? CustomsAmount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [DisplayName("Freight Amount")]
        public double? FreightAmount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [DisplayName("Handling Fee")]
        public double? HandlingFeeAmount { get; set; }

        public virtual ICollection<ShipmentList> ShipmentLists { get; set; }

    }
}
