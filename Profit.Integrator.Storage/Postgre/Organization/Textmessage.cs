
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("textmessages")]
    public partial class Textmessage : IEquatable<Textmessage>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("messagetext", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Messagetext { get; set; } // character varying(4000)
        [Column("messagetype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string Messagetype { get; set; } = null!; // character varying(64)
        [Column("contextbefore", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Contextbefore { get; set; } // character varying(4000)
        [Column("contextafter", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Contextafter { get; set; } // character varying(4000)
        [Column("userproperties", DataType = DataType.Text, DbType = "text")] public string? Userproperties { get; set; } // text
        [Column("messageresponse", DataType = DataType.Text, DbType = "text")] public string? Messageresponse { get; set; } // text
        [Column("serverid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Serverid { get; set; } // uuid
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Textmessage> _equalityComparer = ComparerBuilder.GetEqualityComparer<Textmessage>(c => c.Id);

        public bool Equals(Textmessage? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Textmessage);
        }
        #endregion
    }
}
