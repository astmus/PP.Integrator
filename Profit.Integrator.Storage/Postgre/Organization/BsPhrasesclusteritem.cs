
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("bs_phrasesclusteritems")]
    public partial class BsPhrasesclusteritem : IEquatable<BsPhrasesclusteritem>
    {
        [Column("id"              , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id               { get; set; } // uuid
        [Column("phrasesclusterid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Phrasesclusterid { get; set; } // uuid
        [Column("cod"             , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length       = 32  )] public string?  Cod              { get; set; } // character varying(32)
        [Column("phrase"          , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Phrase           { get; set; } // text
        [Column("lemmaphrase"     , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Lemmaphrase      { get; set; } // text
        [Column("weight"          , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?  Weight           { get; set; } // double precision
        [Column("properties"      , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Properties       { get; set; } // text
        [Column("createddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate      { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"       , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted        { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<BsPhrasesclusteritem> _equalityComparer = ComparerBuilder.GetEqualityComparer<BsPhrasesclusteritem>(c => c.Id);

        public bool Equals(BsPhrasesclusteritem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BsPhrasesclusteritem);
        }
        #endregion
    }
}
