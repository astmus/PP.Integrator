
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    public partial class MasterDataBase : DataConnection
    {
        [Table("trustedapps")]
        public partial class Trustedapp : IEquatable<Trustedapp>
        {
            [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)]
            public Guid Id { get; set; } // uuid
            [Column("externalresourceid", DataType = DataType.Guid, DbType = "uuid")]
            public Guid Externalresourceid { get; set; } // uuid
            [Column("entityid", DataType = DataType.Guid, DbType = "uuid")]
            public Guid Entityid { get; set; } // uuid
            [Column("trustedappid", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)]
            public string Trustedappid { get; set; } = null!; // character varying(50)
            [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")]
            public bool Isdeleted { get; set; } // boolean

            #region IEquatable<T> support
            private static readonly IEqualityComparer<Trustedapp> _equalityComparer = ComparerBuilder.GetEqualityComparer<Trustedapp>(c => c.Id);

            public bool Equals(Trustedapp? other)
            {
                return _equalityComparer.Equals(this, other!);
            }

            public override int GetHashCode()
            {
                return _equalityComparer.GetHashCode(this);
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as Trustedapp);
            }
            #endregion
        }
    }
}