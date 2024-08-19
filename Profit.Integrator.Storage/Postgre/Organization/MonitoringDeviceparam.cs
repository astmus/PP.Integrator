
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("monitoring_deviceparams")]
    public partial class MonitoringDeviceparam : IEquatable<MonitoringDeviceparam>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("typeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Typeid { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Name { get; set; } // character varying(512)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("externalid", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Externalid { get; set; } // character varying(128)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<MonitoringDeviceparam> _equalityComparer = ComparerBuilder.GetEqualityComparer<MonitoringDeviceparam>(c => c.Id);

        public bool Equals(MonitoringDeviceparam? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MonitoringDeviceparam);
        }
        #endregion
    }
}
