
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("appstype")]
    public partial class Appstype : IEquatable<Appstype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("apps", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Apps { get; set; } = null!; // character varying(512)
        [Column("type", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Type { get; set; } // character varying(512)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Appstype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Appstype>(c => c.Id);

        public bool Equals(Appstype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Appstype);
        }
        #endregion
    }
}
