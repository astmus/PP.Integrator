
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_scriptsversions")]
    public partial class VoiceScriptsversion
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("scriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid Scriptid { get; set; } // uuid
        [Column("versiontype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Versiontype { get; set; } = null!; // character varying(50)
        [Column("version", DataType = DataType.Int32, DbType = "integer")] public int Version { get; set; } // integer
        [Column("scriptjson", DataType = DataType.Text, DbType = "text")] public string? Scriptjson { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
