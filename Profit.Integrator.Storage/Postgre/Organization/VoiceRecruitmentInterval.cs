
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_recruitment_intervals")]
    public partial class VoiceRecruitmentInterval : IEquatable<VoiceRecruitmentInterval>
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                 { get; set; } // uuid
        [Column("outgoingruleid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Outgoingruleid     { get; set; } // uuid
        [Column("vacancyname"       , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Vacancyname        { get; set; } // character varying(255)
        [Column("intervaltype"      , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Intervaltype       { get; set; } // character varying(50)
        [Column("starttime"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Starttime          { get; set; } // timestamp (6) without time zone
        [Column("endtime"           , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Endtime            { get; set; } // timestamp (6) without time zone
        [Column("outgoingruleitemid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Outgoingruleitemid { get; set; } // uuid
        [Column("status"            , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?   Status             { get; set; } // character varying(50)
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updateddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted          { get; set; } // boolean
        [Column("createdbyuserid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Createdbyuserid    { get; set; } // uuid
        [Column("userid"            , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Userid             { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceRecruitmentInterval> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceRecruitmentInterval>(c => c.Id);

        public bool Equals(VoiceRecruitmentInterval? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceRecruitmentInterval);
        }
        #endregion
    }
}
