
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("appsmask")]
    public partial class Appsmask : IEquatable<Appsmask>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("mask", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Mask { get; set; } = null!; // character varying(512)
        [Column("type", DataType = DataType.Guid, DbType = "uuid")] public Guid Type { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Appsmask> _equalityComparer = ComparerBuilder.GetEqualityComparer<Appsmask>(c => c.Id);

        public bool Equals(Appsmask? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Appsmask);
        }
        #endregion
    }
}
