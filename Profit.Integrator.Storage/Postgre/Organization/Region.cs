
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("regions")]
    public partial class Region : IEquatable<Region>
    {
        [Column("id"     , DataType  = DataType.Guid    , DbType   = "uuid"                 , IsPrimaryKey = true                                  )] public Guid    Id      { get; set; } // uuid
        [Column("name"   , CanBeNull = false            , DataType = DataType.NVarChar      , DbType       = "character varying(255)", Length = 255)] public string  Name    { get; set; } = null!; // character varying(255)
        [Column("objects", DataType  = DataType.Text    , DbType   = "text"                                                                        )] public string? Objects { get; set; } // text
        [Column("manager", DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                    )] public string? Manager { get; set; } // character varying(50)
        [Column("notify" , DataType  = DataType.Text    , DbType   = "text"                                                                        )] public string? Notify  { get; set; } // text
        [Column("chief"  , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                    )] public string? Chief   { get; set; } // character varying(50)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Region> _equalityComparer = ComparerBuilder.GetEqualityComparer<Region>(c => c.Id);

        public bool Equals(Region? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Region);
        }
        #endregion
    }
}
