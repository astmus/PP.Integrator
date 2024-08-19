
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("accesskeys")]
    public partial class Accesskey : IEquatable<Accesskey>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("expireson", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Expireson { get; set; } // timestamp (6) without time zone
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Name { get; set; } = null!; // character varying(512)
        [Column("address", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Address { get; set; } // character varying(512)
        [Column("authtype", DataType = DataType.NVarChar, DbType = "character varying(10)", Length = 10)] public string? Authtype { get; set; } // character varying(10)
        [Column("template", DataType = DataType.NVarChar, DbType = "character varying(40)", Length = 40)] public string? Template { get; set; } // character varying(40)
        [Column("properties", DataType = DataType.Text, DbType = "text")] public string? Properties { get; set; } // text
        [Column("resourcetype", DataType = DataType.NVarChar, DbType = "character varying(10)", Length = 10)] public string? Resourcetype { get; set; } // character varying(10)
        [Column("entityid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Entityid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Accesskey> _equalityComparer = ComparerBuilder.GetEqualityComparer<Accesskey>(c => c.Id);

        public bool Equals(Accesskey? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Accesskey);
        }
        #endregion
    }
}
