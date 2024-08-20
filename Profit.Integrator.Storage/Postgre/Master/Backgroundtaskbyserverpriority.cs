
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("backgroundtaskbyserverpriorities")]
    public partial class Backgroundtaskbyserverpriority : IEquatable<Backgroundtaskbyserverpriority>
    {
        [Column("id"            , DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id             { get; set; } // uuid
        [Column("server"        , DataType = DataType.Guid, DbType = "uuid"                     )] public Guid Server         { get; set; } // uuid
        [Column("backgroundtask", DataType = DataType.Guid, DbType = "uuid"                     )] public Guid Backgroundtask { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Backgroundtaskbyserverpriority> _equalityComparer = ComparerBuilder.GetEqualityComparer<Backgroundtaskbyserverpriority>(c => c.Id);

        public bool Equals(Backgroundtaskbyserverpriority? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Backgroundtaskbyserverpriority);
        }
        #endregion
    }
}
