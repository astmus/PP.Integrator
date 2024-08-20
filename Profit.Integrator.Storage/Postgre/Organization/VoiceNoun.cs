
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_nouns")]
    public partial class VoiceNoun : IEquatable<VoiceNoun>
    {
        [Column("id"       , DataType  = DataType.Guid    , DbType   = "uuid"                 , IsPrimaryKey = true                                )] public Guid    Id        { get; set; } // uuid
        [Column("name"     , CanBeNull = false            , DataType = DataType.NVarChar      , DbType       = "character varying(50)", Length = 50)] public string  Name      { get; set; } = null!; // character varying(50)
        [Column("i1"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? I1        { get; set; } // character varying(50)
        [Column("i2"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? I2        { get; set; } // character varying(50)
        [Column("i5"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? I5        { get; set; } // character varying(50)
        [Column("r1"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? R1        { get; set; } // character varying(50)
        [Column("r2"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? R2        { get; set; } // character varying(50)
        [Column("r5"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? R5        { get; set; } // character varying(50)
        [Column("d1"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? D1        { get; set; } // character varying(50)
        [Column("d2"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? D2        { get; set; } // character varying(50)
        [Column("d5"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? D5        { get; set; } // character varying(50)
        [Column("v1"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? V1        { get; set; } // character varying(50)
        [Column("v2"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? V2        { get; set; } // character varying(50)
        [Column("v5"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? V5        { get; set; } // character varying(50)
        [Column("t1"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? T1        { get; set; } // character varying(50)
        [Column("t2"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? T2        { get; set; } // character varying(50)
        [Column("t5"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? T5        { get; set; } // character varying(50)
        [Column("p1"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? P1        { get; set; } // character varying(50)
        [Column("p2"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? P2        { get; set; } // character varying(50)
        [Column("p5"       , DataType  = DataType.NVarChar, DbType   = "character varying(50)", Length       = 50                                  )] public string? P5        { get; set; } // character varying(50)
        [Column("isdeleted", DataType  = DataType.Boolean , DbType   = "boolean"                                                                   )] public bool    Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceNoun> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceNoun>(c => c.Id);

        public bool Equals(VoiceNoun? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceNoun);
        }
        #endregion
    }
}
