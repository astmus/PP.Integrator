
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("uvw_statushistory", IsView = true)]
    public partial class UvwStatushistory
    {
        [Column("incidentid"  , DataType = DataType.Guid     , DbType = "uuid"                           , SkipOnInsert = true, SkipOnUpdate = true)] public Guid?     Incidentid   { get; set; } // uuid
        [Column("statusid"    , DataType = DataType.Guid     , DbType = "uuid"                           , SkipOnInsert = true, SkipOnUpdate = true)] public Guid?     Statusid     { get; set; } // uuid
        [Column("assigneddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone", SkipOnInsert = true, SkipOnUpdate = true)] public DateTime? Assigneddate { get; set; } // timestamp (6) without time zone
    }
}
