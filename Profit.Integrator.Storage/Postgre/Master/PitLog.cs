
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("pit_logs")]
    public partial class PitLog
    {
        [Column("id", DataType = DataType.Int64, DbType = "bigint", IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public long Id { get; set; } // bigint
        [Column("module", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Module { get; set; } // character varying(50)
        [Column("method", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Method { get; set; } // character varying(50)
        [Column("eventtype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Eventtype { get; set; } // character varying(50)
        [Column("eventtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Eventtime { get; set; } // timestamp (6) without time zone
        [Column("eventtext", DataType = DataType.Text, DbType = "text")] public string? Eventtext { get; set; } // text
    }
}
