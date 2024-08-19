
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("languagecodes")]
    public partial class Languagecode : IEquatable<Languagecode>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("cod", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(2)", Length = 2)] public string Cod { get; set; } = null!; // character varying(2)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Languagecode> _equalityComparer = ComparerBuilder.GetEqualityComparer<Languagecode>(c => c.Id);

        public bool Equals(Languagecode? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Languagecode);
        }
        #endregion
    }
}
