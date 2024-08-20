
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_scripts")]
    public partial class VoiceScript : IEquatable<VoiceScript>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("title"          , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Title           { get; set; } // character varying(1024)
        [Column("isvoicescript"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isvoicescript   { get; set; } // boolean
        [Column("scripttype"     , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Scripttype      { get; set; } // character varying(50)
        [Column("editorversion"  , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Editorversion   { get; set; } // integer
        [Column("version"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Version         { get; set; } // integer
        [Column("settings"       , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Settings        { get; set; } // text
        [Column("groupid"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Groupid         { get; set; } // uuid
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean
        [Column("tags"           , DataType = DataType.NVarChar , DbType = "character varying"                                   )] public string?   Tags            { get; set; } // character varying

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceScript> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceScript>(c => c.Id);

        public bool Equals(VoiceScript? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceScript);
        }
        #endregion
    }
}
