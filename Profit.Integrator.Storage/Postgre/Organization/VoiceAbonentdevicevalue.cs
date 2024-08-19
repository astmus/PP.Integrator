
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_abonentdevicevalues")]
    public partial class VoiceAbonentdevicevalue
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("abonentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Abonentid { get; set; } // uuid
        [Column("deviceid", DataType = DataType.Guid, DbType = "uuid")] public Guid Deviceid { get; set; } // uuid
        [Column("ratetypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid Ratetypeid { get; set; } // uuid
        [Column("passdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Passdate { get; set; } // timestamp (6) without time zone
        [Column("value", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Value { get; set; } // character varying(50)
        [Column("Сonsumption", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Сonsumption { get; set; } // character varying(50)
        [Column("avgvalue", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Avgvalue { get; set; } // character varying(50)
        [Column("phonenumber", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Phonenumber { get; set; } // character varying(50)
        [Column("callid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Callid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("consumption", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Consumption { get; set; } // character varying(50)
    }
}
