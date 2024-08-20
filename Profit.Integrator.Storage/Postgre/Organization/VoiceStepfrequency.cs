
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_stepfrequencies")]
    public partial class VoiceStepfrequency : IEquatable<VoiceStepfrequency>
    {
        [Column("stepid"   , DataType = DataType.Guid , DbType = "uuid"   , IsPrimaryKey = true)] public Guid Stepid    { get; set; } // uuid
        [Column("frequency", DataType = DataType.Int32, DbType = "integer"                     )] public int? Frequency { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceStepfrequency> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceStepfrequency>(c => c.Stepid);

        public bool Equals(VoiceStepfrequency? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceStepfrequency);
        }
        #endregion
    }
}
