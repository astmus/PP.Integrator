
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("dwh_chats")]
    public partial class DwhChat
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("completetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Completetime { get; set; } // timestamp (6) without time zone
        [Column("productid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Productid { get; set; } // uuid
        [Column("accountid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Accountid { get; set; } // uuid
        [Column("chatscount", DataType = DataType.Int32, DbType = "integer")] public int Chatscount { get; set; } // integer
        [Column("dwhcalcversion", DataType = DataType.Int32, DbType = "integer")] public int? Dwhcalcversion { get; set; } // integer
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
