
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenter_operatorsinwork")]
    public partial class CallcenterOperatorsinwork : IEquatable<CallcenterOperatorsinwork>
    {
        [Column("id"              , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id               { get; set; } // uuid
        [Column("operatorid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Operatorid       { get; set; } // uuid
        [Column("logintime"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Logintime        { get; set; } // timestamp (6) without time zone
        [Column("logouttime"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Logouttime       { get; set; } // timestamp (6) without time zone
        [Column("lastactivitytime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Lastactivitytime { get; set; } // timestamp (6) without time zone
        [Column("onlinechatscount", DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Onlinechatscount { get; set; } // integer
        [Column("createddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate      { get; set; } // timestamp (6) without time zone
        [Column("updateddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate      { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"       , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted        { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CallcenterOperatorsinwork> _equalityComparer = ComparerBuilder.GetEqualityComparer<CallcenterOperatorsinwork>(c => c.Id);

        public bool Equals(CallcenterOperatorsinwork? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CallcenterOperatorsinwork);
        }
        #endregion
    }
}
