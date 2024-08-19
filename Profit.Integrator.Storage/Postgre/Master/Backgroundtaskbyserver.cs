
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("backgroundtaskbyservers")]
    public partial class Backgroundtaskbyserver : IEquatable<Backgroundtaskbyserver>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("server", DataType = DataType.Guid, DbType = "uuid")] public Guid Server { get; set; } // uuid
        [Column("backgroundtask", DataType = DataType.Guid, DbType = "uuid")] public Guid Backgroundtask { get; set; } // uuid
        [Column("isactive", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isactive { get; set; } // boolean
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Backgroundtaskbyserver> _equalityComparer = ComparerBuilder.GetEqualityComparer<Backgroundtaskbyserver>(c => c.Id);

        public bool Equals(Backgroundtaskbyserver? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Backgroundtaskbyserver);
        }
        #endregion
    }
}
