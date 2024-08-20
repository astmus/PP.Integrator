
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_chatplatforms")]
    public partial class ViChatplatform : IEquatable<ViChatplatform>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid     Id          { get; set; } // uuid
        [Column("name"       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(128)", Length = 128)] public string   Name        { get; set; } = null!; // character varying(128)
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatplatform> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatplatform>(c => c.Id);

        public bool Equals(ViChatplatform? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatplatform);
        }
        #endregion
    }
}
