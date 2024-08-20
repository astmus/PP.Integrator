
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("usernotifications")]
    public partial class Usernotification : IEquatable<Usernotification>
    {
        [Column("id"                    , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                     { get; set; } // uuid
        [Column("touserid"              , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Touserid               { get; set; } // uuid
        [Column("backgroundtaskid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Backgroundtaskid       { get; set; } // uuid
        [Column("messagetext"           , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Messagetext            { get; set; } // text
        [Column("reasonitemid"          , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Reasonitemid           { get; set; } // uuid
        [Column("userproperties"        , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Userproperties         { get; set; } // text
        [Column("expirydate"            , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Expirydate             { get; set; } // timestamp (6) without time zone
        [Column("sendeddate"            , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Sendeddate             { get; set; } // timestamp (6) without time zone
        [Column("createddate"           , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate            { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"             , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted              { get; set; } // boolean
        [Column("issendingscheduledtime", DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Issendingscheduledtime { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Usernotification> _equalityComparer = ComparerBuilder.GetEqualityComparer<Usernotification>(c => c.Id);

        public bool Equals(Usernotification? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Usernotification);
        }
        #endregion
    }
}
