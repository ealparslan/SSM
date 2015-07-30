namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Order Name")]
        public string OrderName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Sold Date")]
        public DateTime SoldDate { get; set; }

        [Required]
        [DisplayName("Sales Channel")]
        public string SalesChannel { get; set; }

        [Required]
        [DisplayName("Order Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        public double OrderAmount { get; set; }

        public virtual HashSet<OrderList> OrderLists { get; set; }

        //public virtual HashSet<Box> Boxes { get; set; }

    }
}
