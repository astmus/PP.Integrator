
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_chatactivityattachments")]
    public partial class ViChatactivityattachment : IEquatable<ViChatactivityattachment>
    {
        [Column("id"           , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id            { get; set; } // uuid
        [Column("activityid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Activityid    { get; set; } // uuid
        [Column("name"         , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?  Name          { get; set; } // character varying(512)
        [Column("contenttype"  , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?  Contenttype   { get; set; } // character varying(128)
        [Column("contenturl"   , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?  Contenturl    { get; set; } // character varying(1024)
        [Column("contentpiturl", DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?  Contentpiturl { get; set; } // character varying(1024)
        [Column("contenttext"  , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Contenttext   { get; set; } // text
        [Column("createddate"  , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate   { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"    , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatactivityattachment> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatactivityattachment>(c => c.Id);

        public bool Equals(ViChatactivityattachment? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatactivityattachment);
        }
        #endregion
    }
}
