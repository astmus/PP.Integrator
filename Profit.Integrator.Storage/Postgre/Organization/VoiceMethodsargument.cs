
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_methodsarguments")]
    public partial class VoiceMethodsargument : IEquatable<VoiceMethodsargument>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("methodid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Methodid        { get; set; } // uuid
        [Column("title"          , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Title           { get; set; } // character varying(1024)
        [Column("properties"     , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Properties      { get; set; } // character varying(1024)
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceMethodsargument> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceMethodsargument>(c => c.Id);

        public bool Equals(VoiceMethodsargument? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceMethodsargument);
        }
        #endregion
    }
}
