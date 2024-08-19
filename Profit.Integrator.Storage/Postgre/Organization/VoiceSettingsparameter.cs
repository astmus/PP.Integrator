
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_settingsparameters")]
    public partial class VoiceSettingsparameter : IEquatable<VoiceSettingsparameter>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Name { get; set; } = null!; // character varying(128)
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Title { get; set; } = null!; // character varying(128)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("selfvaluetype", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string Selfvaluetype { get; set; } = null!; // character varying(16)
        [Column("iscomplex", DataType = DataType.Boolean, DbType = "boolean")] public bool? Iscomplex { get; set; } // boolean
        [Column("defaultvalue", DataType = DataType.Text, DbType = "text")] public string? Defaultvalue { get; set; } // text
        [Column("parentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentid { get; set; } // uuid
        [Column("supportmulty", DataType = DataType.Boolean, DbType = "boolean")] public bool? Supportmulty { get; set; } // boolean
        [Column("stepperformer", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Stepperformer { get; set; } // character varying(255)
        [Column("recognizertype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Recognizertype { get; set; } // character varying(50)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("itemorder", DataType = DataType.Int32, DbType = "integer")] public int? Itemorder { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceSettingsparameter> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceSettingsparameter>(c => c.Id);

        public bool Equals(VoiceSettingsparameter? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceSettingsparameter);
        }
        #endregion
    }
}
