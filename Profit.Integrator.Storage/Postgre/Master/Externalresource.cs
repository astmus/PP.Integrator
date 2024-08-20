
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("externalresources")]
    public partial class Externalresource : IEquatable<Externalresource>
    {
        [Column("id"                  , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid      Id                   { get; set; } // uuid
        [Column("resourcetype"        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(32)", Length = 32)] public string    Resourcetype         { get; set; } = null!; // character varying(32)
        [Column("name"                , DataType  = DataType.NVarChar , DbType   = "character varying(512)"         , Length       = 512                                 )] public string?   Name                 { get; set; } // character varying(512)
        [Column("address"             , DataType  = DataType.NVarChar , DbType   = "character varying(512)"         , Length       = 512                                 )] public string?   Address              { get; set; } // character varying(512)
        [Column("uriaddress"          , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                )] public string?   Uriaddress           { get; set; } // character varying(1024)
        [Column("websocketfulladdress", DataType  = DataType.NVarChar , DbType   = "character varying(512)"         , Length       = 512                                 )] public string?   Websocketfulladdress { get; set; } // character varying(512)
        [Column("isactive"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool?     Isactive             { get; set; } // boolean
        [Column("lastalivetime"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime? Lastalivetime        { get; set; } // timestamp (6) without time zone
        [Column("properties"          , DataType  = DataType.Text     , DbType   = "text"                                                                                )] public string?   Properties           { get; set; } // text
        [Column("trustedappid"        , DataType  = DataType.NVarChar , DbType   = "character varying(128)"         , Length       = 128                                 )] public string?   Trustedappid         { get; set; } // character varying(128)
        [Column("createdate"          , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime? Createdate           { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Externalresource> _equalityComparer = ComparerBuilder.GetEqualityComparer<Externalresource>(c => c.Id);

        public bool Equals(Externalresource? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Externalresource);
        }
        #endregion
    }
}
