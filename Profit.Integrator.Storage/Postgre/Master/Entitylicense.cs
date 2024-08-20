
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("entitylicenses")]
    public partial class Entitylicense : IEquatable<Entitylicense>
    {
        [Column("id"         , DataType = DataType.Guid    , DbType = "uuid"                 , IsPrimaryKey = true)] public Guid    Id          { get; set; } // uuid
        [Column("entityid"   , DataType = DataType.Guid    , DbType = "uuid"                                      )] public Guid    Entityid    { get; set; } // uuid
        [Column("licenseid"  , DataType = DataType.Guid    , DbType = "uuid"                                      )] public Guid    Licenseid   { get; set; } // uuid
        [Column("licensecode", DataType = DataType.NVarChar, DbType = "character varying(64)", Length       = 64  )] public string? Licensecode { get; set; } // character varying(64)
        [Column("count"      , DataType = DataType.Int32   , DbType = "integer"                                   )] public int     Count       { get; set; } // integer
        [Column("isdeleted"  , DataType = DataType.Boolean , DbType = "boolean"                                   )] public bool    Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Entitylicense> _equalityComparer = ComparerBuilder.GetEqualityComparer<Entitylicense>(c => c.Id);

        public bool Equals(Entitylicense? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entitylicense);
        }
        #endregion
    }
}
