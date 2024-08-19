
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("notification")]
    public partial class Notification
    {
        [Column("id", DataType = DataType.Int64, DbType = "bigint")] public long Id { get; set; } // bigint
    }
}
