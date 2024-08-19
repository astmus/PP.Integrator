
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("blobtempstorage")]
    public partial class Blobtempstorage : IEquatable<Blobtempstorage>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("content", DataType = DataType.Binary, DbType = "bytea")] public byte[]? Content { get; set; } // bytea
        [Column("filepath", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Filepath { get; set; } // character varying(1024)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Blobtempstorage> _equalityComparer = ComparerBuilder.GetEqualityComparer<Blobtempstorage>(c => c.Id);

        public bool Equals(Blobtempstorage? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Blobtempstorage);
        }
        #endregion
    }
}
