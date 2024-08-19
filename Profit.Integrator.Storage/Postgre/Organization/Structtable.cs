
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("structtables")]
    public partial class Structtable
    {
        [Column("table_catalog", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? TableCatalog { get; set; } // character varying(128)
        [Column("table_schema", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? TableSchema { get; set; } // character varying(128)
        [Column("table_name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string TableName { get; set; } = null!; // character varying(128)
        [Column("table_type", DataType = DataType.NVarChar, DbType = "character varying(10)", Length = 10)] public string? TableType { get; set; } // character varying(10)
    }
}
