
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("absenseclassification")]
    public partial class Absenseclassification
    {
        [Column("user", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string User { get; set; } = null!; // character varying(50)
        [Column("dttm1", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Dttm1 { get; set; } // timestamp (6) without time zone
        [Column("dttm2", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Dttm2 { get; set; } // timestamp (6) without time zone
        [Column("subj", DataType = DataType.Text, DbType = "text")] public string? Subj { get; set; } // text
        [Column("type", DataType = DataType.Int16, DbType = "smallint")] public short Type { get; set; } // smallint
        [Column("iswork", DataType = DataType.Int16, DbType = "smallint")] public short Iswork { get; set; } // smallint
        [Column("numberrequests", DataType = DataType.Int16, DbType = "smallint")] public short Numberrequests { get; set; } // smallint
        [Column("article", DataType = DataType.Int32, DbType = "integer")] public int? Article { get; set; } // integer
    }
}
