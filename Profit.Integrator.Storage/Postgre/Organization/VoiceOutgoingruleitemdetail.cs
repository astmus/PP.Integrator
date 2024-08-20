
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_outgoingruleitemdetails")]
    public partial class VoiceOutgoingruleitemdetail
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Id                 { get; set; } // uuid
        [Column("outgoingruleitemid", DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Outgoingruleitemid { get; set; } // uuid
        [Column("callid"            , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Callid             { get; set; } // uuid
        [Column("callcentercallid"  , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Callcentercallid   { get; set; } // uuid
        [Column("contextid"         , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Contextid          { get; set; } // uuid
        [Column("context"           , DataType = DataType.Text     , DbType = "text"                                         )] public string?   Context            { get; set; } // text
        [Column("activitytype"      , DataType = DataType.NVarChar , DbType = "character varying(10)"          , Length = 10 )] public string?   Activitytype       { get; set; } // character varying(10)
        [Column("activityresult"    , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length = 255)] public string?   Activityresult     { get; set; } // character varying(255)
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updateddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
    }
}
