
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("uvw_actionlogs", IsView = true)]
    public partial class UvwActionlog
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", SkipOnInsert = true, SkipOnUpdate = true)] public Guid? Id { get; set; } // uuid
        [Column("username", DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100, SkipOnInsert = true, SkipOnUpdate = true)] public string? Username { get; set; } // character varying(100)
        [Column("userlogin", DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100, SkipOnInsert = true, SkipOnUpdate = true)] public string? Userlogin { get; set; } // character varying(100)
        [Column("logname", DataType = DataType.NVarChar, DbType = "character varying(300)", Length = 300, SkipOnInsert = true, SkipOnUpdate = true)] public string? Logname { get; set; } // character varying(300)
        [Column("comment", DataType = DataType.Text, DbType = "text", SkipOnInsert = true, SkipOnUpdate = true)] public string? Comment { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone", SkipOnInsert = true, SkipOnUpdate = true)] public DateTime? Createddate { get; set; } // timestamp (6) without time zone
        [Column("ipaddress", DataType = DataType.Text, DbType = "text", SkipOnInsert = true, SkipOnUpdate = true)] public string? Ipaddress { get; set; } // text
        [Column("issuccessful", DataType = DataType.Boolean, DbType = "boolean", SkipOnInsert = true, SkipOnUpdate = true)] public bool? Issuccessful { get; set; } // boolean
    }
}
