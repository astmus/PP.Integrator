
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("crossentityroles")]
    public partial class Crossentityrole : IEquatable<Crossentityrole>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Crossentityrole> _equalityComparer = ComparerBuilder.GetEqualityComparer<Crossentityrole>(c => c.Id);

        public bool Equals(Crossentityrole? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Crossentityrole);
        }
        #endregion
    }
}
