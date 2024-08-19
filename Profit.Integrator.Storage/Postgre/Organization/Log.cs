
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("logs")]
    public partial class Log
    {
        [Column("dttm", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Dttm { get; set; } // timestamp (6) without time zone
        [Column("userid", DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100)] public string? Userid { get; set; } // character varying(100)
        [Column("tasknum", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Tasknum { get; set; } // character varying(50)
        [Column("text", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Text { get; set; } // character varying(4000)
        [Column("robot", DataType = DataType.Boolean, DbType = "boolean")] public bool? Robot { get; set; } // boolean
        [Column("fordel", DataType = DataType.NChar, DbType = "character(10)", Length = 10)] public string? Fordel { get; set; } // character(10)
    }
}
