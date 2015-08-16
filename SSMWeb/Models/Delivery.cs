namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Delivery
    {
        public int Id { get; set; }

        [DisplayName("Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Shipment Id")]
        public int ShipmentId { get; set; }

        [DisplayName("Barcodes Printed")]
        public bool BarcodesPrinted { get; set; }

        public virtual HashSet<DeliveryList> DeliveryLists { get; set; }

        public virtual Shipment Shipment { get; set; }

    }
}
