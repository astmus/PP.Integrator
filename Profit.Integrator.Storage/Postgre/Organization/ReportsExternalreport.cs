
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("reports_externalreports")]
    public partial class ReportsExternalreport : IEquatable<ReportsExternalreport>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("foldertitle", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Foldertitle { get; set; } // character varying(512)
        [Column("reporturl", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string Reporturl { get; set; } = null!; // character varying(1024)
        [Column("reporttitle", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Reporttitle { get; set; } = null!; // character varying(512)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ReportsExternalreport> _equalityComparer = ComparerBuilder.GetEqualityComparer<ReportsExternalreport>(c => c.Id);

        public bool Equals(ReportsExternalreport? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ReportsExternalreport);
        }
        #endregion
    }
}
