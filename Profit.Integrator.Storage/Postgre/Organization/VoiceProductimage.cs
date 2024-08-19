
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_productimages")]
    public partial class VoiceProductimage : IEquatable<VoiceProductimage>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("productid", DataType = DataType.Guid, DbType = "uuid")] public Guid Productid { get; set; } // uuid
        [Column("imageurl", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Imageurl { get; set; } // character varying(1024)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceProductimage> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceProductimage>(c => c.Id);

        public bool Equals(VoiceProductimage? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceProductimage);
        }
        #endregion
    }
}
