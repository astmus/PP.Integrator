
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("timemanagement$schedule$workday")]
    public partial class TimemanagementScheduleWorkday : IEquatable<TimemanagementScheduleWorkday>
    {
        [Column("id"        , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id         { get; set; } // uuid
        [Column("scheduleid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Scheduleid { get; set; } // uuid
        [Column("week"      , DataType = DataType.Int16    , DbType = "smallint"                                            )] public short?   Week       { get; set; } // smallint
        [Column("dayofweek" , DataType = DataType.Int16    , DbType = "smallint"                                            )] public short?   Dayofweek  { get; set; } // smallint
        [Column("starttime" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Starttime  { get; set; } // timestamp (6) without time zone
        [Column("endtime"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Endtime    { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<TimemanagementScheduleWorkday> _equalityComparer = ComparerBuilder.GetEqualityComparer<TimemanagementScheduleWorkday>(c => c.Id);

        public bool Equals(TimemanagementScheduleWorkday? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TimemanagementScheduleWorkday);
        }
        #endregion
    }
}
