namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public Order()
        {
            OrderLists = new HashSet<OrderList>();
        }

        public int Id { get; set; }

        [Required]
        public string OrderName { get; set; }

        public DateTime SoldDate { get; set; }

        [Required]
        public string SalesChannel { get; set; }

        public int OrderListId { get; set; }

        [Required]
        public string OrderAmount { get; set; }

        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
