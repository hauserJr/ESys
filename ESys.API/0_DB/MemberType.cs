namespace ESys.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberType
    {
        [Key]
        [Column(Order = 0)]
        public Guid MemberType_Guid { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string MemberType_Name { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string MemberType_Code { get; set; }
    }
}
