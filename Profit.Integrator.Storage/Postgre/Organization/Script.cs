
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("scripts")]
    public partial class Script : IEquatable<Script>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Title { get; set; } // character varying(255)
        [Column("scripttype", DataType = DataType.NVarChar, DbType = "character varying(10)", Length = 10)] public string? Scripttype { get; set; } // character varying(10)
        [Column("categoryid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Categoryid { get; set; } // uuid
        [Column("statusid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Statusid { get; set; } // uuid
        [Column("inputrequired", DataType = DataType.Boolean, DbType = "boolean")] public bool? Inputrequired { get; set; } // boolean
        [Column("notcheckrequiredfields", DataType = DataType.Boolean, DbType = "boolean")] public bool? Notcheckrequiredfields { get; set; } // boolean
        [Column("isgroup", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isgroup { get; set; } // boolean
        [Column("created", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Created { get; set; } // timestamp (6) without time zone
        [Column("modified", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Modified { get; set; } // timestamp (6) without time zone
        [Column("author", DataType = DataType.Int32, DbType = "integer")] public int? Author { get; set; } // integer
        [Column("editor", DataType = DataType.Int32, DbType = "integer")] public int? Editor { get; set; } // integer
        [Column("deleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Deleted { get; set; } // boolean
        [Column("afterusercurrent", DataType = DataType.Boolean, DbType = "boolean")] public bool? Afterusercurrent { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Script> _equalityComparer = ComparerBuilder.GetEqualityComparer<Script>(c => c.Id);

        public bool Equals(Script? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Script);
        }
        #endregion
    }
}
