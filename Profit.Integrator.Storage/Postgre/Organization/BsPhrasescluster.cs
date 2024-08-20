
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("bs_phrasesclusters")]
    public partial class BsPhrasescluster : IEquatable<BsPhrasescluster>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("name"           , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Name            { get; set; } // character varying(1024)
        [Column("cod"            , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length       = 32  )] public string?   Cod             { get; set; } // character varying(32)
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<BsPhrasescluster> _equalityComparer = ComparerBuilder.GetEqualityComparer<BsPhrasescluster>(c => c.Id);

        public bool Equals(BsPhrasescluster? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BsPhrasescluster);
        }
        #endregion
    }
}
