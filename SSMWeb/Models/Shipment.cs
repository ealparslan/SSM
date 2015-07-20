//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipment
    {
        public Shipment()
        {
            this.ShipmentLists = new HashSet<ShipmentList>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUserId { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public Nullable<System.DateTime> LoadedDate { get; set; }
        public string ContainerName { get; set; }
        public string PONumber { get; set; }
        public Nullable<long> BoxQuantity { get; set; }
        public string DestinationCity { get; set; }
        public Nullable<System.DateTime> ETD { get; set; }
        public string ContainerType { get; set; }
        public string PickupReferanceID { get; set; }
        public string VesselName { get; set; }
        public string FreightCompany { get; set; }
        public Nullable<bool> IsAirShipment { get; set; }
        public Nullable<bool> IsCustomsCleared { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
        public Nullable<bool> IsCustomsPaid { get; set; }
        public Nullable<bool> IsFreightPaid { get; set; }
        public Nullable<double> CustomsAmount { get; set; }
        public Nullable<double> FreightAmount { get; set; }
        public Nullable<double> HandlingFeeAmount { get; set; }
    
        public virtual ICollection<ShipmentList> ShipmentLists { get; set; }
    }
}
