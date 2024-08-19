
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("hr_employmentcandidatesonstagingitems")]
    public partial class HrEmploymentcandidatesonstagingitem : IEquatable<HrEmploymentcandidatesonstagingitem>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("candidateid", DataType = DataType.Guid, DbType = "uuid")] public Guid Candidateid { get; set; } // uuid
        [Column("stagingitemid", DataType = DataType.Guid, DbType = "uuid")] public Guid Stagingitemid { get; set; } // uuid
        [Column("outgoingruleabonentid", DataType = DataType.Guid, DbType = "uuid")] public Guid Outgoingruleabonentid { get; set; } // uuid
        [Column("hruserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Hruserid { get; set; } // uuid
        [Column("timeslotfrom", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Timeslotfrom { get; set; } // timestamp (6) without time zone
        [Column("timeslotto", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Timeslotto { get; set; } // timestamp (6) without time zone
        [Column("stagingitemvoicepoint", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Stagingitemvoicepoint { get; set; } // character varying(512)
        [Column("stagingitemstatusid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Stagingitemstatusid { get; set; } // uuid
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<HrEmploymentcandidatesonstagingitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<HrEmploymentcandidatesonstagingitem>(c => c.Id);

        public bool Equals(HrEmploymentcandidatesonstagingitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HrEmploymentcandidatesonstagingitem);
        }
        #endregion
    }
}
