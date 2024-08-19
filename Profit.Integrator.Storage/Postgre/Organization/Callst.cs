
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callst")]
    public partial class Callst
    {
        [Column("guids", DataType = DataType.Guid, DbType = "uuid")] public Guid? Guids { get; set; } // uuid
        [Column("databasename", DataType = DataType.NVarChar, DbType = "character varying(200)", Length = 200)] public string? Databasename { get; set; } // character varying(200)
        [Column("calls", DataType = DataType.Int32, DbType = "integer")] public int? Calls { get; set; } // integer
        [Column("callin", DataType = DataType.Int32, DbType = "integer")] public int? Callin { get; set; } // integer
        [Column("callout", DataType = DataType.Int32, DbType = "integer")] public int? Callout { get; set; } // integer
        [Column("maxd", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Maxd { get; set; } // timestamp (6) without time zone
    }
}
