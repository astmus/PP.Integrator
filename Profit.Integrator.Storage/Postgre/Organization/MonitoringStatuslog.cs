
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("monitoring_statuslog")]
    public partial class MonitoringStatuslog : IEquatable<MonitoringStatuslog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("deviceid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Deviceid { get; set; } // uuid
        [Column("paramid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Paramid { get; set; } // uuid
        [Column("paramvalue", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Paramvalue { get; set; } // character varying(256)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<MonitoringStatuslog> _equalityComparer = ComparerBuilder.GetEqualityComparer<MonitoringStatuslog>(c => c.Id);

        public bool Equals(MonitoringStatuslog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MonitoringStatuslog);
        }
        #endregion
    }
}
