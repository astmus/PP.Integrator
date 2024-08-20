
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("usercontacts")]
    public partial class Usercontact : IEquatable<Usercontact>
    {
        [Column("id"           , DataType  = DataType.Guid    , DbType   = "uuid"                  , IsPrimaryKey = true  )] public Guid    Id            { get; set; } // uuid
        [Column("userid"       , DataType  = DataType.Guid    , DbType   = "uuid"                                         )] public Guid    Userid        { get; set; } // uuid
        [Column("typeid"       , DataType  = DataType.Guid    , DbType   = "uuid"                                         )] public Guid    Typeid        { get; set; } // uuid
        [Column("contact"      , CanBeNull = false            , DataType = DataType.Text           , DbType       = "text")] public string  Contact       { get; set; } = null!; // text
        [Column("contacthandle", DataType  = DataType.NVarChar, DbType   = "character varying(128)", Length       = 128   )] public string? Contacthandle { get; set; } // character varying(128)
        [Column("source"       , DataType  = DataType.NVarChar, DbType   = "character varying(8)"  , Length       = 8     )] public string? Source        { get; set; } // character varying(8)
        [Column("isdeleted"    , DataType  = DataType.Boolean , DbType   = "boolean"                                      )] public bool    Isdeleted     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Usercontact> _equalityComparer = ComparerBuilder.GetEqualityComparer<Usercontact>(c => c.Id);

        public bool Equals(Usercontact? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Usercontact);
        }
        #endregion
    }
}
