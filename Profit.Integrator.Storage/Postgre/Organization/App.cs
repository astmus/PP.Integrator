
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("apps")]
    public partial class App : IEquatable<App>
    {
        [Column("id"                , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid     Id                 { get; set; } // uuid
        [Column("apps"              , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string   Apps               { get; set; } = null!; // character varying(512)
        [Column("context"           , CanBeNull = false             , DataType = DataType.Text                    , DbType       = "text"                                )] public string   Context            { get; set; } = null!; // text
        [Column("productversion"    , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?  Productversion     { get; set; } // character varying(50)
        [Column("productcompanyname", DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                   )] public string?  Productcompanyname { get; set; } // character varying(255)
        [Column("dt1"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Dt1                { get; set; } // timestamp (6) without time zone
        [Column("dt2"               , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Dt2                { get; set; } // timestamp (6) without time zone
        [Column("ip"                , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(32)" , Length = 32 )] public string   Ip                 { get; set; } = null!; // character varying(32)
        [Column("user"              , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string   User               { get; set; } = null!; // character varying(255)
        [Column("pc"                , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string   Pc                 { get; set; } = null!; // character varying(255)
        [Column("crc"               , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string   Crc                { get; set; } = null!; // character varying(255)
        [Column("delta_min"         , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int      DeltaMin           { get; set; } // integer
        [Column("isremotesession"   , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?    Isremotesession    { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<App> _equalityComparer = ComparerBuilder.GetEqualityComparer<App>(c => c.Id);

        public bool Equals(App? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as App);
        }
        #endregion
    }
}
