
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("activitylogtypes")]
    public partial class Activitylogtype : IEquatable<Activitylogtype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(300)", Length = 300)] public string? Name { get; set; } // character varying(300)
        [Column("methodname", DataType = DataType.NVarChar, DbType = "character varying(300)", Length = 300)] public string? Methodname { get; set; } // character varying(300)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Activitylogtype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Activitylogtype>(c => c.Id);

        public bool Equals(Activitylogtype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Activitylogtype);
        }
        #endregion
    }
}
