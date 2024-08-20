
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenter_outgoingruleoutgoinglines")]
    public partial class CallcenterOutgoingruleoutgoingline : IEquatable<CallcenterOutgoingruleoutgoingline>
    {
        [Column("id"            , DataType  = DataType.Guid   , DbType   = "uuid"           , IsPrimaryKey = true                                  )] public Guid   Id             { get; set; } // uuid
        [Column("outgoingruleid", DataType  = DataType.Guid   , DbType   = "uuid"                                                                  )] public Guid   Outgoingruleid { get; set; } // uuid
        [Column("line"          , CanBeNull = false           , DataType = DataType.NVarChar, DbType       = "character varying(256)", Length = 256)] public string Line           { get; set; } = null!; // character varying(256)
        [Column("isdeleted"     , DataType  = DataType.Boolean, DbType   = "boolean"                                                               )] public bool   Isdeleted      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CallcenterOutgoingruleoutgoingline> _equalityComparer = ComparerBuilder.GetEqualityComparer<CallcenterOutgoingruleoutgoingline>(c => c.Id);

        public bool Equals(CallcenterOutgoingruleoutgoingline? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CallcenterOutgoingruleoutgoingline);
        }
        #endregion
    }
}
