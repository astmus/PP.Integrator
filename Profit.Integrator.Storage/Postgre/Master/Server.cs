
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("servers")]
    public partial class Server : IEquatable<Server>
    {
        [Column("id"                          , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id                           { get; set; } // uuid
        [Column("name"                        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string    Name                         { get; set; } = null!; // character varying(512)
        [Column("ipaddress"                   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(64)" , Length = 64 )] public string    Ipaddress                    { get; set; } = null!; // character varying(64)
        [Column("pitversion"                  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(16)" , Length = 16 )] public string    Pitversion                   { get; set; } = null!; // character varying(16)
        [Column("webserverport"               , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(16)" , Length = 16 )] public string    Webserverport                { get; set; } = null!; // character varying(16)
        [Column("webserverscheme"             , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8                                     )] public string?   Webserverscheme              { get; set; } // character varying(8)
        [Column("webserverfulladdress"        , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Webserverfulladdress         { get; set; } // character varying(256)
        [Column("webserverfullinternaladdress", DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Webserverfullinternaladdress { get; set; } // character varying(256)
        [Column("websocketfulladdress"        , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Websocketfulladdress         { get; set; } // character varying(256)
        [Column("websocketfullinternaladdress", DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Websocketfullinternaladdress { get; set; } // character varying(256)
        [Column("webserverhttpport"           , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8                                     )] public string?   Webserverhttpport            { get; set; } // character varying(8)
        [Column("webserverhttpaddress"        , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Webserverhttpaddress         { get; set; } // character varying(256)
        [Column("isenabled"                   , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Isenabled                    { get; set; } // boolean
        [Column("isactive"                    , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Isactive                     { get; set; } // boolean
        [Column("lastalivetime"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Lastalivetime                { get; set; } // timestamp (6) without time zone
        [Column("laststarttime"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Laststarttime                { get; set; } // timestamp (6) without time zone
        [Column("priority"                    , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Priority                     { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Server> _equalityComparer = ComparerBuilder.GetEqualityComparer<Server>(c => c.Id);

        public bool Equals(Server? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Server);
        }
        #endregion
    }
}
