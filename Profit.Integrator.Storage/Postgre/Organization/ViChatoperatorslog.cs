
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_chatoperatorslogs")]
    public partial class ViChatoperatorslog : IEquatable<ViChatoperatorslog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("logtype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string Logtype { get; set; } = null!; // character varying(32)
        [Column("value", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Value { get; set; } // character varying(256)
        [Column("extravalue", DataType = DataType.Text, DbType = "text")] public string? Extravalue { get; set; } // text
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatoperatorslog> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatoperatorslog>(c => c.Id);

        public bool Equals(ViChatoperatorslog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatoperatorslog);
        }
        #endregion
    }
}
