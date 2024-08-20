
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_knowledgearticles_folders")]
    public partial class SdKnowledgearticlesFolder : IEquatable<SdKnowledgearticlesFolder>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id          { get; set; } // uuid
        [Column("title"      , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(200)", Length = 200)] public string    Title       { get; set; } = null!; // character varying(200)
        [Column("resulttrain", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(50)" , Length = 50 )] public string    Resulttrain { get; set; } = null!; // character varying(50)
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdKnowledgearticlesFolder> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdKnowledgearticlesFolder>(c => c.Id);

        public bool Equals(SdKnowledgearticlesFolder? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdKnowledgearticlesFolder);
        }
        #endregion
    }
}
