namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
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

        public DateTime? CreatedDate { get; set; }

        public string CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedUserId { get; set; }

        public DateTime? LoadedDate { get; set; }

        public string ContainerName { get; set; }

        public string PONumber { get; set; }

        public long? BoxQuantity { get; set; }

        public string DestinationCity { get; set; }

        public DateTime? ETD { get; set; }

        public string ContainerType { get; set; }

        public string PickupReferanceID { get; set; }

        public string VesselName { get; set; }

        public string FreightCompany { get; set; }

        public bool? IsAirShipment { get; set; }

        public bool? IsCustomsCleared { get; set; }

        public bool? IsDelivered { get; set; }

        public bool? IsCustomsPaid { get; set; }

        public bool? IsFreightPaid { get; set; }

        public double? CustomsAmount { get; set; }

        public double? FreightAmount { get; set; }

        public double? HandlingFeeAmount { get; set; }

        public virtual ICollection<ShipmentList> ShipmentLists { get; set; }
    }
}
