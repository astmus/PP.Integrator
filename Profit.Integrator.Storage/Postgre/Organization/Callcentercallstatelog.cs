
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcentercallstatelog")]
    public partial class Callcentercallstatelog : IEquatable<Callcentercallstatelog>
    {
        [Column("id"                  , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id                   { get; set; } // uuid
        [Column("call"                , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Call                 { get; set; } // uuid
        [Column("statetype"           , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Statetype            { get; set; } // uuid
        [Column("logtime"             , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Logtime              { get; set; } // timestamp (6) without time zone
        [Column("ivrmenu"             , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Ivrmenu              { get; set; } // uuid
        [Column("ivrmenuitem"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Ivrmenuitem          { get; set; } // uuid
        [Column("operator"            , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Operator             { get; set; } // uuid
        [Column("operatorsgroup"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Operatorsgroup       { get; set; } // uuid
        [Column("externalcontrollerid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?    Externalcontrollerid { get; set; } // uuid
        [Column("uri"                 , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?  Uri                  { get; set; } // character varying(256)
        [Column("conversationid"      , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?  Conversationid       { get; set; } // character varying(50)
        [Column("dialingresult"       , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?  Dialingresult        { get; set; } // character varying(50)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcentercallstatelog> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcentercallstatelog>(c => c.Id);

        public bool Equals(Callcentercallstatelog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcentercallstatelog);
        }
        #endregion
    }
}
