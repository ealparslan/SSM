namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderList
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public DateTime SoldDate { get; set; }

        [Required]
        public string SalesChannel { get; set; }

        public int BoxId { get; set; }

        [Required]
        public string SoldQty { get; set; }

        //public virtual Box Box { get; set; }

        public virtual Order Order { get; set; }

    }
}
