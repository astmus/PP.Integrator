
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidentgridcalccolumns")]
    public partial class Guiincidentgridcalccolumn : IEquatable<Guiincidentgridcalccolumn>
    {
        [Column("id"          , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id           { get; set; } // uuid
        [Column("calcfunction", CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Calcfunction { get; set; } = null!; // character varying(1024)
        [Column("title"       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Title        { get; set; } = null!; // character varying(1024)
        [Column("description" , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Description  { get; set; } // text
        [Column("position"    , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Position     { get; set; } // integer
        [Column("width"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Width        { get; set; } // integer
        [Column("foruser"     , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024                                    )] public string?   Foruser      { get; set; } // character varying(1024)
        [Column("createdate"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Createdate   { get; set; } // timestamp (6) without time zone
        [Column("deletedate"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Deletedate   { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentgridcalccolumn> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentgridcalccolumn>(c => c.Id);

        public bool Equals(Guiincidentgridcalccolumn? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentgridcalccolumn);
        }
        #endregion
    }
}
