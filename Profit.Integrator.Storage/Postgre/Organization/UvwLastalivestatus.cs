
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("uvw_lastalivestatus", IsView = true)]
    public partial class UvwLastalivestatus
    {
        [Column("incidentid", DataType = DataType.Guid, DbType = "uuid", SkipOnInsert = true, SkipOnUpdate = true)] public Guid? Incidentid { get; set; } // uuid
        [Column("incidentnumber", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256, SkipOnInsert = true, SkipOnUpdate = true)] public string? Incidentnumber { get; set; } // character varying(256)
        [Column("laststatusid", DataType = DataType.Guid, DbType = "uuid", SkipOnInsert = true, SkipOnUpdate = true)] public Guid? Laststatusid { get; set; } // uuid
        [Column("laststatusassigneddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone", SkipOnInsert = true, SkipOnUpdate = true)] public DateTime? Laststatusassigneddate { get; set; } // timestamp (6) without time zone
        [Column("lastalivestatusid", DataType = DataType.Guid, DbType = "uuid", SkipOnInsert = true, SkipOnUpdate = true)] public Guid? Lastalivestatusid { get; set; } // uuid
        [Column("lastalivestatusassigneddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone", SkipOnInsert = true, SkipOnUpdate = true)] public DateTime? Lastalivestatusassigneddate { get; set; } // timestamp (6) without time zone
    }
}
