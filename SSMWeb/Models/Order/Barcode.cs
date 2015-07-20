namespace DataLayerPrimitives
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Barcode
    {
        public Barcode()
        {
            Box = new Box();
        }

        public int Id { get; set; }

        [Required]
        public string CodeNumber { get; set; }

        [Required]
        public string CodeType { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public virtual Box Box { get; set; }
    }
}
