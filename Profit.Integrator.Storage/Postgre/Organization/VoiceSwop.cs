
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_swop")]
    public partial class VoiceSwop : IEquatable<VoiceSwop>
    {
        [Column("id"           , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id            { get; set; } // uuid
        [Column("itemid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Itemid        { get; set; } // uuid
        [Column("swopobjectid" , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Swopobjectid  { get; set; } // uuid
        [Column("swopmessageid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Swopmessageid { get; set; } // uuid
        [Column("status"       , DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Status        { get; set; } // integer
        [Column("createddate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate   { get; set; } // timestamp (6) without time zone
        [Column("updateddate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate   { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"    , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceSwop> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceSwop>(c => c.Id);

        public bool Equals(VoiceSwop? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceSwop);
        }
        #endregion
    }
}
