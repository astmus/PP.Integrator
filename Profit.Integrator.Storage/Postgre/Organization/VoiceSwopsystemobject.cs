
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("voice_swopsystemobjects")]
    public partial class VoiceSwopsystemobject : IEquatable<VoiceSwopsystemobject>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("swopsystemid", DataType = DataType.Guid, DbType = "uuid")] public Guid Swopsystemid { get; set; } // uuid
        [Column("objecttypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Objecttypeid { get; set; } // uuid
        [Column("needreceive", DataType = DataType.Boolean, DbType = "boolean")] public bool Needreceive { get; set; } // boolean
        [Column("swopmethodreceive", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Swopmethodreceive { get; set; } // character varying(255)
        [Column("needsend", DataType = DataType.Boolean, DbType = "boolean")] public bool Needsend { get; set; } // boolean
        [Column("swopmethod", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Swopmethod { get; set; } // character varying(255)
        [Column("swopmethodsuccess", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Swopmethodsuccess { get; set; } // character varying(255)
        [Column("Limit", DataType = DataType.Int32, DbType = "integer")] public int? Limit { get; set; } // integer
        [Column("swoporder", DataType = DataType.Int32, DbType = "integer")] public int Swoporder { get; set; } // integer
        [Column("issavebypacket", DataType = DataType.Boolean, DbType = "boolean")] public bool? Issavebypacket { get; set; } // boolean
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Createdbyuserid { get; set; } // uuid
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceSwopsystemobject> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceSwopsystemobject>(c => c.Id);

        public bool Equals(VoiceSwopsystemobject? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceSwopsystemobject);
        }
        #endregion
    }
}
