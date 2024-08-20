
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidentattributes")]
    public partial class Guiincidentattribute : IEquatable<Guiincidentattribute>
    {
        [Column("id"               , DataType  = DataType.Guid    , DbType   = "uuid"                  , IsPrimaryKey = true                                  )] public Guid    Id                { get; set; } // uuid
        [Column("attrsrc"          , CanBeNull = false            , DataType = DataType.NVarChar       , DbType       = "character varying(16)" , Length = 16 )] public string  Attrsrc           { get; set; } = null!; // character varying(16)
        [Column("attrname"         , CanBeNull = false            , DataType = DataType.NVarChar       , DbType       = "character varying(256)", Length = 256)] public string  Attrname          { get; set; } = null!; // character varying(256)
        [Column("attrtitle"        , DataType  = DataType.NVarChar, DbType   = "character varying(256)", Length       = 256                                   )] public string? Attrtitle         { get; set; } // character varying(256)
        [Column("attrdescription"  , DataType  = DataType.Text    , DbType   = "text"                                                                         )] public string? Attrdescription   { get; set; } // text
        [Column("attrtype"         , CanBeNull = false            , DataType = DataType.NVarChar       , DbType       = "character varying(256)", Length = 256)] public string  Attrtype          { get; set; } = null!; // character varying(256)
        [Column("attrisrequired"   , DataType  = DataType.Boolean , DbType   = "boolean"                                                                      )] public bool?   Attrisrequired    { get; set; } // boolean
        [Column("attrisreadonly"   , DataType  = DataType.Boolean , DbType   = "boolean"                                                                      )] public bool?   Attrisreadonly    { get; set; } // boolean
        [Column("attrdefaultvalue" , DataType  = DataType.Text    , DbType   = "text"                                                                         )] public string? Attrdefaultvalue  { get; set; } // text
        [Column("attrdefaultscript", DataType  = DataType.Text    , DbType   = "text"                                                                         )] public string? Attrdefaultscript { get; set; } // text
        [Column("cntrtype"         , CanBeNull = false            , DataType = DataType.NVarChar       , DbType       = "character varying(256)", Length = 256)] public string  Cntrtype          { get; set; } = null!; // character varying(256)
        [Column("cntrproperties"   , DataType  = DataType.Text    , DbType   = "text"                                                                         )] public string? Cntrproperties    { get; set; } // text
        [Column("isselected"       , DataType  = DataType.Boolean , DbType   = "boolean"                                                                      )] public bool?   Isselected        { get; set; } // boolean
        [Column("cntrorder"        , DataType  = DataType.Int32   , DbType   = "integer"                                                                      )] public int?    Cntrorder         { get; set; } // integer
        [Column("cntrattributes"   , DataType  = DataType.Text    , DbType   = "text"                                                                         )] public string? Cntrattributes    { get; set; } // text
        [Column("attrcanmulti"     , DataType  = DataType.Boolean , DbType   = "boolean"                                                                      )] public bool?   Attrcanmulti      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentattribute> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentattribute>(c => c.Id);

        public bool Equals(Guiincidentattribute? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentattribute);
        }
        #endregion
    }
}
