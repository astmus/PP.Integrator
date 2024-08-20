
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_productboxes")]
    public partial class VoiceProductbox : IEquatable<VoiceProductbox>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("title"          , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Title           { get; set; } = null!; // character varying(255)
        [Column("parentid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Parentid        { get; set; } // uuid
        [Column("parenttitle"    , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?   Parenttitle     { get; set; } // character varying(255)
        [Column("status"         , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Status          { get; set; } // integer
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Createdbyuserid { get; set; } // uuid
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceProductbox> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceProductbox>(c => c.Id);

        public bool Equals(VoiceProductbox? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceProductbox);
        }
        #endregion
    }
}
