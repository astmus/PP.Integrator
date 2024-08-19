
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("organizationscache")]
    public partial class Organizationscache : IEquatable<Organizationscache>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("entityid", DataType = DataType.Guid, DbType = "uuid")] public Guid Entityid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("usedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Usedate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Organizationscache> _equalityComparer = ComparerBuilder.GetEqualityComparer<Organizationscache>(c => c.Id);

        public bool Equals(Organizationscache? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Organizationscache);
        }
        #endregion
    }
}
