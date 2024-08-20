
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("hr_stagingemploymentitems")]
    public partial class HrStagingemploymentitem : IEquatable<HrStagingemploymentitem>
    {
        [Column("id"                 , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                  { get; set; } // uuid
        [Column("stagingemploymentid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Stagingemploymentid { get; set; } // uuid
        [Column("voicescriptid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Voicescriptid       { get; set; } // uuid
        [Column("workcalendarid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Workcalendarid      { get; set; } // uuid
        [Column("duration"           , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Duration            { get; set; } // integer
        [Column("outgoingruleid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Outgoingruleid      { get; set; } // uuid
        [Column("position"           , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Position            { get; set; } // integer
        [Column("properties"         , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Properties          { get; set; } // text
        [Column("createdbyuserid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid     { get; set; } // uuid
        [Column("createddate"        , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate         { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid     { get; set; } // uuid
        [Column("updateddate"        , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate         { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"          , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted           { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<HrStagingemploymentitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<HrStagingemploymentitem>(c => c.Id);

        public bool Equals(HrStagingemploymentitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HrStagingemploymentitem);
        }
        #endregion
    }
}
