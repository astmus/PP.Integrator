
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_dialogs")]
    public partial class ViDialog
    {
        [Column("id"                  , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Id                   { get; set; } // uuid
        [Column("sessionid"           , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Sessionid            { get; set; } // uuid
        [Column("recognitionstarttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Recognitionstarttime { get; set; } // timestamp (6) without time zone
        [Column("authoruri"           , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Authoruri            { get; set; } // character varying(256)
        [Column("authorname"          , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length = 256)] public string?   Authorname           { get; set; } // character varying(256)
        [Column("authortype"          , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length = 32 )] public string?   Authortype           { get; set; } // character varying(32)
        [Column("isincoming"          , DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool?     Isincoming           { get; set; } // boolean
        [Column("stepid"              , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Stepid               { get; set; } // uuid
        [Column("phrasesource"        , DataType = DataType.Text     , DbType = "text"                                         )] public string?   Phrasesource         { get; set; } // text
        [Column("phrasechannelsource" , DataType = DataType.Text     , DbType = "text"                                         )] public string?   Phrasechannelsource  { get; set; } // text
        [Column("phrase"              , DataType = DataType.Text     , DbType = "text"                                         )] public string?   Phrase               { get; set; } // text
        [Column("originalid"          , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Originalid           { get; set; } // uuid
        [Column("createddate"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("updateddate"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Updateddate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool      Isdeleted            { get; set; } // boolean
    }
}
