
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("calendar")]
    public partial class Calendar
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Name { get; set; } = null!; // character varying(50)
        [Column("b1", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B1 { get; set; } // timestamp (6) without time zone
        [Column("e1", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E1 { get; set; } // timestamp (6) without time zone
        [Column("b2", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B2 { get; set; } // timestamp (6) without time zone
        [Column("e2", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E2 { get; set; } // timestamp (6) without time zone
        [Column("b3", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B3 { get; set; } // timestamp (6) without time zone
        [Column("e3", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E3 { get; set; } // timestamp (6) without time zone
        [Column("b4", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B4 { get; set; } // timestamp (6) without time zone
        [Column("e4", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E4 { get; set; } // timestamp (6) without time zone
        [Column("b5", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B5 { get; set; } // timestamp (6) without time zone
        [Column("e5", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E5 { get; set; } // timestamp (6) without time zone
        [Column("b6", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B6 { get; set; } // timestamp (6) without time zone
        [Column("e6", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E6 { get; set; } // timestamp (6) without time zone
        [Column("b7", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? B7 { get; set; } // timestamp (6) without time zone
        [Column("e7", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? E7 { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean
    }
}
