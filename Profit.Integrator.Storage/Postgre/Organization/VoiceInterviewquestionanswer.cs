
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_interviewquestionanswers")]
    public partial class VoiceInterviewquestionanswer : IEquatable<VoiceInterviewquestionanswer>
    {
        [Column("id"          , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id           { get; set; } // uuid
        [Column("questionid"  , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Questionid   { get; set; } // uuid
        [Column("number"      , DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Number       { get; set; } // integer
        [Column("texttorec"   , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Texttorec    { get; set; } // character varying(255)
        [Column("texttospeech", DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Texttospeech { get; set; } // character varying(255)
        [Column("texttoanswer", DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Texttoanswer { get; set; } // character varying(255)
        [Column("createddate" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate  { get; set; } // timestamp (6) without time zone
        [Column("updateddate" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate  { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"   , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted    { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceInterviewquestionanswer> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceInterviewquestionanswer>(c => c.Id);

        public bool Equals(VoiceInterviewquestionanswer? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceInterviewquestionanswer);
        }
        #endregion
    }
}
