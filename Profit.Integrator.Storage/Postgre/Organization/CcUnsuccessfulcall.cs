
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("cc_unsuccessfulcalls")]
    public partial class CcUnsuccessfulcall : IEquatable<CcUnsuccessfulcall>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("phone", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100)] public string Phone { get; set; } = null!; // character varying(100)
        [Column("time_call", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? TimeCall { get; set; } // timestamp (6) without time zone
        [Column("count_attempt", DataType = DataType.Int16, DbType = "smallint")] public short CountAttempt { get; set; } // smallint
        [Column("filename1", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Filename1 { get; set; } // character varying(255)
        [Column("text1", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Text1 { get; set; } // character varying(4000)
        [Column("filename2", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Filename2 { get; set; } // character varying(255)
        [Column("text2", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Text2 { get; set; } // character varying(4000)
        [Column("priority", DataType = DataType.Int16, DbType = "smallint")] public short Priority { get; set; } // smallint

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CcUnsuccessfulcall> _equalityComparer = ComparerBuilder.GetEqualityComparer<CcUnsuccessfulcall>(c => c.Id);

        public bool Equals(CcUnsuccessfulcall? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CcUnsuccessfulcall);
        }
        #endregion
    }
}
