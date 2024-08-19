
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcenter_outgoingruleabonents")]
    public partial class CallcenterOutgoingruleabonent : IEquatable<CallcenterOutgoingruleabonent>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("outgoingruleid", DataType = DataType.Guid, DbType = "uuid")] public Guid Outgoingruleid { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Userid { get; set; } // uuid
        [Column("userexternalid", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Userexternalid { get; set; } // character varying(128)
        [Column("username", DataType = DataType.Text, DbType = "text")] public string? Username { get; set; } // text
        [Column("userphone", DataType = DataType.NVarChar, DbType = "character varying(32)", Length = 32)] public string? Userphone { get; set; } // character varying(32)
        [Column("userproperties", DataType = DataType.Text, DbType = "text")] public string? Userproperties { get; set; } // text
        [Column("texttospeech", DataType = DataType.Text, DbType = "text")] public string? Texttospeech { get; set; } // text
        [Column("extendedfields", DataType = DataType.BinaryJson, DbType = "jsonb")] public string? Extendedfields { get; set; } // jsonb
        [Column("currentstatus", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Currentstatus { get; set; } = null!; // character varying(256)
        [Column("lastcalltime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastcalltime { get; set; } // timestamp (6) without time zone
        [Column("callcount", DataType = DataType.Int32, DbType = "integer")] public int Callcount { get; set; } // integer
        [Column("lastsuccesscompletetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastsuccesscompletetime { get; set; } // timestamp (6) without time zone
        [Column("successcallcount", DataType = DataType.Int32, DbType = "integer")] public int Successcallcount { get; set; } // integer
        [Column("smscount", DataType = DataType.Int32, DbType = "integer")] public int? Smscount { get; set; } // integer
        [Column("position", DataType = DataType.Int32, DbType = "integer")] public int? Position { get; set; } // integer
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CallcenterOutgoingruleabonent> _equalityComparer = ComparerBuilder.GetEqualityComparer<CallcenterOutgoingruleabonent>(c => c.Id);

        public bool Equals(CallcenterOutgoingruleabonent? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CallcenterOutgoingruleabonent);
        }
        #endregion
    }
}
