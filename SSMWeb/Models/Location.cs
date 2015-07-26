namespace SSMWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        public string Description { get; set; }

        public virtual HashSet<Box> Boxes { get; set; }
    }
}
