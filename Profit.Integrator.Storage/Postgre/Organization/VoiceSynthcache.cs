
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_synthcache")]
    public partial class VoiceSynthcache : IEquatable<VoiceSynthcache>
    {
        [Column("id"              , DataType  = DataType.Int32    , DbType   = "integer"                        , IsPrimaryKey = true   , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int       Id               { get; set; } // integer
        [Column("cacheid"         , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                                                )] public Guid?     Cacheid          { get; set; } // uuid
        [Column("synthtype"       , DataType  = DataType.NVarChar , DbType   = "character varying(16)"          , Length       = 16                                                                  )] public string?   Synthtype        { get; set; } // character varying(16)
        [Column("texttospeech"    , CanBeNull = false             , DataType = DataType.Text                    , DbType       = "text"                                                              )] public string    Texttospeech     { get; set; } = null!; // text
        [Column("data"            , CanBeNull = false             , DataType = DataType.Binary                  , DbType       = "bytea"                                                             )] public byte[]    Data             { get; set; } = null!; // bytea
        [Column("texttospeechhash", DataType  = DataType.Int32    , DbType   = "integer"                                                                                                             )] public int       Texttospeechhash { get; set; } // integer
        [Column("options"         , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                                                )] public string?   Options          { get; set; } // character varying(1024)
        [Column("optionshash"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                                                             )] public int?      Optionshash      { get; set; } // integer
        [Column("fileformat"      , DataType  = DataType.NVarChar , DbType   = "character varying(5)"           , Length       = 5                                                                   )] public string?   Fileformat       { get; set; } // character varying(5)
        [Column("createddate"     , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                                                     )] public DateTime  Createddate      { get; set; } // timestamp (6) without time zone
        [Column("updateddate"     , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                                                     )] public DateTime? Updateddate      { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                                             )] public bool      Isdeleted        { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceSynthcache> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceSynthcache>(c => c.Id);

        public bool Equals(VoiceSynthcache? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceSynthcache);
        }
        #endregion
    }
}
