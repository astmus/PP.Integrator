
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitem_elapsedtime")]
    public partial class SdWorkitemElapsedtime : IEquatable<SdWorkitemElapsedtime>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id              { get; set; } // uuid
        [Column("workitemid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Workitemid      { get; set; } // uuid
        [Column("userid"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Userid          { get; set; } // uuid
        [Column("startworktime"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Startworktime   { get; set; } // timestamp (6) without time zone
        [Column("finishworktime" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Finishworktime  { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemElapsedtime> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemElapsedtime>(c => c.Id);

        public bool Equals(SdWorkitemElapsedtime? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemElapsedtime);
        }
        #endregion
    }
}
