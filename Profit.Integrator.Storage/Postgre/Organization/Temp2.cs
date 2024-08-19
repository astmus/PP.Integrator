
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("temp2")]
    public partial class Temp2
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("usernotificationid", DataType = DataType.Guid, DbType = "uuid")] public Guid Usernotificationid { get; set; } // uuid
        [Column("notifychannelid", DataType = DataType.Guid, DbType = "uuid")] public Guid Notifychannelid { get; set; } // uuid
        [Column("sendeddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Sendeddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("plansendeddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Plansendeddate { get; set; } // timestamp (6) without time zone
        [Column("countunsuccess", DataType = DataType.Int32, DbType = "integer")] public int? Countunsuccess { get; set; } // integer
    }
}
