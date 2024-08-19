
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callresultstate")]
    public partial class Callresultstate
    {
        [Column("statecode", DataType = DataType.Int32, DbType = "integer")] public int Statecode { get; set; } // integer
        [Column("textcode", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(150)", Length = 150)] public string Textcode { get; set; } = null!; // character varying(150)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
    }
}
