
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("viewedincidents")]
    public partial class Viewedincident
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("user", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string User { get; set; } = null!; // character varying(50)
        [Column("incident", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Incident { get; set; } = null!; // character varying(50)
        [Column("dateline", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Dateline { get; set; } // timestamp (6) without time zone
    }
}
