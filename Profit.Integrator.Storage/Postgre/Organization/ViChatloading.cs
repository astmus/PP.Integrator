
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_chatloadings")]
    public partial class ViChatloading : IEquatable<ViChatloading>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("serverid", DataType = DataType.Guid, DbType = "uuid")] public Guid Serverid { get; set; } // uuid
        [Column("accountid", DataType = DataType.Guid, DbType = "uuid")] public Guid Accountid { get; set; } // uuid
        [Column("vacancyid", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string Vacancyid { get; set; } = null!; // character varying(20)
        [Column("topicid", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string Topicid { get; set; } = null!; // character varying(20)
        [Column("lastmessageid", DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string? Lastmessageid { get; set; } // character varying(20)
        [Column("lastmessagedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastmessagedate { get; set; } // timestamp (6) without time zone
        [Column("lastloaddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastloaddate { get; set; } // timestamp (6) without time zone
        [Column("loadedcount", DataType = DataType.Int32, DbType = "integer")] public int Loadedcount { get; set; } // integer
        [Column("sleepstart", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Sleepstart { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatloading> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatloading>(c => c.Id);

        public bool Equals(ViChatloading? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatloading);
        }
        #endregion
    }
}
