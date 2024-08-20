
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    public partial class OrganizationDataBase : DataConnection
    {
        [Table("cleartablessettings")]
        public partial class Cleartablessetting : IEquatable<Cleartablessetting>
        {
            [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
            [Column("tablename", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Tablename { get; set; } = null!; // character varying(512)
            [Column("expirydays", DataType = DataType.Int32, DbType = "integer")] public int? Expirydays { get; set; } // integer
            [Column("restrows", DataType = DataType.Int32, DbType = "integer")] public int? Restrows { get; set; } // integer
            [Column("datecolumnname", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Datecolumnname { get; set; } // character varying(128)
            [Column("isdateutc", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdateutc { get; set; } // boolean
            [Column("isenabled", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isenabled { get; set; } // boolean
            [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
            [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

            #region IEquatable<T> support
            private static readonly IEqualityComparer<Cleartablessetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<Cleartablessetting>(c => c.Id);

            public bool Equals(Cleartablessetting? other)
            {
                return _equalityComparer.Equals(this, other!);
            }

            public override int GetHashCode()
            {
                return _equalityComparer.GetHashCode(this);
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as Cleartablessetting);
            }
            #endregion
        }
    }
}