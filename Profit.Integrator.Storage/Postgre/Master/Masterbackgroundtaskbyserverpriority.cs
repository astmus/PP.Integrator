
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("masterbackgroundtaskbyserverpriorities")]
    public partial class Masterbackgroundtaskbyserverpriority : IEquatable<Masterbackgroundtaskbyserverpriority>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("server", DataType = DataType.Guid, DbType = "uuid")] public Guid Server { get; set; } // uuid
        [Column("masterbackgroundtask", DataType = DataType.Guid, DbType = "uuid")] public Guid Masterbackgroundtask { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Masterbackgroundtaskbyserverpriority> _equalityComparer = ComparerBuilder.GetEqualityComparer<Masterbackgroundtaskbyserverpriority>(c => c.Id);

        public bool Equals(Masterbackgroundtaskbyserverpriority? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Masterbackgroundtaskbyserverpriority);
        }
        #endregion
    }
}
