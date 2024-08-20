
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("calls")]
    public partial class Call
    {
        [Column("id"                , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid      Id                 { get; set; } // uuid
        [Column("usersip"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(255)", Length = 255)] public string    Usersip            { get; set; } = null!; // character varying(255)
        [Column("confid"            , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(50)" , Length = 50 )] public string    Confid             { get; set; } = null!; // character varying(50)
        [Column("poolitemid"        , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length = 50                                    )] public string?   Poolitemid         { get; set; } // character varying(50)
        [Column("dt0"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime  Dt0                { get; set; } // timestamp (6) without time zone
        [Column("dt2"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime? Dt2                { get; set; } // timestamp (6) without time zone
        [Column("file"              , DataType  = DataType.Binary   , DbType   = "bytea"                                                                           )] public byte[]?   File               { get; set; } // bytea
        [Column("log"               , DataType  = DataType.Text     , DbType   = "text"                                                                            )] public string?   Log                { get; set; } // text
        [Column("incomeline"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid?     Incomeline         { get; set; } // uuid
        [Column("virtuallineid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid?     Virtuallineid      { get; set; } // uuid
        [Column("isincoming"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool      Isincoming         { get; set; } // boolean
        [Column("agentsip"          , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(255)", Length = 255)] public string    Agentsip           { get; set; } = null!; // character varying(255)
        [Column("dt1"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime  Dt1                { get; set; } // timestamp (6) without time zone
        [Column("hasrecord"         , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool?     Hasrecord          { get; set; } // boolean
        [Column("isredirected"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool?     Isredirected       { get; set; } // boolean
        [Column("callinitiateuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid?     Callinitiateuserid { get; set; } // uuid
        [Column("callanswereduserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid?     Callanswereduserid { get; set; } // uuid
        [Column("rowsource"         , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length = 255                                   )] public string?   Rowsource          { get; set; } // character varying(255)
    }
}
