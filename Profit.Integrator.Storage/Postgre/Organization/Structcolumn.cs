
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("structcolumns")]
    public partial class Structcolumn
    {
        [Column("table_catalog"           , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? TableCatalog           { get; set; } // character varying(128)
        [Column("table_schema"            , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? TableSchema            { get; set; } // character varying(128)
        [Column("table_name"              , CanBeNull = false                     , DataType = LinqToDB.DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string  TableName              { get; set; } = null!; // character varying(128)
        [Column("column_name"             , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? ColumnName             { get; set; } // character varying(128)
        [Column("ordinal_position"        , DataType  = LinqToDB.DataType.Int32   , DbType   = "integer"                                                                  )] public int?    OrdinalPosition        { get; set; } // integer
        [Column("column_default"          , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(4000)" , Length = 4000                                  )] public string? ColumnDefault          { get; set; } // character varying(4000)
        [Column("is_nullable"             , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(3)"    , Length = 3                                     )] public string? IsNullable             { get; set; } // character varying(3)
        [Column("data_type"               , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? DataType               { get; set; } // character varying(128)
        [Column("character_maximum_length", DataType  = LinqToDB.DataType.Int32   , DbType   = "integer"                                                                  )] public int?    CharacterMaximumLength { get; set; } // integer
        [Column("character_octet_length"  , DataType  = LinqToDB.DataType.Int32   , DbType   = "integer"                                                                  )] public int?    CharacterOctetLength   { get; set; } // integer
        [Column("numeric_precision"       , DataType  = LinqToDB.DataType.Int16   , DbType   = "smallint"                                                                 )] public short?  NumericPrecision       { get; set; } // smallint
        [Column("numeric_precision_radix" , DataType  = LinqToDB.DataType.Int16   , DbType   = "smallint"                                                                 )] public short?  NumericPrecisionRadix  { get; set; } // smallint
        [Column("numeric_scale"           , DataType  = LinqToDB.DataType.Int32   , DbType   = "integer"                                                                  )] public int?    NumericScale           { get; set; } // integer
        [Column("datetime_precision"      , DataType  = LinqToDB.DataType.Int16   , DbType   = "smallint"                                                                 )] public short?  DatetimePrecision      { get; set; } // smallint
        [Column("character_set_catalog"   , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? CharacterSetCatalog    { get; set; } // character varying(128)
        [Column("character_set_schema"    , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? CharacterSetSchema     { get; set; } // character varying(128)
        [Column("character_set_name"      , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? CharacterSetName       { get; set; } // character varying(128)
        [Column("collation_catalog"       , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? CollationCatalog       { get; set; } // character varying(128)
        [Column("collation_schema"        , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? CollationSchema        { get; set; } // character varying(128)
        [Column("collation_name"          , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? CollationName          { get; set; } // character varying(128)
        [Column("domain_catalog"          , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? DomainCatalog          { get; set; } // character varying(128)
        [Column("domain_schema"           , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? DomainSchema           { get; set; } // character varying(128)
        [Column("domain_name"             , DataType  = LinqToDB.DataType.NVarChar, DbType   = "character varying(128)"  , Length = 128                                   )] public string? DomainName             { get; set; } // character varying(128)
    }
}
