
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("relatedincidentandcall")]
    public partial class Relatedincidentandcall : IEquatable<Relatedincidentandcall>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("callid", DataType = DataType.Guid, DbType = "uuid")] public Guid Callid { get; set; } // uuid
        [Column("incident", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Incident { get; set; } = null!; // character varying(50)
        [Column("workitemid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Workitemid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Relatedincidentandcall> _equalityComparer = ComparerBuilder.GetEqualityComparer<Relatedincidentandcall>(c => c.Id);

        public bool Equals(Relatedincidentandcall? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Relatedincidentandcall);
        }
        #endregion
    }
}
