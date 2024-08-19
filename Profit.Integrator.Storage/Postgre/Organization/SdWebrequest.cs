
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_webrequests")]
    public partial class SdWebrequest : IEquatable<SdWebrequest>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("clientaddress", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Clientaddress { get; set; } // character varying(1024)
        [Column("serveraddress", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Serveraddress { get; set; } // character varying(1024)
        [Column("useridentity", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Useridentity { get; set; } // character varying(1024)
        [Column("text", DataType = DataType.Text, DbType = "text")] public string? Text { get; set; } // text
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("isverified", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isverified { get; set; } // boolean
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWebrequest> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWebrequest>(c => c.Id);

        public bool Equals(SdWebrequest? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWebrequest);
        }
        #endregion
    }
}
