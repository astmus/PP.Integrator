
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_recognizedphrases")]
    public partial class VoiceRecognizedphrase : IEquatable<VoiceRecognizedphrase>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid     Id          { get; set; } // uuid
        [Column("name"       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string   Name        { get; set; } = null!; // character varying(255)
        [Column("confidence" , DataType  = DataType.Double   , DbType   = "double precision"                                                                      )] public double?  Confidence  { get; set; } // double precision
        [Column("stepid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid     Stepid      { get; set; } // uuid
        [Column("callid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid     Callid      { get; set; } // uuid
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceRecognizedphrase> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceRecognizedphrase>(c => c.Id);

        public bool Equals(VoiceRecognizedphrase? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceRecognizedphrase);
        }
        #endregion
    }
}
