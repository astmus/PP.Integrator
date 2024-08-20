
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("signatureusers")]
    public partial class Signatureuser : IEquatable<Signatureuser>
    {
        [Column("userid"   , DataType = DataType.Guid    , DbType = "uuid"                   , IsPrimaryKey = true)] public Guid    Userid    { get; set; } // uuid
        [Column("signature", DataType = DataType.NVarChar, DbType = "character varying(1000)", Length       = 1000)] public string? Signature { get; set; } // character varying(1000)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Signatureuser> _equalityComparer = ComparerBuilder.GetEqualityComparer<Signatureuser>(c => c.Userid);

        public bool Equals(Signatureuser? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Signatureuser);
        }
        #endregion
    }
}
