
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("constant")]
    public partial class Constant : IEquatable<Constant>
    {
        [Column("id"  , DataType  = DataType.Guid    , DbType   = "uuid"                  , IsPrimaryKey = true                                  )] public Guid    Id   { get; set; } // uuid
        [Column("name", CanBeNull = false            , DataType = DataType.NVarChar       , DbType       = "character varying(255)", Length = 255)] public string  Name { get; set; } = null!; // character varying(255)
        [Column("val" , CanBeNull = false            , DataType = DataType.Text           , DbType       = "text"                                )] public string  Val  { get; set; } = null!; // text
        [Column("usr" , DataType  = DataType.NVarChar, DbType   = "character varying(255)", Length       = 255                                   )] public string? Usr  { get; set; } // character varying(255)
        [Column("pc"  , DataType  = DataType.NVarChar, DbType   = "character varying(255)", Length       = 255                                   )] public string? Pc   { get; set; } // character varying(255)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Constant> _equalityComparer = ComparerBuilder.GetEqualityComparer<Constant>(c => c.Id);

        public bool Equals(Constant? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Constant);
        }
        #endregion
    }
}
