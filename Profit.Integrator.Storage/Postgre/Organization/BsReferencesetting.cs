
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("bs_referencesettings")]
    public partial class BsReferencesetting : IEquatable<BsReferencesetting>
    {
        [Column("id"             , DataType  = DataType.Guid    , DbType   = "uuid"             , IsPrimaryKey = true               )] public Guid    Id              { get; set; } // uuid
        [Column("referencetypeid", DataType  = DataType.Guid    , DbType   = "uuid"                                                 )] public Guid    Referencetypeid { get; set; } // uuid
        [Column("name"           , CanBeNull = false            , DataType = DataType.NVarChar  , DbType       = "character varying")] public string  Name            { get; set; } = null!; // character varying
        [Column("datatype"       , CanBeNull = false            , DataType = DataType.NVarChar  , DbType       = "character varying")] public string  Datatype        { get; set; } = null!; // character varying
        [Column("gridshown"      , DataType  = DataType.Boolean , DbType   = "boolean"                                              )] public bool    Gridshown       { get; set; } // boolean
        [Column("length"         , DataType  = DataType.Int32   , DbType   = "integer"                                              )] public int?    Length          { get; set; } // integer
        [Column("mask"           , DataType  = DataType.NVarChar, DbType   = "character varying"                                    )] public string? Mask            { get; set; } // character varying
        [Column("isdeleted"      , DataType  = DataType.Boolean , DbType   = "boolean"                                              )] public bool    Isdeleted       { get; set; } // boolean
        [Column("position"       , DataType  = DataType.Int32   , DbType   = "integer"                                              )] public int     Position        { get; set; } // integer
        [Column("fieldid"        , CanBeNull = false            , DataType = DataType.NVarChar  , DbType       = "character varying")] public string  Fieldid         { get; set; } = null!; // character varying

        #region IEquatable<T> support
        private static readonly IEqualityComparer<BsReferencesetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<BsReferencesetting>(c => c.Id);

        public bool Equals(BsReferencesetting? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BsReferencesetting);
        }
        #endregion
    }
}
