
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_externalresources")]
    public partial class ViExternalresource : IEquatable<ViExternalresource>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("resourcetype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Resourcetype { get; set; } = null!; // character varying(50)
        [Column("resourceuri", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Resourceuri { get; set; } = null!; // character varying(50)
        [Column("isactive", DataType = DataType.Boolean, DbType = "boolean")] public bool Isactive { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViExternalresource> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViExternalresource>(c => c.Id);

        public bool Equals(ViExternalresource? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViExternalresource);
        }
        #endregion
    }
}
