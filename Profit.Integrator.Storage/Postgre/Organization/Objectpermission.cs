
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("objectpermissions")]
    public partial class Objectpermission : IEquatable<Objectpermission>
    {
        [Column("objectid", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true, PrimaryKeyOrder = 0)] public Guid Objectid { get; set; } // uuid
        [Column("objecttype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128, IsPrimaryKey = true, PrimaryKeyOrder = 1)] public string Objecttype { get; set; } = null!; // character varying(128)
        [Column("usergroupid", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true, PrimaryKeyOrder = 2)] public Guid Usergroupid { get; set; } // uuid
        [Column("canwrite", DataType = DataType.Boolean, DbType = "boolean")] public bool Canwrite { get; set; } // boolean
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Objectpermission> _equalityComparer = ComparerBuilder.GetEqualityComparer<Objectpermission>(c => c.Objectid, c => c.Objecttype, c => c.Usergroupid);

        public bool Equals(Objectpermission? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Objectpermission);
        }
        #endregion
    }
}
