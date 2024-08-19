
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("marks")]
    public partial class Mark
    {
        [Column("dt", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Dt { get; set; } // timestamp (6) without time zone
        [Column("user", CanBeNull = false, DataType = DataType.Text, DbType = "text")] public string User { get; set; } = null!; // text
        [Column("mark", DataType = DataType.Int32, DbType = "integer")] public int Mark1 { get; set; } // integer
        [Column("num", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Num { get; set; } // character varying(50)
    }
}
