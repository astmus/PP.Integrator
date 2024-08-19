
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("cc_statecall")]
    public partial class CcStatecall : IEquatable<CcStatecall>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("state_code", DataType = DataType.Int16, DbType = "smallint")] public short StateCode { get; set; } // smallint
        [Column("state", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string State { get; set; } = null!; // character varying(20)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CcStatecall> _equalityComparer = ComparerBuilder.GetEqualityComparer<CcStatecall>(c => c.Id);

        public bool Equals(CcStatecall? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CcStatecall);
        }
        #endregion
    }
}
