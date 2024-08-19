
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("accessforms")]
    public partial class Accessform
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("controller", DataType = DataType.Boolean, DbType = "boolean")] public bool Controller { get; set; } // boolean
        [Column("operator", DataType = DataType.Boolean, DbType = "boolean")] public bool Operator { get; set; } // boolean
        [Column("assigned", DataType = DataType.Boolean, DbType = "boolean")] public bool Assigned { get; set; } // boolean
        [Column("operregion", DataType = DataType.Boolean, DbType = "boolean")] public bool? Operregion { get; set; } // boolean
        [Column("none", DataType = DataType.Boolean, DbType = "boolean")] public bool? None { get; set; } // boolean
    }
}
