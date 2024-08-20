
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("timezones")]
    public partial class Timezone
    {
        [Column("id"        , DataType  = DataType.Guid   , DbType   = "uuid"                                                                    )] public Guid     Id         { get; set; } // uuid
        [Column("name"      , DataType  = DataType.Text   , DbType   = "text"                                                                    )] public string?  Name       { get; set; } // text
        [Column("timezone"  , CanBeNull = false           , DataType = DataType.NVarChar          , DbType = "character varying(50)", Length = 50)] public string   Timezone1  { get; set; } = null!; // character varying(50)
        [Column("sign"      , DataType  = DataType.Boolean, DbType   = "boolean"                                                                 )] public bool     Sign       { get; set; } // boolean
        [Column("timeoffset", DataType  = DataType.Time   , DbType   = "time(3) without time zone"                                               )] public TimeSpan Timeoffset { get; set; } // time(3) without time zone
        [Column("isdeleted" , DataType  = DataType.Boolean, DbType   = "boolean"                                                                 )] public bool     Isdeleted  { get; set; } // boolean
    }
}
