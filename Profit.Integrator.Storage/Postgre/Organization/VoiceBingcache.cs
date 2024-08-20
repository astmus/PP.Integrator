
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_bingcache")]
    public partial class VoiceBingcache : IEquatable<VoiceBingcache>
    {
        [Column("id"              , DataType  = DataType.Int32  , DbType   = "integer"      , IsPrimaryKey = true   , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int    Id               { get; set; } // integer
        [Column("texttospeech"    , CanBeNull = false           , DataType = DataType.Text  , DbType       = "text"                                                              )] public string Texttospeech     { get; set; } = null!; // text
        [Column("data"            , CanBeNull = false           , DataType = DataType.Binary, DbType       = "bytea"                                                             )] public byte[] Data             { get; set; } = null!; // bytea
        [Column("texttospeechhash", DataType  = DataType.Int32  , DbType   = "integer"                                                                                           )] public int    Texttospeechhash { get; set; } // integer
        [Column("isdeleted"       , DataType  = DataType.Boolean, DbType   = "boolean"                                                                                           )] public bool   Isdeleted        { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceBingcache> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceBingcache>(c => c.Id);

        public bool Equals(VoiceBingcache? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceBingcache);
        }
        #endregion
    }
}
