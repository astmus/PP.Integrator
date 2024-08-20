
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_chatactivities")]
    public partial class ViChatactivity
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Id                 { get; set; } // uuid
        [Column("activityid"        , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length = 128)] public string?   Activityid         { get; set; } // character varying(128)
        [Column("isincoming"        , DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool?     Isincoming         { get; set; } // boolean
        [Column("conversationid"    , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length = 512)] public string?   Conversationid     { get; set; } // character varying(512)
        [Column("fromid"            , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Fromid             { get; set; } // character varying(256)
        [Column("fromname"          , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Fromname           { get; set; } // character varying(256)
        [Column("toid"              , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Toid               { get; set; } // character varying(256)
        [Column("toname"            , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Toname             { get; set; } // character varying(256)
        [Column("serviceurl"        , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length = 512)] public string?   Serviceurl         { get; set; } // character varying(512)
        [Column("channeltype"       , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Channeltype        { get; set; } // character varying(256)
        [Column("channelid"         , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Channelid          { get; set; } // uuid
        [Column("text"              , DataType = DataType.Text     , DbType = "text"                                         )] public string?   Text               { get; set; } // text
        [Column("textformat"        , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length = 32 )] public string?   Textformat         { get; set; } // character varying(32)
        [Column("type"              , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length = 32 )] public string?   Type               { get; set; } // character varying(32)
        [Column("status"            , DataType = DataType.Int32    , DbType = "integer"                                      )] public int?      Status             { get; set; } // integer
        [Column("platformid"        , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Platformid         { get; set; } // uuid
        [Column("accountid"         , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Accountid          { get; set; } // uuid
        [Column("receivepitserverid", DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Receivepitserverid { get; set; } // uuid
        [Column("processpitserverid", DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Processpitserverid { get; set; } // uuid
        [Column("pitchatid"         , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Pitchatid          { get; set; } // uuid
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updateddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool      Isdeleted          { get; set; } // boolean
    }
}
