
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_grammaritems")]
    public partial class VoiceGrammaritem : IEquatable<VoiceGrammaritem>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("name"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Name            { get; set; } = null!; // character varying(255)
        [Column("texttorec"      , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Texttorec       { get; set; } = null!; // character varying(255)
        [Column("texttospeech"   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Texttospeech    { get; set; } = null!; // character varying(255)
        [Column("texttoanswer"   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Texttoanswer    { get; set; } = null!; // character varying(255)
        [Column("options"        , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Options         { get; set; } // character varying(50)
        [Column("grammarid"      , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Grammarid       { get; set; } // uuid
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceGrammaritem> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceGrammaritem>(c => c.Id);

        public bool Equals(VoiceGrammaritem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceGrammaritem);
        }
        #endregion
    }
}
