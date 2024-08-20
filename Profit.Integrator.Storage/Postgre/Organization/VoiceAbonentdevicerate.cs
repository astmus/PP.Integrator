
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_abonentdevicerates")]
    public partial class VoiceAbonentdevicerate : IEquatable<VoiceAbonentdevicerate>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id          { get; set; } // uuid
        [Column("deviceid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Deviceid    { get; set; } // uuid
        [Column("ratetypeid" , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Ratetypeid  { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAbonentdevicerate> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAbonentdevicerate>(c => c.Id);

        public bool Equals(VoiceAbonentdevicerate? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAbonentdevicerate);
        }
        #endregion
    }
}
