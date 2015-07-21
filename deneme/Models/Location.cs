namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        public Location()
        {
            Boxes = new HashSet<Box>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Box> Boxes { get; set; }
    }
}
