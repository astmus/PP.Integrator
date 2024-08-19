
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("timemanagement$schedule$officeroleassignment")]
    public partial class TimemanagementScheduleOfficeroleassignment : IEquatable<TimemanagementScheduleOfficeroleassignment>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("officeid", DataType = DataType.Guid, DbType = "uuid")] public Guid Officeid { get; set; } // uuid
        [Column("roleid", DataType = DataType.Guid, DbType = "uuid")] public Guid Roleid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<TimemanagementScheduleOfficeroleassignment> _equalityComparer = ComparerBuilder.GetEqualityComparer<TimemanagementScheduleOfficeroleassignment>(c => c.Id);

        public bool Equals(TimemanagementScheduleOfficeroleassignment? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TimemanagementScheduleOfficeroleassignment);
        }
        #endregion
    }
}
