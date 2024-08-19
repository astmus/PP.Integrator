
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("users_logs")]
    public partial class UsersLog
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("logname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Logname { get; set; } = null!; // character varying(128)
        [Column("logvalue", DataType = DataType.Text, DbType = "text")] public string? Logvalue { get; set; } // text
        [Column("comment", DataType = DataType.Text, DbType = "text")] public string? Comment { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("activitylogtypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Activitylogtypeid { get; set; } // uuid
        [Column("objectid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Objectid { get; set; } // uuid
        [Column("info", DataType = DataType.Text, DbType = "text")] public string? Info { get; set; } // text
        [Column("issuccessful", DataType = DataType.Boolean, DbType = "boolean")] public bool? Issuccessful { get; set; } // boolean
    }
}
