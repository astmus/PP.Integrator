
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("guiincidentattributesondynamicscontainers")]
    public partial class Guiincidentattributesondynamicscontainer : IEquatable<Guiincidentattributesondynamicscontainer>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("container", DataType = DataType.Guid, DbType = "uuid")] public Guid Container { get; set; } // uuid
        [Column("attribute", DataType = DataType.Guid, DbType = "uuid")] public Guid Attribute { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string Title { get; set; } = null!; // character varying(1024)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("isrequired", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isrequired { get; set; } // boolean
        [Column("isreadonly", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isreadonly { get; set; } // boolean
        [Column("defaultvalue", DataType = DataType.Text, DbType = "text")] public string? Defaultvalue { get; set; } // text
        [Column("cntrorder", DataType = DataType.Int32, DbType = "integer")] public int? Cntrorder { get; set; } // integer
        [Column("cntrproperties", DataType = DataType.Text, DbType = "text")] public string? Cntrproperties { get; set; } // text
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone
        [Column("ismulti", DataType = DataType.Boolean, DbType = "boolean")] public bool? Ismulti { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentattributesondynamicscontainer> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentattributesondynamicscontainer>(c => c.Id);

        public bool Equals(Guiincidentattributesondynamicscontainer? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentattributesondynamicscontainer);
        }
        #endregion
    }
}
