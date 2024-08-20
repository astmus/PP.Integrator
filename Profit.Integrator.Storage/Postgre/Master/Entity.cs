
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("entities")]
    public partial class Entity : IEquatable<Entity>
    {
        [Column("id"                  , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id                   { get; set; } // uuid
        [Column("sid"                 , DataType  = DataType.NVarChar , DbType   = "character varying(2)"           , Length       = 2                                       )] public string?   Sid                  { get; set; } // character varying(2)
        [Column("name"                , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)" , Length = 512 )] public string    Name                 { get; set; } = null!; // character varying(512)
        [Column("pitdbconnection"     , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1028)", Length = 1028)] public string    Pitdbconnection      { get; set; } = null!; // character varying(1028)
        [Column("ad_ou"               , DataType  = DataType.NVarChar , DbType   = "character varying(512)"         , Length       = 512                                     )] public string?   AdOu                 { get; set; } // character varying(512)
        [Column("allusers"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Allusers             { get; set; } // boolean
        [Column("trustedapplicationid", DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                     )] public string?   Trustedapplicationid { get; set; } // character varying(256)
        [Column("remotehosts"         , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Remotehosts          { get; set; } // text
        [Column("isactive"            , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Isactive             { get; set; } // boolean
        [Column("settings"            , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Settings             { get; set; } // text
        [Column("externallinesnumber" , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Externallinesnumber  { get; set; } // integer
        [Column("createddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Createddate          { get; set; } // timestamp (6) without time zone
        [Column("address"             , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Address              { get; set; } // text
        [Column("contract"            , DataType  = DataType.NVarChar , DbType   = "character varying(1028)"        , Length       = 1028                                    )] public string?   Contract             { get; set; } // character varying(1028)
        [Column("tarifficationscheme" , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                      )] public string?   Tarifficationscheme  { get; set; } // character varying(50)
        [Column("appversion"          , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                      )] public string?   Appversion           { get; set; } // character varying(50)
        [Column("databaseinfo"        , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Databaseinfo         { get; set; } // text

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Entity> _equalityComparer = ComparerBuilder.GetEqualityComparer<Entity>(c => c.Id);

        public bool Equals(Entity? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity);
        }
        #endregion
    }
}
