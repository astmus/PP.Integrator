
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcenterincomelines")]
    public partial class Callcenterincomeline : IEquatable<Callcenterincomeline>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("targetarea", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Targetarea { get; set; } // character varying(256)
        [Column("isendpoint", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isendpoint { get; set; } // boolean
        [Column("sip", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Sip { get; set; } // character varying(256)
        [Column("telnumber", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Telnumber { get; set; } // character varying(256)
        [Column("ivrmenu", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ivrmenu { get; set; } // uuid
        [Column("scriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Scriptid { get; set; } // uuid
        [Column("poolsize", DataType = DataType.Int32, DbType = "integer")] public int? Poolsize { get; set; } // integer
        [Column("virtuallineid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Virtuallineid { get; set; } // uuid
        [Column("outboundgateway", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Outboundgateway { get; set; } // character varying(255)
        [Column("hostfqdn", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Hostfqdn { get; set; } // character varying(255)
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcenterincomeline> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcenterincomeline>(c => c.Id);

        public bool Equals(Callcenterincomeline? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcenterincomeline);
        }
        #endregion
    }
}
