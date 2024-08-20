
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_chats")]
    public partial class ViChat
    {
        [Column("id"               , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Id                { get; set; } // uuid
        [Column("sessionid"        , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid      Sessionid         { get; set; } // uuid
        [Column("title"            , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length = 128)] public string?   Title             { get; set; } // character varying(128)
        [Column("platformid"       , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Platformid        { get; set; } // uuid
        [Column("receiveserverid"  , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Receiveserverid   { get; set; } // uuid
        [Column("processserverid"  , DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Processserverid   { get; set; } // uuid
        [Column("processviserverid", DataType = DataType.Guid     , DbType = "uuid"                                         )] public Guid?     Processviserverid { get; set; } // uuid
        [Column("properties"       , DataType = DataType.Text     , DbType = "text"                                         )] public string?   Properties        { get; set; } // text
        [Column("createddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime  Createddate       { get; set; } // timestamp (6) without time zone
        [Column("updateddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"              )] public DateTime? Updateddate       { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"        , DataType = DataType.Boolean  , DbType = "boolean"                                      )] public bool      Isdeleted         { get; set; } // boolean
    }
}
