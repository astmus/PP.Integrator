
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("structtable_constraints")]
    public partial class StructtableConstraint
    {
        [Column("constraint_catalog", DataType  = DataType.NVarChar, DbType   = "character varying(128)", Length = 128                                   )] public string? ConstraintCatalog { get; set; } // character varying(128)
        [Column("constraint_schema" , DataType  = DataType.NVarChar, DbType   = "character varying(128)", Length = 128                                   )] public string? ConstraintSchema  { get; set; } // character varying(128)
        [Column("constraint_name"   , CanBeNull = false            , DataType = DataType.NVarChar       , DbType = "character varying(128)", Length = 128)] public string  ConstraintName    { get; set; } = null!; // character varying(128)
        [Column("table_catalog"     , DataType  = DataType.NVarChar, DbType   = "character varying(128)", Length = 128                                   )] public string? TableCatalog      { get; set; } // character varying(128)
        [Column("table_schema"      , DataType  = DataType.NVarChar, DbType   = "character varying(128)", Length = 128                                   )] public string? TableSchema       { get; set; } // character varying(128)
        [Column("table_name"        , DataType  = DataType.NVarChar, DbType   = "character varying(128)", Length = 128                                   )] public string? TableName         { get; set; } // character varying(128)
        [Column("constraint_type"   , DataType  = DataType.NVarChar, DbType   = "character varying(11)" , Length = 11                                    )] public string? ConstraintType    { get; set; } // character varying(11)
        [Column("is_deferrable"     , CanBeNull = false            , DataType = DataType.NVarChar       , DbType = "character varying(2)"  , Length = 2  )] public string  IsDeferrable      { get; set; } = null!; // character varying(2)
        [Column("initially_deferred", CanBeNull = false            , DataType = DataType.NVarChar       , DbType = "character varying(2)"  , Length = 2  )] public string  InitiallyDeferred { get; set; } = null!; // character varying(2)
    }
}
