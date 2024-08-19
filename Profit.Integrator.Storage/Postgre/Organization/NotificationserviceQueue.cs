
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("notificationservice$queue")]
    public partial class NotificationserviceQueue : IEquatable<NotificationserviceQueue>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("messageid", DataType = DataType.Guid, DbType = "uuid")] public Guid Messageid { get; set; } // uuid
        [Column("targeturi", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Targeturi { get; set; } = null!; // character varying(256)
        [Column("issent", DataType = DataType.Boolean, DbType = "boolean")] public bool Issent { get; set; } // boolean
        [Column("lastsendingdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastsendingdate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<NotificationserviceQueue> _equalityComparer = ComparerBuilder.GetEqualityComparer<NotificationserviceQueue>(c => c.Id);

        public bool Equals(NotificationserviceQueue? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as NotificationserviceQueue);
        }
        #endregion
    }
}
