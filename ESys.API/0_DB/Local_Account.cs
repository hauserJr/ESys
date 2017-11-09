namespace ESys.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Local_Account
    {
        [Key]
        [Column(Order = 0)]
        public Guid Account_Guid { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string UserAccount { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string Password { get; set; }

        [Column(Order = 3)]
        public bool EmailCheck { get; set; }
    }
}
