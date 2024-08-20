
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_checkpoints")]
    public partial class VoiceCheckpoint
    {
        [Column("id"          , DataType = DataType.Int64    , DbType = "bigint"                         , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public long      Id           { get; set; } // bigint
        [Column("callid"      , DataType = DataType.Guid     , DbType = "uuid"                                                                                        )] public Guid?     Callid       { get; set; } // uuid
        [Column("prevstepid"  , DataType = DataType.Guid     , DbType = "uuid"                                                                                        )] public Guid?     Prevstepid   { get; set; } // uuid
        [Column("stepid"      , DataType = DataType.Guid     , DbType = "uuid"                                                                                        )] public Guid?     Stepid       { get; set; } // uuid
        [Column("iteration"   , DataType = DataType.Int32    , DbType = "integer"                                                                                     )] public int?      Iteration    { get; set; } // integer
        [Column("comment"     , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length     = 255                                           )] public string?   Comment      { get; set; } // character varying(255)
        [Column("completetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                                                             )] public DateTime? Completetime { get; set; } // timestamp (6) without time zone
        [Column("intcallid"   , DataType = DataType.Int32    , DbType = "integer"                                                                                     )] public int?      Intcallid    { get; set; } // integer
        [Column("contextid"   , DataType = DataType.Guid     , DbType = "uuid"                                                                                        )] public Guid?     Contextid    { get; set; } // uuid
    }
}
