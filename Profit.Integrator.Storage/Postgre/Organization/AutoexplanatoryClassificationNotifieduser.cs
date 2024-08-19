
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("autoexplanatory$classification$notifiedusers")]
    public partial class AutoexplanatoryClassificationNotifieduser : IEquatable<AutoexplanatoryClassificationNotifieduser>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("notify", DataType = DataType.Boolean, DbType = "boolean")] public bool Notify { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<AutoexplanatoryClassificationNotifieduser> _equalityComparer = ComparerBuilder.GetEqualityComparer<AutoexplanatoryClassificationNotifieduser>(c => c.Id);

        public bool Equals(AutoexplanatoryClassificationNotifieduser? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as AutoexplanatoryClassificationNotifieduser);
        }
        #endregion
    }
}
