
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcenter_outgoingrules")]
    public partial class CallcenterOutgoingrule : IEquatable<CallcenterOutgoingrule>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Name { get; set; } // character varying(1024)
        [Column("masterscriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Masterscriptid { get; set; } // uuid
        [Column("scriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid Scriptid { get; set; } // uuid
        [Column("workcalendarid", DataType = DataType.Guid, DbType = "uuid")] public Guid Workcalendarid { get; set; } // uuid
        [Column("withrecord", DataType = DataType.Boolean, DbType = "boolean")] public bool Withrecord { get; set; } // boolean
        [Column("simultaneouslycalling", DataType = DataType.Int32, DbType = "integer")] public int Simultaneouslycalling { get; set; } // integer
        [Column("maxcallscount", DataType = DataType.Int32, DbType = "integer")] public int? Maxcallscount { get; set; } // integer
        [Column("timebetweencalls", DataType = DataType.Int32, DbType = "integer")] public int? Timebetweencalls { get; set; } // integer
        [Column("outgoingline", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Outgoingline { get; set; } = null!; // character varying(256)
        [Column("virtuallineid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Virtuallineid { get; set; } // uuid
        [Column("startdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Startdate { get; set; } // timestamp (6) without time zone
        [Column("enddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Enddate { get; set; } // timestamp (6) without time zone
        [Column("isactual", DataType = DataType.Boolean, DbType = "boolean")] public bool Isactual { get; set; } // boolean
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(2048)", Length = 2048)] public string? Description { get; set; } // character varying(2048)
        [Column("texttospeech", DataType = DataType.Text, DbType = "text")] public string? Texttospeech { get; set; } // text
        [Column("currentstatus", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Currentstatus { get; set; } = null!; // character varying(256)
        [Column("extendedfields", DataType = DataType.BinaryJson, DbType = "jsonb")] public string? Extendedfields { get; set; } // jsonb
        [Column("activeserver", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Activeserver { get; set; } // character varying(50)
        [Column("lastactivitytime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastactivitytime { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("ruletype", DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string? Ruletype { get; set; } // character varying(20)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CallcenterOutgoingrule> _equalityComparer = ComparerBuilder.GetEqualityComparer<CallcenterOutgoingrule>(c => c.Id);

        public bool Equals(CallcenterOutgoingrule? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CallcenterOutgoingrule);
        }
        #endregion
    }
}
