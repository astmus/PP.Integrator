
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_dialogs")]
    public partial class VoiceDialog : IEquatable<VoiceDialog>
    {
        [Column("id"                  , DataType  = DataType.Int64    , DbType   = "bigint"                         , IsPrimaryKey = true  , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public long      Id                   { get; set; } // bigint
        [Column("callid"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                                               )] public Guid      Callid               { get; set; } // uuid
        [Column("stepid"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                                               )] public Guid      Stepid               { get; set; } // uuid
        [Column("phrase"              , CanBeNull = false             , DataType = DataType.Text                    , DbType       = "text"                                                             )] public string    Phrase               { get; set; } = null!; // text
        [Column("isincoming"          , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                                            )] public bool      Isincoming           { get; set; } // boolean
        [Column("recognitionstarttime", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                                                    )] public DateTime? Recognitionstarttime { get; set; } // timestamp (6) without time zone
        [Column("createddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                                                    )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                                            )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceDialog> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceDialog>(c => c.Id);

        public bool Equals(VoiceDialog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceDialog);
        }
        #endregion
    }
}
