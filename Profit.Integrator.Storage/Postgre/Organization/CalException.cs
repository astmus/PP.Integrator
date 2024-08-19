
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("cal_exception")]
    public partial class CalException
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("id_cal", DataType = DataType.Guid, DbType = "uuid")] public Guid IdCal { get; set; } // uuid
        [Column("tbeg", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Tbeg { get; set; } // timestamp (6) without time zone
        [Column("tend", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Tend { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean
    }
}
