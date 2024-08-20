
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("accesstoobject")]
    public partial class Accesstoobject
    {
        [Column("idobject"   , DataType = DataType.Guid   , DbType = "uuid"   )] public Guid  Idobject    { get; set; } // uuid
        [Column("idgroupsm"  , DataType = DataType.Guid   , DbType = "uuid"   )] public Guid  Idgroupsm   { get; set; } // uuid
        [Column("readaccess" , DataType = DataType.Boolean, DbType = "boolean")] public bool? Readaccess  { get; set; } // boolean
        [Column("writeaccess", DataType = DataType.Boolean, DbType = "boolean")] public bool? Writeaccess { get; set; } // boolean
        [Column("typeobject" , DataType = DataType.Int32  , DbType = "integer")] public int   Typeobject  { get; set; } // integer
    }
}
