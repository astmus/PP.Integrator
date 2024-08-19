
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("departmentincidentassignedusers")]
    public partial class Departmentincidentassigneduser : IEquatable<Departmentincidentassigneduser>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("departmentid", DataType = DataType.Guid, DbType = "uuid")] public Guid Departmentid { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("incidentcategoryid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Incidentcategoryid { get; set; } // uuid
        [Column("usehardimplementer", DataType = DataType.Boolean, DbType = "boolean")] public bool? Usehardimplementer { get; set; } // boolean
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Departmentincidentassigneduser> _equalityComparer = ComparerBuilder.GetEqualityComparer<Departmentincidentassigneduser>(c => c.Id);

        public bool Equals(Departmentincidentassigneduser? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Departmentincidentassigneduser);
        }
        #endregion
    }
}
