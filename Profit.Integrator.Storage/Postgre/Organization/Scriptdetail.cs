
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("scriptdetails")]
    public partial class Scriptdetail
    {
        [Column("parentid"   , DataType = DataType.Guid, DbType = "uuid")] public Guid?   Parentid    { get; set; } // uuid
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
    }
}
