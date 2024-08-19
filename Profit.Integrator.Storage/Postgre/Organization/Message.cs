
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("messages")]
    public partial class Message
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("enabled", DataType = DataType.Boolean, DbType = "boolean")] public bool? Enabled { get; set; } // boolean
        [Column("type", DataType = DataType.Int32, DbType = "integer")] public int? Type { get; set; } // integer
        [Column("messageid", DataType = DataType.Guid, DbType = "uuid")] public Guid Messageid { get; set; } // uuid
        [Column("culture", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Culture { get; set; } = null!; // character varying(50)
        [Column("text", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Text { get; set; } // character varying(4000)
    }
}
