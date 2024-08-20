
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_interviewquestions")]
    public partial class VoiceInterviewquestion : IEquatable<VoiceInterviewquestion>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id          { get; set; } // uuid
        [Column("number"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int       Number      { get; set; } // integer
        [Column("title"      , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string    Title       { get; set; } = null!; // character varying(512)
        [Column("displayname", DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Displayname { get; set; } // character varying(255)
        [Column("interviewid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Interviewid { get; set; } // uuid
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceInterviewquestion> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceInterviewquestion>(c => c.Id);

        public bool Equals(VoiceInterviewquestion? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceInterviewquestion);
        }
        #endregion
    }
}
