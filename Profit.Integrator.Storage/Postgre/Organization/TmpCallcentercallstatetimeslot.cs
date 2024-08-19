
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("tmp_callcentercallstatetimeslot")]
    public partial class TmpCallcentercallstatetimeslot
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("logtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Logtime { get; set; } // timestamp (6) without time zone
        [Column("userwaitingcount", DataType = DataType.Int32, DbType = "integer")] public int? Userwaitingcount { get; set; } // integer
        [Column("userspeakingcount", DataType = DataType.Int32, DbType = "integer")] public int? Userspeakingcount { get; set; } // integer
        [Column("userinivrmenucount", DataType = DataType.Int32, DbType = "integer")] public int? Userinivrmenucount { get; set; } // integer
        [Column("operatorpausingcount", DataType = DataType.Int32, DbType = "integer")] public int? Operatorpausingcount { get; set; } // integer
        [Column("operatorworkingcount", DataType = DataType.Int32, DbType = "integer")] public int? Operatorworkingcount { get; set; } // integer
        [Column("operatorspeakingcount", DataType = DataType.Int32, DbType = "integer")] public int? Operatorspeakingcount { get; set; } // integer
        [Column("simulincomecallcount", DataType = DataType.Int32, DbType = "integer")] public int? Simulincomecallcount { get; set; } // integer
        [Column("simuloutgoingcallcount", DataType = DataType.Int32, DbType = "integer")] public int? Simuloutgoingcallcount { get; set; } // integer
    }
}
