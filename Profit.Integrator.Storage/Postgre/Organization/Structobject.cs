
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("structobjects")]
    public partial class Structobject
    {
        [Column("name"               , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(128)", Length = 128)] public string   Name              { get; set; } = null!; // character varying(128)
        [Column("object_id"          , DataType  = DataType.Int32    , DbType   = "integer"                                                                         )] public int      ObjectId          { get; set; } // integer
        [Column("principal_id"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                         )] public int?     PrincipalId       { get; set; } // integer
        [Column("schema_id"          , DataType  = DataType.Int32    , DbType   = "integer"                                                                         )] public int      SchemaId          { get; set; } // integer
        [Column("parent_object_id"   , DataType  = DataType.Int32    , DbType   = "integer"                                                                         )] public int      ParentObjectId    { get; set; } // integer
        [Column("type"               , CanBeNull = false             , DataType = DataType.NChar                   , DbType = "character(2)"          , Length = 2  )] public string   Type              { get; set; } = null!; // character(2)
        [Column("type_desc"          , DataType  = DataType.NVarChar , DbType   = "character varying(60)"          , Length = 60                                    )] public string?  TypeDesc          { get; set; } // character varying(60)
        [Column("create_date"        , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime CreateDate        { get; set; } // timestamp (6) without time zone
        [Column("modify_date"        , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime ModifyDate        { get; set; } // timestamp (6) without time zone
        [Column("is_ms_shipped"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool     IsMsShipped       { get; set; } // boolean
        [Column("is_published"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool     IsPublished       { get; set; } // boolean
        [Column("is_schema_published", DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool     IsSchemaPublished { get; set; } // boolean
    }
}
