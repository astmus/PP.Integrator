
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("clipboard_contents")]
    public partial class ClipboardContent : IEquatable<ClipboardContent>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid     Id              { get; set; } // uuid
        [Column("area"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(32)", Length = 32)] public string   Area            { get; set; } = null!; // character varying(32)
        [Column("content"        , DataType  = DataType.Text     , DbType   = "text"                                                                                )] public string?  Content         { get; set; } // text
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid     Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime Createddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool     Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ClipboardContent> _equalityComparer = ComparerBuilder.GetEqualityComparer<ClipboardContent>(c => c.Id);

        public bool Equals(ClipboardContent? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ClipboardContent);
        }
        #endregion
    }
}
