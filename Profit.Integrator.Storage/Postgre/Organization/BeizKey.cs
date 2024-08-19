
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("beiz_key")]
    public partial class BeizKey
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("category", DataType = DataType.Guid, DbType = "uuid")] public Guid Category { get; set; } // uuid
        [Column("type", DataType = DataType.Int16, DbType = "smallint")] public short Type { get; set; } // smallint
        [Column("word", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Word { get; set; } = null!; // character varying(255)
        [Column("freq", DataType = DataType.Int32, DbType = "integer")] public int Freq { get; set; } // integer
    }
}
