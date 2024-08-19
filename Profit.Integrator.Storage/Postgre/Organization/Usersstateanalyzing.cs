
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("usersstateanalyzing")]
    public partial class Usersstateanalyzing
    {
        [Column("user", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string User { get; set; } = null!; // character varying(50)
        [Column("dttm", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Dttm { get; set; } // timestamp (6) without time zone
        [Column("suspiciousness", DataType = DataType.Int16, DbType = "smallint")] public short Suspiciousness { get; set; } // smallint
    }
}
