
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("temp1")]
    public partial class Temp1
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("touserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Touserid { get; set; } // uuid
        [Column("backgroundtaskid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Backgroundtaskid { get; set; } // uuid
        [Column("messagetext", DataType = DataType.Text, DbType = "text")] public string? Messagetext { get; set; } // text
        [Column("reasonitemid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Reasonitemid { get; set; } // uuid
        [Column("userproperties", DataType = DataType.Text, DbType = "text")] public string? Userproperties { get; set; } // text
        [Column("expirydate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Expirydate { get; set; } // timestamp (6) without time zone
        [Column("sendeddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Sendeddate { get; set; } // timestamp (6) without time zone
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("issendingscheduledtime", DataType = DataType.Boolean, DbType = "boolean")] public bool? Issendingscheduledtime { get; set; } // boolean
    }
}
