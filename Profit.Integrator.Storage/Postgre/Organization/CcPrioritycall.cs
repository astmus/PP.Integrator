
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("cc_prioritycall")]
    public partial class CcPrioritycall : IEquatable<CcPrioritycall>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("priority_code", DataType = DataType.Int16, DbType = "smallint")] public short PriorityCode { get; set; } // smallint
        [Column("priority", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string Priority { get; set; } = null!; // character varying(20)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CcPrioritycall> _equalityComparer = ComparerBuilder.GetEqualityComparer<CcPrioritycall>(c => c.Id);

        public bool Equals(CcPrioritycall? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CcPrioritycall);
        }
        #endregion
    }
}
