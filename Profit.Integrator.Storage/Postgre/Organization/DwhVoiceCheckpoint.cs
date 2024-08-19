
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("dwh_voice_checkpoints")]
    public partial class DwhVoiceCheckpoint
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("completetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Completetime { get; set; } // timestamp (6) without time zone
        [Column("stepid", DataType = DataType.Guid, DbType = "uuid")] public Guid Stepid { get; set; } // uuid
        [Column("movecount", DataType = DataType.Int32, DbType = "integer")] public int Movecount { get; set; } // integer
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
