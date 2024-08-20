
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("entitiesadous")]
    public partial class Entitiesadou : IEquatable<Entitiesadou>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id          { get; set; } // uuid
        [Column("entity"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Entity      { get; set; } // uuid
        [Column("ad_ou"      , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   AdOu        { get; set; } // character varying(1024)
        [Column("createdate" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createdate  { get; set; } // timestamp (6) without time zone
        [Column("withsubtree", DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Withsubtree { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Entitiesadou> _equalityComparer = ComparerBuilder.GetEqualityComparer<Entitiesadou>(c => c.Id);

        public bool Equals(Entitiesadou? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entitiesadou);
        }
        #endregion
    }
}
