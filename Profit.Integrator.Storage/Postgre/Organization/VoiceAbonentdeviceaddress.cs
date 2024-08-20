
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_abonentdeviceaddresses")]
    public partial class VoiceAbonentdeviceaddress
    {
        [Column("id"       , DataType = DataType.Guid    , DbType = "uuid"                                )] public Guid    Id        { get; set; } // uuid
        [Column("deviceid" , DataType = DataType.Guid    , DbType = "uuid"                                )] public Guid    Deviceid  { get; set; } // uuid
        [Column("title"    , DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Title     { get; set; } // character varying(255)
        [Column("location" , DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Location  { get; set; } // character varying(255)
        [Column("isdeleted", DataType = DataType.Boolean , DbType = "boolean"                             )] public bool    Isdeleted { get; set; } // boolean
    }
}
