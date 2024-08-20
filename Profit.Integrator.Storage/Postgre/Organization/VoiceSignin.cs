
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_signins")]
    public partial class VoiceSignin
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Id                 { get; set; } // uuid
        [Column("employeeid"        , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Employeeid         { get; set; } // uuid
        [Column("userphone"         , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length = 255)] public string?   Userphone          { get; set; } // character varying(255)
        [Column("roleid"            , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length = 50 )] public string?   Roleid             { get; set; } // character varying(50)
        [Column("contextid"         , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Contextid          { get; set; } // uuid
        [Column("recentactivitytime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Recentactivitytime { get; set; } // timestamp (6) without time zone
        [Column("status"            , DataType = DataType.Int32    , DbType = "integer"                                      )] public int?      Status             { get; set; } // integer
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updateddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid"   , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Createdbyuserid    { get; set; } // uuid
        [Column("updatedbyuserid"   , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Updatedbyuserid    { get; set; } // uuid
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool?     Isdeleted          { get; set; } // boolean
    }
}
