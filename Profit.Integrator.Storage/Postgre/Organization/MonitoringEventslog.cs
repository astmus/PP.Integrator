
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("monitoring_eventslog")]
    public partial class MonitoringEventslog : IEquatable<MonitoringEventslog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("deviceid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Deviceid { get; set; } // uuid
        [Column("eventtype", DataType = DataType.Int32, DbType = "integer")] public int? Eventtype { get; set; } // integer
        [Column("eventsubtype", DataType = DataType.Int32, DbType = "integer")] public int? Eventsubtype { get; set; } // integer
        [Column("eventtext", DataType = DataType.Text, DbType = "text")] public string? Eventtext { get; set; } // text
        [Column("eventproperties", DataType = DataType.Text, DbType = "text")] public string? Eventproperties { get; set; } // text
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<MonitoringEventslog> _equalityComparer = ComparerBuilder.GetEqualityComparer<MonitoringEventslog>(c => c.Id);

        public bool Equals(MonitoringEventslog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MonitoringEventslog);
        }
        #endregion
    }
}
