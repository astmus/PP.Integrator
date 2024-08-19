
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("monitoring_devicestypes")]
    public partial class MonitoringDevicestype : IEquatable<MonitoringDevicestype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Name { get; set; } // character varying(512)
        [Column("cod", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Cod { get; set; } // character varying(128)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<MonitoringDevicestype> _equalityComparer = ComparerBuilder.GetEqualityComparer<MonitoringDevicestype>(c => c.Id);

        public bool Equals(MonitoringDevicestype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MonitoringDevicestype);
        }
        #endregion
    }
}
