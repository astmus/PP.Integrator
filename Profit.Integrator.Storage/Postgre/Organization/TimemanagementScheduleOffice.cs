
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("timemanagement$schedule$office")]
    public partial class TimemanagementScheduleOffice : IEquatable<TimemanagementScheduleOffice>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("city", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string City { get; set; } = null!; // character varying(256)
        [Column("address", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Address { get; set; } // character varying(256)
        [Column("managerid", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Managerid { get; set; } = null!; // character varying(256)
        [Column("timezoneid", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Timezoneid { get; set; } = null!; // character varying(256)
        [Column("timezonebias", DataType = DataType.Int32, DbType = "integer")] public int Timezonebias { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<TimemanagementScheduleOffice> _equalityComparer = ComparerBuilder.GetEqualityComparer<TimemanagementScheduleOffice>(c => c.Id);

        public bool Equals(TimemanagementScheduleOffice? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TimemanagementScheduleOffice);
        }
        #endregion
    }
}
