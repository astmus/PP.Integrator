
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("websocketlog")]
    public partial class Websocketlog : IEquatable<Websocketlog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("serverid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Serverid { get; set; } // uuid
        [Column("eventsource", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Eventsource { get; set; } // character varying(16)
        [Column("eventtype", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Eventtype { get; set; } // character varying(16)
        [Column("socketid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Socketid { get; set; } // uuid
        [Column("serverurl", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Serverurl { get; set; } // character varying(512)
        [Column("clientipaddress", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Clientipaddress { get; set; } // character varying(512)
        [Column("clientport", DataType = DataType.Int32, DbType = "integer")] public int? Clientport { get; set; } // integer
        [Column("messagetext", DataType = DataType.Text, DbType = "text")] public string? Messagetext { get; set; } // text
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Websocketlog> _equalityComparer = ComparerBuilder.GetEqualityComparer<Websocketlog>(c => c.Id);

        public bool Equals(Websocketlog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Websocketlog);
        }
        #endregion
    }
}
