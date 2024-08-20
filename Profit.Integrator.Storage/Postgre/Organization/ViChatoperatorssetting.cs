
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_chatoperatorssettings")]
    public partial class ViChatoperatorssetting
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Id          { get; set; } // uuid
        [Column("userid"     , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Userid      { get; set; } // uuid
        [Column("socketid"   , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid?     Socketid    { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                        )] public bool      Isdeleted   { get; set; } // boolean
    }
}
