
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("activedirectory$membership")]
    public partial class ActivedirectoryMembership
    {
        [Column("id"               , DataType = DataType.Guid, DbType = "uuid")] public Guid Id                { get; set; } // uuid
        [Column("containerentityid", DataType = DataType.Guid, DbType = "uuid")] public Guid Containerentityid { get; set; } // uuid
        [Column("containedentityid", DataType = DataType.Guid, DbType = "uuid")] public Guid Containedentityid { get; set; } // uuid
    }
}
