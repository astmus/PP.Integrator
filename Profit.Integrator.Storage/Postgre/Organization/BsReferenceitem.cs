
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("bs_referenceitems")]
    public partial class BsReferenceitem
    {
        [Column("id"             , DataType = DataType.Guid      , DbType = "uuid"                                          )] public Guid      Id              { get; set; } // uuid
        [Column("referencetypeid", DataType = DataType.Guid      , DbType = "uuid"                                          )] public Guid      Referencetypeid { get; set; } // uuid
        [Column("externalid"     , DataType = DataType.NVarChar  , DbType = "character varying(64)"          , Length = 64  )] public string?   Externalid      { get; set; } // character varying(64)
        [Column("cod"            , DataType = DataType.Int32     , DbType = "integer"                                       )] public int?      Cod             { get; set; } // integer
        [Column("name"           , DataType = DataType.NVarChar  , DbType = "character varying(1024)"        , Length = 1024)] public string?   Name            { get; set; } // character varying(1024)
        [Column("lemmaname"      , DataType = DataType.NVarChar  , DbType = "character varying(1024)"        , Length = 1024)] public string?   Lemmaname       { get; set; } // character varying(1024)
        [Column("properties"     , DataType = DataType.BinaryJson, DbType = "jsonb"                                         )] public string?   Properties      { get; set; } // jsonb
        [Column("createddate"    , DataType = DataType.DateTime2 , DbType = "timestamp (6) without time zone"               )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updateddate"    , DataType = DataType.DateTime2 , DbType = "timestamp (6) without time zone"               )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean   , DbType = "boolean"                                       )] public bool      Isdeleted       { get; set; } // boolean
        [Column("parentid"       , DataType = DataType.Guid      , DbType = "uuid"                                          )] public Guid?     Parentid        { get; set; } // uuid
        [Column("isfolder"       , DataType = DataType.Boolean   , DbType = "boolean"                                       )] public bool      Isfolder        { get; set; } // boolean
        [Column("position"       , DataType = DataType.Int32     , DbType = "integer"                                       )] public int?      Position        { get; set; } // integer
    }
}
