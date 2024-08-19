
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("workcalendardayranges")]
    public partial class Workcalendardayrange : IEquatable<Workcalendardayrange>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("workcalendarid", DataType = DataType.Guid, DbType = "uuid")] public Guid Workcalendarid { get; set; } // uuid
        [Column("dayofweek", DataType = DataType.Int32, DbType = "integer")] public int Dayofweek { get; set; } // integer
        [Column("starttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Starttime { get; set; } // timestamp (6) without time zone
        [Column("endtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Endtime { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Workcalendardayrange> _equalityComparer = ComparerBuilder.GetEqualityComparer<Workcalendardayrange>(c => c.Id);

        public bool Equals(Workcalendardayrange? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Workcalendardayrange);
        }
        #endregion
    }
}
