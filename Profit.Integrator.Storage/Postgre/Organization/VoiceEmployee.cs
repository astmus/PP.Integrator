
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_employees")]
    public partial class VoiceEmployee : IEquatable<VoiceEmployee>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Title { get; set; } // character varying(255)
        [Column("code", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Code { get; set; } // character varying(50)
        [Column("firstname", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Firstname { get; set; } // character varying(255)
        [Column("lastname", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Lastname { get; set; } // character varying(255)
        [Column("speed", DataType = DataType.Int32, DbType = "integer")] public int? Speed { get; set; } // integer
        [Column("job", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Job { get; set; } // character varying(255)
        [Column("password", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Password { get; set; } // character varying(50)
        [Column("locationid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Locationid { get; set; } // uuid
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceEmployee> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceEmployee>(c => c.Id);

        public bool Equals(VoiceEmployee? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceEmployee);
        }
        #endregion
    }
}
