
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_abonentdeviceverifications")]
    public partial class VoiceAbonentdeviceverification
    {
        [Column("abonentid", DataType = DataType.Guid, DbType = "uuid")] public Guid Abonentid { get; set; } // uuid
        [Column("deviceid", DataType = DataType.Guid, DbType = "uuid")] public Guid Deviceid { get; set; } // uuid
        [Column("isverified", DataType = DataType.Boolean, DbType = "boolean")] public bool Isverified { get; set; } // boolean
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("verificationdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Verificationdate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
