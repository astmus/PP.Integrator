
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("nlu_category")]
    public partial class NluCategory
    {
        [Column("category", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Category { get; set; } // character varying(50)
        [Column("template", DataType = DataType.NVarChar, DbType = "character varying(200)", Length = 200)] public string? Template { get; set; } // character varying(200)
    }
}
