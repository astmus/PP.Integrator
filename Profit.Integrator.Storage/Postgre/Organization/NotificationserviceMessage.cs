
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("notificationservice$messages")]
    public partial class NotificationserviceMessage : IEquatable<NotificationserviceMessage>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("subject", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Subject { get; set; } // character varying(256)
        [Column("body", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string Body { get; set; } = null!; // character varying(1024)
        [Column("authorid", DataType = DataType.Guid, DbType = "uuid")] public Guid Authorid { get; set; } // uuid
        [Column("timeadded", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Timeadded { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<NotificationserviceMessage> _equalityComparer = ComparerBuilder.GetEqualityComparer<NotificationserviceMessage>(c => c.Id);

        public bool Equals(NotificationserviceMessage? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as NotificationserviceMessage);
        }
        #endregion
    }
}
