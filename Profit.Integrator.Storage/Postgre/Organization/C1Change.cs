
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("c1_change")]
    public partial class C1Change
    {
        [Column("exc_id", DataType = DataType.Guid, DbType = "uuid")] public Guid ExcId { get; set; } // uuid
        [Column("exc_dt", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime ExcDt { get; set; } // timestamp (6) without time zone
        [Column("exc_done", DataType = DataType.Int16, DbType = "smallint")] public short ExcDone { get; set; } // smallint
        [Column("incid", DataType = DataType.Guid, DbType = "uuid")] public Guid Incid { get; set; } // uuid
        [Column("state", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string State { get; set; } = null!; // character varying(50)
    }
}
