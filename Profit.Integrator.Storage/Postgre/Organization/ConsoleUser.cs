
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("console_users")]
    public partial class ConsoleUser : IEquatable<ConsoleUser>
    {
        [Column("id"           , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id            { get; set; } // uuid
        [Column("sip"          , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Sip           { get; set; } = null!; // character varying(256)
        [Column("displayname"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string    Displayname   { get; set; } = null!; // character varying(512)
        [Column("logindatetime", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Logindatetime { get; set; } // timestamp (6) without time zone
        [Column("createddate"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate   { get; set; } // timestamp (6) without time zone
        [Column("updateddate"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate   { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"    , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleUser> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleUser>(c => c.Id);

        public bool Equals(ConsoleUser? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleUser);
        }
        #endregion
    }
}
