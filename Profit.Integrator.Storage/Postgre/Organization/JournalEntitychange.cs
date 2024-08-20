
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("journal_entitychanges")]
    public partial class JournalEntitychange
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid     Id              { get; set; } // uuid
        [Column("parentid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid?    Parentid        { get; set; } // uuid
        [Column("objecttable"    , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(128)", Length = 128)] public string   Objecttable     { get; set; } = null!; // character varying(128)
        [Column("objectid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid     Objectid        { get; set; } // uuid
        [Column("objectversion"  , DataType  = DataType.Int32    , DbType   = "integer"                                                                         )] public int?     Objectversion   { get; set; } // integer
        [Column("authorid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid?    Authorid        { get; set; } // uuid
        [Column("changedate"     , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime Changedate      { get; set; } // timestamp (6) without time zone
        [Column("objectxml"      , DataType  = DataType.Xml      , DbType   = "xml"                                                                             )] public string?  Objectxml       { get; set; } // xml
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid     Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime Createddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool     Isdeleted       { get; set; } // boolean
    }
}
