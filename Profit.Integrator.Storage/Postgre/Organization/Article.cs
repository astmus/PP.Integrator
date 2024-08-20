
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("articles")]
    public partial class Article
    {
        [Column("id"           , DataType  = DataType.Int32  , DbType   = "integer"                                                         )] public int    Id            { get; set; } // integer
        [Column("name"         , CanBeNull = false           , DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100)] public string Name          { get; set; } = null!; // character varying(100)
        [Column("isworkingtime", DataType  = DataType.Boolean, DbType   = "boolean"                                                         )] public bool   Isworkingtime { get; set; } // boolean
        [Column("iscomment"    , DataType  = DataType.Boolean, DbType   = "boolean"                                                         )] public bool   Iscomment     { get; set; } // boolean
        [Column("isdeleted"    , DataType  = DataType.Boolean, DbType   = "boolean"                                                         )] public bool?  Isdeleted     { get; set; } // boolean
    }
}
