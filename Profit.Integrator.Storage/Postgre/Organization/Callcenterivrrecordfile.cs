
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcenterivrrecordfiles")]
    public partial class Callcenterivrrecordfile : IEquatable<Callcenterivrrecordfile>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Name { get; set; } // character varying(1024)
        [Column("content", DataType = DataType.Binary, DbType = "bytea")] public byte[]? Content { get; set; } // bytea
        [Column("ivrmenuonopen", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ivrmenuonopen { get; set; } // uuid
        [Column("ivrmenuonwaiting", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ivrmenuonwaiting { get; set; } // uuid
        [Column("ivrmenuitemoninfo", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ivrmenuitemoninfo { get; set; } // uuid
        [Column("ivrmenuitemonselect", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ivrmenuitemonselect { get; set; } // uuid
        [Column("positionnumber", DataType = DataType.Int32, DbType = "integer")] public int? Positionnumber { get; set; } // integer
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone
        [Column("isactive", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isactive { get; set; } // boolean
        [Column("waitingtype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Waitingtype { get; set; } // character varying(50)
        [Column("itemtype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Itemtype { get; set; } // character varying(50)
        [Column("interval", DataType = DataType.Int32, DbType = "integer")] public int? Interval { get; set; } // integer
        [Column("ivrmenuonwaitingoperator", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ivrmenuonwaitingoperator { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcenterivrrecordfile> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcenterivrrecordfile>(c => c.Id);

        public bool Equals(Callcenterivrrecordfile? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcenterivrrecordfile);
        }
        #endregion
    }
}
