
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("logs_visitsobjectsbyuser")]
    public partial class LogsVisitsobjectsbyuser : IEquatable<LogsVisitsobjectsbyuser>
    {
        [Column("id"          , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id           { get; set; } // uuid
        [Column("userid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Userid       { get; set; } // uuid
        [Column("objecttypeid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Objecttypeid { get; set; } // uuid
        [Column("objectid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Objectid     { get; set; } // uuid
        [Column("visittime"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Visittime    { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"   , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted    { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<LogsVisitsobjectsbyuser> _equalityComparer = ComparerBuilder.GetEqualityComparer<LogsVisitsobjectsbyuser>(c => c.Id);

        public bool Equals(LogsVisitsobjectsbyuser? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as LogsVisitsobjectsbyuser);
        }
        #endregion
    }
}
