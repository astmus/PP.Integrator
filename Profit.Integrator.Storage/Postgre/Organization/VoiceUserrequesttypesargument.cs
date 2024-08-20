
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_userrequesttypesarguments")]
    public partial class VoiceUserrequesttypesargument : IEquatable<VoiceUserrequesttypesargument>
    {
        [Column("id"               , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                { get; set; } // uuid
        [Column("userrequesttypeid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Userrequesttypeid { get; set; } // uuid
        [Column("title"            , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Title             { get; set; } // character varying(1024)
        [Column("defaultvalue"     , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length       = 32  )] public string?   Defaultvalue      { get; set; } // character varying(32)
        [Column("description"      , DataType = DataType.NVarChar , DbType = "character varying(2048)"        , Length       = 2048)] public string?   Description       { get; set; } // character varying(2048)
        [Column("createdbyuserid"  , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid   { get; set; } // uuid
        [Column("createddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate       { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"  , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid   { get; set; } // uuid
        [Column("updateddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate       { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"        , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted         { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceUserrequesttypesargument> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceUserrequesttypesargument>(c => c.Id);

        public bool Equals(VoiceUserrequesttypesargument? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceUserrequesttypesargument);
        }
        #endregion
    }
}
