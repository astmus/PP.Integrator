
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("links")]
    public partial class Link
    {
        [Column("scriptid", DataType = DataType.Guid   , DbType = "uuid"   )] public Guid? Scriptid { get; set; } // uuid
        [Column("parentid", DataType = DataType.Guid   , DbType = "uuid"   )] public Guid? Parentid { get; set; } // uuid
        [Column("rate"    , DataType = DataType.Int32  , DbType = "integer")] public int?  Rate     { get; set; } // integer
        [Column("deleted" , DataType = DataType.Boolean, DbType = "boolean")] public bool? Deleted  { get; set; } // boolean
    }
}
