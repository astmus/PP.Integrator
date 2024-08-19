
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("servicedesk$smsintegration$notificationqueue")]
    public partial class ServicedeskSmsintegrationNotificationqueue : IEquatable<ServicedeskSmsintegrationNotificationqueue>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("incidentid", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Incidentid { get; set; } // character varying(256)
        [Column("message", CanBeNull = false, DataType = DataType.Text, DbType = "text")] public string Message { get; set; } = null!; // text
        [Column("phonenumber", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Phonenumber { get; set; } = null!; // character varying(256)
        [Column("timeadded", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Timeadded { get; set; } // timestamp (6) without time zone
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Userid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ServicedeskSmsintegrationNotificationqueue> _equalityComparer = ComparerBuilder.GetEqualityComparer<ServicedeskSmsintegrationNotificationqueue>(c => c.Id);

        public bool Equals(ServicedeskSmsintegrationNotificationqueue? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ServicedeskSmsintegrationNotificationqueue);
        }
        #endregion
    }
}
