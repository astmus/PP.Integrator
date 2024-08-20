
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_objecttypes")]
    public partial class VoiceObjecttype : IEquatable<VoiceObjecttype>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("title"          , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Title           { get; set; } // character varying(255)
        [Column("internalname"   , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Internalname    { get; set; } // character varying(255)
        [Column("typename"       , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Typename        { get; set; } // character varying(255)
        [Column("xmlnodename"    , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Xmlnodename     { get; set; } // character varying(255)
        [Column("runtimetypename", DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Runtimetypename { get; set; } // character varying(255)
        [Column("tablename"      , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Tablename       { get; set; } // character varying(255)
        [Column("keyfields"      , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Keyfields       { get; set; } // character varying(255)
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceObjecttype> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceObjecttype>(c => c.Id);

        public bool Equals(VoiceObjecttype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceObjecttype);
        }
        #endregion
    }
}
