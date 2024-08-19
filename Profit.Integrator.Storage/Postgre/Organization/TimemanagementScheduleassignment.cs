
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("timemanagement$scheduleassignment")]
    public partial class TimemanagementScheduleassignment : IEquatable<TimemanagementScheduleassignment>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("officeid", DataType = DataType.Guid, DbType = "uuid")] public Guid Officeid { get; set; } // uuid
        [Column("userid", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Userid { get; set; } = null!; // character varying(256)
        [Column("roleid", DataType = DataType.Guid, DbType = "uuid")] public Guid Roleid { get; set; } // uuid
        [Column("scheduleid", DataType = DataType.Guid, DbType = "uuid")] public Guid Scheduleid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<TimemanagementScheduleassignment> _equalityComparer = ComparerBuilder.GetEqualityComparer<TimemanagementScheduleassignment>(c => c.Id);

        public bool Equals(TimemanagementScheduleassignment? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TimemanagementScheduleassignment);
        }
        #endregion
    }
}
