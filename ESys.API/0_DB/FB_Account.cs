namespace ESys.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FB_Account
    {
        [Key]
        [Column(Order = 0)]
        public Guid FBAccount_Guid { get; set; }

        [Column(Order = 1)]
        [StringLength(200)]
        public string Email { get; set; }

        [Column(Order = 2)]
        [StringLength(200)]
        public string ProviderKey { get; set; }
    }
}
