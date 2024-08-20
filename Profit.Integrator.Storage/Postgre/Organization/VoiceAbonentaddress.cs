
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_abonentaddresses")]
    public partial class VoiceAbonentaddress : IEquatable<VoiceAbonentaddress>
    {
        [Column("id"              , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id               { get; set; } // uuid
        [Column("abonentid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Abonentid        { get; set; } // uuid
        [Column("title"           , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?   Title            { get; set; } // character varying(512)
        [Column("region"          , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Region           { get; set; } // character varying(255)
        [Column("district"        , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   District         { get; set; } // character varying(255)
        [Column("locality"        , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Locality         { get; set; } // character varying(255)
        [Column("localitydistrict", DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Localitydistrict { get; set; } // character varying(255)
        [Column("street"          , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Street           { get; set; } // character varying(255)
        [Column("house"           , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   House            { get; set; } // character varying(50)
        [Column("corp"            , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Corp             { get; set; } // character varying(50)
        [Column("building"        , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Building         { get; set; } // character varying(50)
        [Column("flat"            , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Flat             { get; set; } // character varying(50)
        [Column("createddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate      { get; set; } // timestamp (6) without time zone
        [Column("updateddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate      { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"       , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted        { get; set; } // boolean
        [Column("fiascode"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Fiascode         { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAbonentaddress> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAbonentaddress>(c => c.Id);

        public bool Equals(VoiceAbonentaddress? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAbonentaddress);
        }
        #endregion
    }
}
