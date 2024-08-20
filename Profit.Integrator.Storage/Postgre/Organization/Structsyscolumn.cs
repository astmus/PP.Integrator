
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("structsyscolumns")]
    public partial class Structsyscolumn
    {
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Name { get; set; } // character varying(128)
        [Column("id"  , DataType = DataType.Int32   , DbType = "integer"                             )] public int     Id   { get; set; } // integer
    }
}
