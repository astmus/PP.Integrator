
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("console_eventhistory")]
    public partial class ConsoleEventhistory : IEquatable<ConsoleEventhistory>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("eventtypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid Eventtypeid { get; set; } // uuid
        [Column("eventresulttypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Eventresulttypeid { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("sessionid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Sessionid { get; set; } // character varying(64)
        [Column("conversationid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Conversationid { get; set; } // character varying(64)
        [Column("abonentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Abonentid { get; set; } // uuid
        [Column("textmessage", DataType = DataType.Text, DbType = "text")] public string? Textmessage { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleEventhistory> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleEventhistory>(c => c.Id);

        public bool Equals(ConsoleEventhistory? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleEventhistory);
        }
        #endregion
    }
}
