
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("usersstate")]
    public partial class Usersstate
    {
        [Column("User", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string User { get; set; } = null!; // character varying(50)
        [Column("dttm", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Dttm { get; set; } // timestamp (6) without time zone
        [Column("state", DataType = DataType.Int16, DbType = "smallint")] public short State { get; set; } // smallint
        [Column("lastrequest", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Lastrequest { get; set; } // timestamp (6) without time zone
        [Column("source", DataType = DataType.Int16, DbType = "smallint")] public short Source { get; set; } // smallint
        [Column("test", DataType = DataType.NChar, DbType = "character(10)", Length = 10)] public string? Test { get; set; } // character(10)
        [Column("lyncstate", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Lyncstate { get; set; } // character varying(16)
    }
}
