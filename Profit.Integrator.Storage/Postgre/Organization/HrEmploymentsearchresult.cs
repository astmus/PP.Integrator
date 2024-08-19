
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("hr_employmentsearchresults")]
    public partial class HrEmploymentsearchresult : IEquatable<HrEmploymentsearchresult>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("employmentid", DataType = DataType.Guid, DbType = "uuid")] public Guid Employmentid { get; set; } // uuid
        [Column("searchconditions", DataType = DataType.Text, DbType = "text")] public string? Searchconditions { get; set; } // text
        [Column("properties", DataType = DataType.Text, DbType = "text")] public string? Properties { get; set; } // text
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("currentstate", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Currentstate { get; set; } // character varying(16)
        [Column("ismanual", DataType = DataType.Boolean, DbType = "boolean")] public bool? Ismanual { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<HrEmploymentsearchresult> _equalityComparer = ComparerBuilder.GetEqualityComparer<HrEmploymentsearchresult>(c => c.Id);

        public bool Equals(HrEmploymentsearchresult? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HrEmploymentsearchresult);
        }
        #endregion
    }
}
