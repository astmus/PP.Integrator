
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_settings")]
    public partial class SdSetting : IEquatable<SdSetting>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("value", CanBeNull = false, DataType = DataType.Text, DbType = "text")] public string Value { get; set; } = null!; // text
        [Column("modifieduserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Modifieduserid { get; set; } // uuid
        [Column("modifieddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Modifieddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdSetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdSetting>(c => c.Id);

        public bool Equals(SdSetting? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdSetting);
        }
        #endregion
    }
}
