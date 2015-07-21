namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        [Required]
        public string OrderName { get; set; }

        public DateTime SoldDate { get; set; }

        [Required]
        public string SalesChannel { get; set; }

        [Required]
        public string OrderAmount { get; set; }

        public virtual HashSet<OrderList> OrderLists { get; set; }

        //public virtual HashSet<Box> Boxes { get; set; }

    }
}
