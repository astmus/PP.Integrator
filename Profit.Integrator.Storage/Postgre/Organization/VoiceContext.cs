
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_contexts")]
    public partial class VoiceContext
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("contexttype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Contexttype { get; set; } // character varying(50)
        [Column("data", DataType = DataType.Text, DbType = "text")] public string? Data { get; set; } // text
        [Column("iscompleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Iscompleted { get; set; } // boolean
        [Column("hostfqdn", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Hostfqdn { get; set; } // character varying(50)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
    }
}
