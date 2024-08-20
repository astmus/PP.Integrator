
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_interviewuseranswers")]
    public partial class VoiceInterviewuseranswer : IEquatable<VoiceInterviewuseranswer>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id          { get; set; } // uuid
        [Column("questionid" , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Questionid  { get; set; } // uuid
        [Column("answer"     , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?  Answer      { get; set; } // character varying(255)
        [Column("callid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Callid      { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceInterviewuseranswer> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceInterviewuseranswer>(c => c.Id);

        public bool Equals(VoiceInterviewuseranswer? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceInterviewuseranswer);
        }
        #endregion
    }
}
