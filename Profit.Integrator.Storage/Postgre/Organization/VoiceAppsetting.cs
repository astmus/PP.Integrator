
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_appsettings")]
    public partial class VoiceAppsetting : IEquatable<VoiceAppsetting>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Name { get; set; } // character varying(255)
        [Column("value", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Value { get; set; } // character varying(255)
        [Column("title", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Title { get; set; } // character varying(255)
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Description { get; set; } // character varying(512)
        [Column("paramtype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Paramtype { get; set; } // character varying(50)
        [Column("parentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentid { get; set; } // uuid
        [Column("itemorder", DataType = DataType.Int32, DbType = "integer")] public int? Itemorder { get; set; } // integer
        [Column("valuedescription", DataType = DataType.Text, DbType = "text")] public string? Valuedescription { get; set; } // text
        [Column("targetarea", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Targetarea { get; set; } // character varying(256)
        [Column("extensionid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Extensionid { get; set; } // uuid
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAppsetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAppsetting>(c => c.Id);

        public bool Equals(VoiceAppsetting? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAppsetting);
        }
        #endregion
    }
}
