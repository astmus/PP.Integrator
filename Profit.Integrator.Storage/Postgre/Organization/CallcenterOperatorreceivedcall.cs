
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcenter_operatorreceivedcalls")]
    public partial class CallcenterOperatorreceivedcall
    {
        [Column("operatorid", DataType = DataType.Guid, DbType = "uuid")] public Guid Operatorid { get; set; } // uuid
        [Column("lastreceivedcalltime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastreceivedcalltime { get; set; } // timestamp (6) without time zone
    }
}
