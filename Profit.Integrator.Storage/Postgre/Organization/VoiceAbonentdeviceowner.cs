
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_abonentdeviceowners")]
    public partial class VoiceAbonentdeviceowner
    {
        [Column("deviceid"   , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Deviceid    { get; set; } // uuid
        [Column("abonentid"  , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Abonentid   { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                        )] public bool      Isdeleted   { get; set; } // boolean
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Id          { get; set; } // uuid
    }
}
