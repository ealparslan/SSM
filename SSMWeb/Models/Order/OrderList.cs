namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderList
    {
        public OrderList()
        {
            Box = new Box();
            Order = new Order();
        }

        public int Id { get; set; }

        [Required]
        public string OrderName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SoldDate { get; set; }

        [Required]
        public string SalesChannel { get; set; }

        [Required]
        public string BoxId { get; set; }

        [Required]
        public string SoldQty { get; set; }

        public virtual Box Box { get; set; }
        public virtual Order Order { get; set; }

    }
}
