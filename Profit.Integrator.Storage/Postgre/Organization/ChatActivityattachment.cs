
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("chat_activityattachments")]
    public partial class ChatActivityattachment : IEquatable<ChatActivityattachment>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("activityid", DataType = DataType.Guid, DbType = "uuid")] public Guid Activityid { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Name { get; set; } // character varying(512)
        [Column("contenttype", DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string? Contenttype { get; set; } // character varying(32)
        [Column("contenturl", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Contenturl { get; set; } // character varying(1024)
        [Column("contentpiturl", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Contentpiturl { get; set; } // character varying(1024)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ChatActivityattachment> _equalityComparer = ComparerBuilder.GetEqualityComparer<ChatActivityattachment>(c => c.Id);

        public bool Equals(ChatActivityattachment? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ChatActivityattachment);
        }
        #endregion
    }
}
