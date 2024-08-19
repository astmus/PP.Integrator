
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("chat_activities")]
    public partial class ChatActivity : IEquatable<ChatActivity>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("activityid", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Activityid { get; set; } // character varying(128)
        [Column("isincoming", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isincoming { get; set; } // boolean
        [Column("conversationid", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Conversationid { get; set; } // character varying(128)
        [Column("fromid", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Fromid { get; set; } // character varying(128)
        [Column("fromname", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Fromname { get; set; } // character varying(256)
        [Column("toid", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Toid { get; set; } // character varying(128)
        [Column("toname", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Toname { get; set; } // character varying(256)
        [Column("serviceurl", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Serviceurl { get; set; } // character varying(512)
        [Column("channelid", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Channelid { get; set; } // character varying(256)
        [Column("text", DataType = DataType.Text, DbType = "text")] public string? Text { get; set; } // text
        [Column("textformat", DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string? Textformat { get; set; } // character varying(32)
        [Column("type", DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string? Type { get; set; } // character varying(32)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ChatActivity> _equalityComparer = ComparerBuilder.GetEqualityComparer<ChatActivity>(c => c.Id);

        public bool Equals(ChatActivity? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ChatActivity);
        }
        #endregion
    }
}
