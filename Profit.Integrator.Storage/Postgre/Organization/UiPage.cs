
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
        [Table("ui_pages")]
        public partial class UiPage : IEquatable<UiPage>
        {
            [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
            [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
            [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
            [Column("uri", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Uri { get; set; } // character varying(1024)
            [Column("ico", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Ico { get; set; } // character varying(1024)
            [Column("method", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Method { get; set; } // character varying(128)
            [Column("params", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Params { get; set; } // character varying(1024)
            [Column("lictype", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Lictype { get; set; } // character varying(64)
            [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

            #region IEquatable<T> support
            private static readonly IEqualityComparer<UiPage> _equalityComparer = ComparerBuilder.GetEqualityComparer<UiPage>(c => c.Id);

            public bool Equals(UiPage? other)
            {
                return _equalityComparer.Equals(this, other!);
            }

            public override int GetHashCode()
            {
                return _equalityComparer.GetHashCode(this);
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as UiPage);
            }
            #endregion
        }
    }
}