
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("bayes_primarydata")]
    public partial class BayesPrimarydatum : IEquatable<BayesPrimarydatum>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id          { get; set; } // uuid
        [Column("areaid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Areaid      { get; set; } // uuid
        [Column("category"   , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?  Category    { get; set; } // character varying(512)
        [Column("text"       , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Text        { get; set; } // text
        [Column("lemmatext"  , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Lemmatext   { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<BayesPrimarydatum> _equalityComparer = ComparerBuilder.GetEqualityComparer<BayesPrimarydatum>(c => c.Id);

        public bool Equals(BayesPrimarydatum? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BayesPrimarydatum);
        }
        #endregion
    }
}
