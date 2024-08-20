
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("dwh_cc_callstime")]
    public partial class DwhCcCallstime : IEquatable<DwhCcCallstime>
    {
        [Column("id"                 , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id                 { get; set; } // uuid
        [Column("callid"             , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Callid             { get; set; } // uuid
        [Column("callstart"          , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Callstart          { get; set; } // timestamp (6) without time zone
        [Column("call_seconds"       , DataType = DataType.Int32    , DbType = "integer"                                             )] public int      CallSeconds        { get; set; } // integer
        [Column("wait_seconds"       , DataType = DataType.Int32    , DbType = "integer"                                             )] public int      WaitSeconds        { get; set; } // integer
        [Column("ivr_seconds"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int      IvrSeconds         { get; set; } // integer
        [Column("voicescript_seconds", DataType = DataType.Int32    , DbType = "integer"                                             )] public int      VoicescriptSeconds { get; set; } // integer
        [Column("speak_seconds"      , DataType = DataType.Int32    , DbType = "integer"                                             )] public int      SpeakSeconds       { get; set; } // integer
        [Column("dwhcalcversion"     , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?     Dwhcalcversion     { get; set; } // integer
        [Column("createddate"        , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"          , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted          { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DwhCcCallstime> _equalityComparer = ComparerBuilder.GetEqualityComparer<DwhCcCallstime>(c => c.Id);

        public bool Equals(DwhCcCallstime? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DwhCcCallstime);
        }
        #endregion
    }
}
