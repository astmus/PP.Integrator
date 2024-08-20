
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_replacements")]
    public partial class VoiceReplacement : IEquatable<VoiceReplacement>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("synthesizertype", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(50)" , Length = 50 )] public string    Synthesizertype { get; set; } = null!; // character varying(50)
        [Column("original"       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Original        { get; set; } = null!; // character varying(255)
        [Column("replacement"    , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Replacement     { get; set; } = null!; // character varying(255)
        [Column("iscasesensitive", DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Iscasesensitive { get; set; } // boolean
        [Column("isregex"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isregex         { get; set; } // boolean
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Createdbyuserid { get; set; } // uuid
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceReplacement> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceReplacement>(c => c.Id);

        public bool Equals(VoiceReplacement? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceReplacement);
        }
        #endregion
    }
}
