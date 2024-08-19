
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("departmentnotifychannels")]
    public partial class Departmentnotifychannel : IEquatable<Departmentnotifychannel>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("departmentid", DataType = DataType.Guid, DbType = "uuid")] public Guid Departmentid { get; set; } // uuid
        [Column("notifychannelid", DataType = DataType.Guid, DbType = "uuid")] public Guid Notifychannelid { get; set; } // uuid
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Departmentnotifychannel> _equalityComparer = ComparerBuilder.GetEqualityComparer<Departmentnotifychannel>(c => c.Id);

        public bool Equals(Departmentnotifychannel? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Departmentnotifychannel);
        }
        #endregion
    }
}
