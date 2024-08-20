
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidentbuttons")]
    public partial class Guiincidentbutton : IEquatable<Guiincidentbutton>
    {
        [Column("id"              , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id               { get; set; } // uuid
        [Column("name"            , CanBeNull = false             , DataType = DataType.Text                    , DbType       = "text"                                  )] public string    Name             { get; set; } = null!; // text
        [Column("description"     , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Description      { get; set; } // text
        [Column("title"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Title            { get; set; } = null!; // character varying(1024)
        [Column("withsave"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Withsave         { get; set; } // boolean
        [Column("withclose"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Withclose        { get; set; } // boolean
        [Column("createdate"      , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Createdate       { get; set; } // timestamp (6) without time zone
        [Column("deletedate"      , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Deletedate       { get; set; } // timestamp (6) without time zone
        [Column("withlyncclose"   , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Withlyncclose    { get; set; } // boolean
        [Column("withcall"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Withcall         { get; set; } // boolean
        [Column("issystem"        , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Issystem         { get; set; } // boolean
        [Column("actionproperties", DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Actionproperties { get; set; } // text
        [Column("imagecontent"    , DataType  = DataType.Binary   , DbType   = "bytea"                                                                                   )] public byte[]?   Imagecontent     { get; set; } // bytea

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentbutton> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentbutton>(c => c.Id);

        public bool Equals(Guiincidentbutton? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentbutton);
        }
        #endregion
    }
}
