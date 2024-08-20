
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("notificationservice$distributiongroupsmembers")]
    public partial class NotificationserviceDistributiongroupsmember : IEquatable<NotificationserviceDistributiongroupsmember>
    {
        [Column("id"       , DataType  = DataType.Guid, DbType   = "uuid"           , IsPrimaryKey = true                                  )] public Guid   Id        { get; set; } // uuid
        [Column("groupid"  , DataType  = DataType.Guid, DbType   = "uuid"                                                                  )] public Guid   Groupid   { get; set; } // uuid
        [Column("memberuri", CanBeNull = false        , DataType = DataType.NVarChar, DbType       = "character varying(256)", Length = 256)] public string Memberuri { get; set; } = null!; // character varying(256)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<NotificationserviceDistributiongroupsmember> _equalityComparer = ComparerBuilder.GetEqualityComparer<NotificationserviceDistributiongroupsmember>(c => c.Id);

        public bool Equals(NotificationserviceDistributiongroupsmember? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as NotificationserviceDistributiongroupsmember);
        }
        #endregion
    }
}
