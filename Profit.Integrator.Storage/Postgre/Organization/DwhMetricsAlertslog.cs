
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("dwh_metrics_alertslog")]
    public partial class DwhMetricsAlertslog : IEquatable<DwhMetricsAlertslog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("metricid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Metricid { get; set; } // uuid
        [Column("alerttype", DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string? Alerttype { get; set; } // character varying(32)
        [Column("alerttext", DataType = DataType.Text, DbType = "text")] public string? Alerttext { get; set; } // text
        [Column("alertproperties", DataType = DataType.Text, DbType = "text")] public string? Alertproperties { get; set; } // text
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DwhMetricsAlertslog> _equalityComparer = ComparerBuilder.GetEqualityComparer<DwhMetricsAlertslog>(c => c.Id);

        public bool Equals(DwhMetricsAlertslog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DwhMetricsAlertslog);
        }
        #endregion
    }
}
