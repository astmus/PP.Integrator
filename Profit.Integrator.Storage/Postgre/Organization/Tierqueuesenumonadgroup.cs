
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("tierqueuesenumonadgroup")]
    public partial class Tierqueuesenumonadgroup
    {
        [Column("enumtypeid"            , DataType = DataType.Guid, DbType = "uuid")] public Guid Enumtypeid             { get; set; } // uuid
        [Column("activedirectorygroupid", DataType = DataType.Guid, DbType = "uuid")] public Guid Activedirectorygroupid { get; set; } // uuid
    }
}
