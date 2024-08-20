
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("dct_lemmaresults")]
    public partial class DctLemmaresult : IEquatable<DctLemmaresult>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id          { get; set; } // uuid
        [Column("origword"   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Origword    { get; set; } = null!; // character varying(256)
        [Column("lemmaword"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Lemmaword   { get; set; } = null!; // character varying(256)
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<DctLemmaresult> _equalityComparer = ComparerBuilder.GetEqualityComparer<DctLemmaresult>(c => c.Id);

        public bool Equals(DctLemmaresult? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DctLemmaresult);
        }
        #endregion
    }
}
