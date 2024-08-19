
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("reports_enabledcustomreports")]
    public partial class ReportsEnabledcustomreport : IEquatable<ReportsEnabledcustomreport>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("foldertitle", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Foldertitle { get; set; } // character varying(512)
        [Column("reporttemplate", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Reporttemplate { get; set; } = null!; // character varying(512)
        [Column("reporttitle", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Reporttitle { get; set; } = null!; // character varying(512)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ReportsEnabledcustomreport> _equalityComparer = ComparerBuilder.GetEqualityComparer<ReportsEnabledcustomreport>(c => c.Id);

        public bool Equals(ReportsEnabledcustomreport? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ReportsEnabledcustomreport);
        }
        #endregion
    }
}
