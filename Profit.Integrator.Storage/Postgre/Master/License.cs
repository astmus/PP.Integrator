
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("licenses")]
    public partial class License : IEquatable<License>
    {
        [Column("id"            , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid      Id             { get; set; } // uuid
        [Column("activationcode", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(20)", Length = 20)] public string    Activationcode { get; set; } = null!; // character varying(20)
        [Column("data"          , CanBeNull = false             , DataType = DataType.Binary                  , DbType       = "bytea"                             )] public byte[]    Data           { get; set; } = null!; // bytea
        [Column("activationdate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime? Activationdate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"     , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool?     Isdeleted      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<License> _equalityComparer = ComparerBuilder.GetEqualityComparer<License>(c => c.Id);

        public bool Equals(License? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as License);
        }
        #endregion
    }
}
