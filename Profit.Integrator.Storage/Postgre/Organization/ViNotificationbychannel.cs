
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_notificationbychannels")]
    public partial class ViNotificationbychannel : IEquatable<ViNotificationbychannel>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("notificationid", DataType = DataType.Guid, DbType = "uuid")] public Guid Notificationid { get; set; } // uuid
        [Column("channelid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Channelid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViNotificationbychannel> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViNotificationbychannel>(c => c.Id);

        public bool Equals(ViNotificationbychannel? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViNotificationbychannel);
        }
        #endregion
    }
}
