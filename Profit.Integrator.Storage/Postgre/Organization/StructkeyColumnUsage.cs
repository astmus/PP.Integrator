
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("structkey_column_usage")]
    public partial class StructkeyColumnUsage
    {
        [Column("constraint_catalog", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? ConstraintCatalog { get; set; } // character varying(128)
        [Column("constraint_schema", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? ConstraintSchema { get; set; } // character varying(128)
        [Column("constraint_name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string ConstraintName { get; set; } = null!; // character varying(128)
        [Column("table_catalog", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? TableCatalog { get; set; } // character varying(128)
        [Column("table_schema", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? TableSchema { get; set; } // character varying(128)
        [Column("table_name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string TableName { get; set; } = null!; // character varying(128)
        [Column("column_name", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? ColumnName { get; set; } // character varying(128)
        [Column("ordinal_position", DataType = DataType.Int32, DbType = "integer")] public int OrdinalPosition { get; set; } // integer
    }
}
