namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderList
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Order Id")]
        public int OrderId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Sold Date")]
        public DateTime SoldDate { get; set; }

        [Required]
        [DisplayName("Sales Channel")]
        public string SalesChannel { get; set; }

        [DisplayName("Box Id")]
        public int BoxId { get; set; }

        [Required]
        [DisplayName("Sold Quantity")]
        public string SoldQty { get; set; }

        //public virtual Box Box { get; set; }

        public virtual Order Order { get; set; }

    }
}
