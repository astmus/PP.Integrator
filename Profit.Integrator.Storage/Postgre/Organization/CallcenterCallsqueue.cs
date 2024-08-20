
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenter_callsqueue")]
    public partial class CallcenterCallsqueue
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid     Id                 { get; set; } // uuid
        [Column("dialingobjectid"   , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid     Dialingobjectid    { get; set; } // uuid
        [Column("externalresourceid", DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid     Externalresourceid { get; set; } // uuid
        [Column("contextid"         , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid     Contextid          { get; set; } // uuid
        [Column("enqueuetime"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Enqueuetime        { get; set; } // timestamp (6) without time zone
    }
}
