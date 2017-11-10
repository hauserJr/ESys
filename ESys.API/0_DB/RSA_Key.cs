namespace ESys.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RSA_Key
    {
        [Key]
        [Column(Order = 0)]
        public Guid RSA_Guid { get; set; }

        [Column(Order = 1)]
        public string PublicKey { get; set; }

        [Column(Order = 2)]
        public string PrivateKey { get; set; }

        [Column(Order = 3)]
        public string RSA_Type { get; set; }

    }
}
