
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("console_userscontactspersons")]
    public partial class ConsoleUserscontactsperson : IEquatable<ConsoleUserscontactsperson>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("contactofuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Contactofuserid { get; set; } // uuid
        [Column("groupid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Groupid         { get; set; } // uuid
        [Column("sip"            , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Sip             { get; set; } = null!; // character varying(256)
        [Column("displayname"    , DataType  = DataType.NVarChar , DbType   = "character varying(445)"         , Length       = 445                                   )] public string?   Displayname     { get; set; } // character varying(445)
        [Column("status"         , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                    )] public string?   Status          { get; set; } // character varying(32)
        [Column("endpointtype"   , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32                                    )] public string?   Endpointtype    { get; set; } // character varying(32)
        [Column("avatarurl"      , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                  )] public string?   Avatarurl       { get; set; } // character varying(1024)
        [Column("persontype"     , DataType  = DataType.NVarChar , DbType   = "character varying(16)"          , Length       = 16                                    )] public string?   Persontype      { get; set; } // character varying(16)
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleUserscontactsperson> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleUserscontactsperson>(c => c.Id);

        public bool Equals(ConsoleUserscontactsperson? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleUserscontactsperson);
        }
        #endregion
    }
}
