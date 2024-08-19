
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_externalresourcesavailability")]
    public partial class ViExternalresourcesavailability
    {
        [Column("resourceid", DataType = DataType.Guid, DbType = "uuid")] public Guid Resourceid { get; set; } // uuid
        [Column("unavailabletime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Unavailabletime { get; set; } // timestamp (6) without time zone
    }
}
