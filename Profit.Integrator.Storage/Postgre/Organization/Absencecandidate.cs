
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("absencecandidates")]
    public partial class Absencecandidate : IEquatable<Absencecandidate>
    {
        [Column("id"                  , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                   { get; set; } // uuid
        [Column("usersip"             , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Usersip              { get; set; } // character varying(256)
        [Column("beginabsencetime"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Beginabsencetime     { get; set; } // timestamp (6) without time zone
        [Column("curractivetime"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Curractivetime       { get; set; } // timestamp (6) without time zone
        [Column("prevstate"           , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Prevstate            { get; set; } // character varying(16)
        [Column("currstate"           , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Currstate            { get; set; } // character varying(16)
        [Column("islunchpause"        , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Islunchpause         { get; set; } // boolean
        [Column("islunchpausewithover", DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Islunchpausewithover { get; set; } // boolean
        [Column("createddate"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Absencecandidate> _equalityComparer = ComparerBuilder.GetEqualityComparer<Absencecandidate>(c => c.Id);

        public bool Equals(Absencecandidate? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Absencecandidate);
        }
        #endregion
    }
}
