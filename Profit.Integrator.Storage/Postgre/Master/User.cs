
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("users")]
    public partial class User : IEquatable<User>
    {
        [Column("id"               , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id                { get; set; } // uuid
        [Column("sid"              , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Sid               { get; set; } = null!; // character varying(256)
        [Column("sip"              , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Sip               { get; set; } // character varying(256)
        [Column("login"            , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Login             { get; set; } // character varying(256)
        [Column("name"             , DataType  = DataType.NVarChar , DbType   = "character varying(512)"         , Length       = 512                                   )] public string?   Name              { get; set; } // character varying(512)
        [Column("entity"           , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Entity            { get; set; } // uuid
        [Column("isactive"         , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Isactive          { get; set; } // boolean
        [Column("notupdate"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Notupdate         { get; set; } // boolean
        [Column("createdate"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Createdate        { get; set; } // timestamp (6) without time zone
        [Column("externalid"       , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Externalid        { get; set; } // character varying(256)
        [Column("updateddate"      , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate       { get; set; } // timestamp (6) without time zone
        [Column("keycloakrealmname", DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Keycloakrealmname { get; set; } // character varying(50)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<User> _equalityComparer = ComparerBuilder.GetEqualityComparer<User>(c => c.Id);

        public bool Equals(User? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as User);
        }
        #endregion
    }
}
