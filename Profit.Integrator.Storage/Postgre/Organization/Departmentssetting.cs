
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("departmentssettings")]
    public partial class Departmentssetting : IEquatable<Departmentssetting>
    {
        [Column("deptid"                     , DataType  = DataType.Guid    , DbType   = "uuid"                  , IsPrimaryKey = true                                    )] public Guid    Deptid                      { get; set; } // uuid
        [Column("department"                 , CanBeNull = false            , DataType = DataType.NVarChar       , DbType       = "character varying(4000)", Length = 4000)] public string  Department                  { get; set; } = null!; // character varying(4000)
        [Column("schedule"                   , DataType  = DataType.NVarChar, DbType   = "character varying(32)" , Length       = 32                                      )] public string? Schedule                    { get; set; } // character varying(32)
        [Column("calendar"                   , DataType  = DataType.Guid    , DbType   = "uuid"                                                                           )] public Guid?   Calendar                    { get; set; } // uuid
        [Column("autoexplmode"               , DataType  = DataType.NVarChar, DbType   = "character varying(32)" , Length       = 32                                      )] public string? Autoexplmode                { get; set; } // character varying(32)
        [Column("accountable"                , DataType  = DataType.Guid    , DbType   = "uuid"                                                                           )] public Guid?   Accountable                 { get; set; } // uuid
        [Column("issrccalendarmeetingfilepst", DataType  = DataType.Boolean , DbType   = "boolean"                                                                        )] public bool?   Issrccalendarmeetingfilepst { get; set; } // boolean
        [Column("classifier"                 , DataType  = DataType.NVarChar, DbType   = "character varying(256)", Length       = 256                                     )] public string? Classifier                  { get; set; } // character varying(256)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Departmentssetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<Departmentssetting>(c => c.Deptid);

        public bool Equals(Departmentssetting? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Departmentssetting);
        }
        #endregion
    }
}
