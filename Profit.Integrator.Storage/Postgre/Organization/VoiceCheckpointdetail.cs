
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_checkpointdetails")]
    public partial class VoiceCheckpointdetail
    {
        [Column("id", DataType = DataType.Int64, DbType = "bigint", IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public long Id { get; set; } // bigint
        [Column("callid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Callid { get; set; } // uuid
        [Column("questionid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Questionid { get; set; } // uuid
        [Column("questiondisplayname", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Questiondisplayname { get; set; } // character varying(255)
        [Column("question", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Question { get; set; } // character varying(512)
        [Column("answer", DataType = DataType.Text, DbType = "text")] public string? Answer { get; set; } // text
        [Column("contextid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Contextid { get; set; } // uuid
        [Column("stepid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Stepid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
