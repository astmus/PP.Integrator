
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_workitem_incidents")]
    public partial class SdWorkitemIncident : IEquatable<SdWorkitemIncident>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("number", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Number { get; set; } = null!; // character varying(256)
        [Column("title", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Title { get; set; } // character varying(512)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("resolutiondescription", DataType = DataType.Text, DbType = "text")] public string? Resolutiondescription { get; set; } // text
        [Column("contactmethod", DataType = DataType.Text, DbType = "text")] public string? Contactmethod { get; set; } // text
        [Column("firstassigneddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Firstassigneddate { get; set; } // timestamp (6) without time zone
        [Column("firstresponsedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Firstresponsedate { get; set; } // timestamp (6) without time zone
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createddate { get; set; } // timestamp (6) without time zone
        [Column("resolveddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Resolveddate { get; set; } // timestamp (6) without time zone
        [Column("closeddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Closeddate { get; set; } // timestamp (6) without time zone
        [Column("targetresolutiontime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Targetresolutiontime { get; set; } // timestamp (6) without time zone
        [Column("scheduledstartdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Scheduledstartdate { get; set; } // timestamp (6) without time zone
        [Column("actualstartdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Actualstartdate { get; set; } // timestamp (6) without time zone
        [Column("scheduledenddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Scheduledenddate { get; set; } // timestamp (6) without time zone
        [Column("actualenddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Actualenddate { get; set; } // timestamp (6) without time zone
        [Column("plannedwork", DataType = DataType.Double, DbType = "double precision")] public double? Plannedwork { get; set; } // double precision
        [Column("actualwork", DataType = DataType.Double, DbType = "double precision")] public double? Actualwork { get; set; } // double precision
        [Column("priority", DataType = DataType.Int32, DbType = "integer")] public int? Priority { get; set; } // integer
        [Column("impactid", DataType = DataType.Guid, DbType = "uuid")] public Guid Impactid { get; set; } // uuid
        [Column("urgencyid", DataType = DataType.Guid, DbType = "uuid")] public Guid Urgencyid { get; set; } // uuid
        [Column("statusid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Statusid { get; set; } // uuid
        [Column("sourceid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Sourceid { get; set; } // uuid
        [Column("resolutioncategoryid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Resolutioncategoryid { get; set; } // uuid
        [Column("tierqueueid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Tierqueueid { get; set; } // uuid
        [Column("classificationid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Classificationid { get; set; } // uuid
        [Column("companyid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Companyid { get; set; } // uuid
        [Column("affecteduserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Affecteduserid { get; set; } // uuid
        [Column("assignedtouserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Assignedtouserid { get; set; } // uuid
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Createdbyuserid { get; set; } // uuid
        [Column("closedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Closedbyuserid { get; set; } // uuid
        [Column("resolvedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Resolvedbyuserid { get; set; } // uuid
        [Column("primaryownerid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Primaryownerid { get; set; } // uuid
        [Column("parentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentid { get; set; } // uuid
        [Column("rating", DataType = DataType.Double, DbType = "double precision")] public double? Rating { get; set; } // double precision
        [Column("ratingcomments", DataType = DataType.Text, DbType = "text")] public string? Ratingcomments { get; set; } // text
        [Column("needsknowledgearticle", DataType = DataType.Boolean, DbType = "boolean")] public bool? Needsknowledgearticle { get; set; } // boolean
        [Column("escalated", DataType = DataType.Boolean, DbType = "boolean")] public bool? Escalated { get; set; } // boolean
        [Column("externalid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Externalid { get; set; } // character varying(64)
        [Column("source", DataType = DataType.NVarChar, DbType = "character varying(8)", Length = 8)] public string? Source { get; set; } // character varying(8)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("lastsourceid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Lastsourceid { get; set; } // uuid
        [Column("contextid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Contextid { get; set; } // uuid
        [Column("accountnumber", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Accountnumber { get; set; } // character varying(256)
        [Column("comment", DataType = DataType.Text, DbType = "text")] public string? Comment { get; set; } // text

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemIncident> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemIncident>(c => c.Id);

        public bool Equals(SdWorkitemIncident? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemIncident);
        }
        #endregion
    }
}
