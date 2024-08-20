
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_calls")]
    public partial class VoiceCall
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Id                 { get; set; } // uuid
        [Column("abonent"           , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length = 255)] public string?   Abonent            { get; set; } // character varying(255)
        [Column("scriptid"          , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Scriptid           { get; set; } // uuid
        [Column("starttime"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Starttime          { get; set; } // timestamp (6) without time zone
        [Column("endtime"           , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Endtime            { get; set; } // timestamp (6) without time zone
        [Column("disconnecttime"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Disconnecttime     { get; set; } // timestamp (6) without time zone
        [Column("calltype"          , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length = 50 )] public string?   Calltype           { get; set; } // character varying(50)
        [Column("callcentercallid"  , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Callcentercallid   { get; set; } // uuid
        [Column("extid"             , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length = 50 )] public string?   Extid              { get; set; } // character varying(50)
        [Column("contextid"         , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Contextid          { get; set; } // uuid
        [Column("iscallinconference", DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool?     Iscallinconference { get; set; } // boolean
        [Column("hostfqdn"          , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length = 50 )] public string?   Hostfqdn           { get; set; } // character varying(50)
    }
}
