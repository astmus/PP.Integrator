
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_sessions")]
    public partial class ViSession
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("typeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Typeid { get; set; } // uuid
        [Column("channeltype", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Channeltype { get; set; } // character varying(256)
        [Column("channelid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Channelid { get; set; } // uuid
        [Column("accountid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Accountid { get; set; } // uuid
        [Column("conversationid", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Conversationid { get; set; } // character varying(512)
        [Column("serviceurl", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Serviceurl { get; set; } // character varying(512)
        [Column("initiatoruri", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Initiatoruri { get; set; } // character varying(256)
        [Column("initiatorname", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Initiatorname { get; set; } // character varying(256)
        [Column("boturi", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Boturi { get; set; } // character varying(256)
        [Column("botname", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Botname { get; set; } // character varying(256)
        [Column("starttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Starttime { get; set; } // timestamp (6) without time zone
        [Column("endtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Endtime { get; set; } // timestamp (6) without time zone
        [Column("isincoming", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isincoming { get; set; } // boolean
        [Column("scriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Scriptid { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Userid { get; set; } // uuid
        [Column("userinfo", DataType = DataType.Text, DbType = "text")] public string? Userinfo { get; set; } // text
        [Column("originalid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Originalid { get; set; } // uuid
        [Column("internalinfo", DataType = DataType.Text, DbType = "text")] public string? Internalinfo { get; set; } // text
        [Column("externalinfo", DataType = DataType.Text, DbType = "text")] public string? Externalinfo { get; set; } // text
        [Column("incidentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Incidentid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
