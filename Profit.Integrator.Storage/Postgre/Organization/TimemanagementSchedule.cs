
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("timemanagement$schedule")]
    public partial class TimemanagementSchedule : IEquatable<TimemanagementSchedule>
    {
        [Column("id"   , DataType = DataType.Guid , DbType = "uuid"    , IsPrimaryKey = true)] public Guid   Id    { get; set; } // uuid
        [Column("month", DataType = DataType.Int16, DbType = "smallint"                     )] public short? Month { get; set; } // smallint

        #region IEquatable<T> support
        private static readonly IEqualityComparer<TimemanagementSchedule> _equalityComparer = ComparerBuilder.GetEqualityComparer<TimemanagementSchedule>(c => c.Id);

        public bool Equals(TimemanagementSchedule? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TimemanagementSchedule);
        }
        #endregion
    }
}
