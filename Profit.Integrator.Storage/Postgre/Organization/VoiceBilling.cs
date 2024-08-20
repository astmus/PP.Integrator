
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_billing")]
    public partial class VoiceBilling : IEquatable<VoiceBilling>
    {
        [Column("id"          , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id           { get; set; } // uuid
        [Column("createddate" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate  { get; set; } // timestamp (6) without time zone
        [Column("eventtype"   , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Eventtype    { get; set; } // character varying(50)
        [Column("sttstarttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Sttstarttime { get; set; } // timestamp (6) without time zone
        [Column("sttendtime"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Sttendtime   { get; set; } // timestamp (6) without time zone
        [Column("ttsunits"    , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Ttsunits     { get; set; } // integer
        [Column("callid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Callid       { get; set; } // uuid
        [Column("stepid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Stepid       { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceBilling> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceBilling>(c => c.Id);

        public bool Equals(VoiceBilling? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceBilling);
        }
        #endregion
    }
}
