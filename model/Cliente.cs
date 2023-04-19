namespace WindowsFormsAppCRUD.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlTypes;
    using System.Numerics;

    [Table("Cliente")]
    public partial class Cliente
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOME { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        public DateTime DATA_NASC { get; set; }

        public long CPF { get; set; }

        public long RG { get; set; }
    }
}
