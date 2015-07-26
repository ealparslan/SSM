namespace deneme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Barcode
    {
        public int Id { get; set; }

        public string CodeNumber { get; set; }

        public string CodeType { get; set; }

        public int? BoxId { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public virtual Box Box { get; set; }
    }
}
