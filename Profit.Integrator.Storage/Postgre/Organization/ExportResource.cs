
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("export_resources")]
    public partial class ExportResource : IEquatable<ExportResource>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("resourcetype", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Resourcetype { get; set; } // character varying(128)
        [Column("storeprocedurename", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Storeprocedurename { get; set; } // character varying(256)
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ExportResource> _equalityComparer = ComparerBuilder.GetEqualityComparer<ExportResource>(c => c.Id);

        public bool Equals(ExportResource? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ExportResource);
        }
        #endregion
    }
}
