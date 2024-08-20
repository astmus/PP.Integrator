
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_documents")]
    public partial class VoiceDocument : IEquatable<VoiceDocument>
    {
        [Column("id"            , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id             { get; set; } // uuid
        [Column("title"         , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Title          { get; set; } // character varying(255)
        [Column("documentdate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Documentdate   { get; set; } // timestamp (6) without time zone
        [Column("opertype"      , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Opertype       { get; set; } // character varying(50)
        [Column("documenttype"  , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Documenttype   { get; set; } // character varying(50)
        [Column("employeeid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Employeeid     { get; set; } // uuid
        [Column("locationid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Locationid     { get; set; } // uuid
        [Column("starttime"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Starttime      { get; set; } // timestamp (6) without time zone
        [Column("endtime"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Endtime        { get; set; } // timestamp (6) without time zone
        [Column("nextdocumentid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Nextdocumentid { get; set; } // uuid
        [Column("basedocumentid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Basedocumentid { get; set; } // uuid
        [Column("extendedfields", DataType = DataType.Text     , DbType = "text"                                                )] public string?   Extendedfields { get; set; } // text
        [Column("status"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Status         { get; set; } // integer
        [Column("completed"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Completed      { get; set; } // boolean
        [Column("createddate"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate    { get; set; } // timestamp (6) without time zone
        [Column("updateddate"   , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate    { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isdeleted      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceDocument> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceDocument>(c => c.Id);

        public bool Equals(VoiceDocument? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceDocument);
        }
        #endregion
    }
}
