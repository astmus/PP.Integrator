
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_settingsparametersvalues")]
    public partial class VoiceSettingsparametersvalue : IEquatable<VoiceSettingsparametersvalue>
    {
        [Column("id"         , DataType = DataType.Guid    , DbType = "uuid"                  , IsPrimaryKey = true)] public Guid    Id          { get; set; } // uuid
        [Column("parameterid", DataType = DataType.Guid    , DbType = "uuid"                                       )] public Guid    Parameterid { get; set; } // uuid
        [Column("title"      , DataType = DataType.NVarChar, DbType = "character varying(128)", Length       = 128 )] public string? Title       { get; set; } // character varying(128)
        [Column("value"      , DataType = DataType.NVarChar, DbType = "character varying(128)", Length       = 128 )] public string? Value       { get; set; } // character varying(128)
        [Column("isdeleted"  , DataType = DataType.Boolean , DbType = "boolean"                                    )] public bool    Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceSettingsparametersvalue> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceSettingsparametersvalue>(c => c.Id);

        public bool Equals(VoiceSettingsparametersvalue? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceSettingsparametersvalue);
        }
        #endregion
    }
}
