
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("localizedtext")]
    public partial class Localizedtext : IEquatable<Localizedtext>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("ltstringid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Ltstringid { get; set; } // uuid
        [Column("ltstringname", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Ltstringname { get; set; } // character varying(1024)
        [Column("languagecod", DataType = DataType.NVarChar, DbType = "character varying(2)", Length = 2)] public string? Languagecod { get; set; } // character varying(2)
        [Column("ltvalue", DataType = DataType.Text, DbType = "text")] public string? Ltvalue { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Localizedtext> _equalityComparer = ComparerBuilder.GetEqualityComparer<Localizedtext>(c => c.Id);

        public bool Equals(Localizedtext? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Localizedtext);
        }
        #endregion
    }
}
