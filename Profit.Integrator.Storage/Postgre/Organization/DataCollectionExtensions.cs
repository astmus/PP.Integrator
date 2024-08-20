using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Profit.Integrator.Storage.Postgre.Organization.OrganizationDataBase;

namespace Profit.Integrator.Storage.Postgre.Organization
{

    public static partial class DataCollectionExtensions
    {
        #region Table Extensions
        public static Absencecandidate? Find(this ITable<Absencecandidate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Absencecandidate?> FindAsync(this ITable<Absencecandidate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Absenceclassificationcandidate? Find(this ITable<Absenceclassificationcandidate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Absenceclassificationcandidate?> FindAsync(this ITable<Absenceclassificationcandidate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Accessformsforrole? Find(this ITable<Accessformsforrole> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Accessformsforrole?> FindAsync(this ITable<Accessformsforrole> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Accrual? Find(this ITable<Accrual> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Accrual?> FindAsync(this ITable<Accrual> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Activitylogtype? Find(this ITable<Activitylogtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Activitylogtype?> FindAsync(this ITable<Activitylogtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static App? Find(this ITable<App> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<App?> FindAsync(this ITable<App> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Appsmask? Find(this ITable<Appsmask> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Appsmask?> FindAsync(this ITable<Appsmask> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Appstype? Find(this ITable<Appstype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Appstype?> FindAsync(this ITable<Appstype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Attachedfile? Find(this ITable<Attachedfile> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Attachedfile?> FindAsync(this ITable<Attachedfile> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static AutoexplanatoryClassificationNotifieduser? Find(this ITable<AutoexplanatoryClassificationNotifieduser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<AutoexplanatoryClassificationNotifieduser?> FindAsync(this ITable<AutoexplanatoryClassificationNotifieduser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BayesArea? Find(this ITable<BayesArea> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BayesArea?> FindAsync(this ITable<BayesArea> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BayesPrimarydatum? Find(this ITable<BayesPrimarydatum> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BayesPrimarydatum?> FindAsync(this ITable<BayesPrimarydatum> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BayesStatistic? Find(this ITable<BayesStatistic> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BayesStatistic?> FindAsync(this ITable<BayesStatistic> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BeizAu? Find(this ITable<BeizAu> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BeizAu?> FindAsync(this ITable<BeizAu> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Blobstorage? Find(this ITable<Blobstorage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Blobstorage?> FindAsync(this ITable<Blobstorage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Blobtempstorage? Find(this ITable<Blobtempstorage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Blobtempstorage?> FindAsync(this ITable<Blobtempstorage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Branch? Find(this ITable<Branch> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Branch?> FindAsync(this ITable<Branch> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsPhrasesclusteritem? Find(this ITable<BsPhrasesclusteritem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsPhrasesclusteritem?> FindAsync(this ITable<BsPhrasesclusteritem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsPhrasescluster? Find(this ITable<BsPhrasescluster> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsPhrasescluster?> FindAsync(this ITable<BsPhrasescluster> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsReferencesetting? Find(this ITable<BsReferencesetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsReferencesetting?> FindAsync(this ITable<BsReferencesetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsReferencetype? Find(this ITable<BsReferencetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsReferencetype?> FindAsync(this ITable<BsReferencetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterAppsetting? Find(this ITable<CallcenterAppsetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterAppsetting?> FindAsync(this ITable<CallcenterAppsetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOperatorsinwork? Find(this ITable<CallcenterOperatorsinwork> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOperatorsinwork?> FindAsync(this ITable<CallcenterOperatorsinwork> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOutgoingruleabonent? Find(this ITable<CallcenterOutgoingruleabonent> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOutgoingruleabonent?> FindAsync(this ITable<CallcenterOutgoingruleabonent> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOutgoingruleoutgoingline? Find(this ITable<CallcenterOutgoingruleoutgoingline> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOutgoingruleoutgoingline?> FindAsync(this ITable<CallcenterOutgoingruleoutgoingline> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOutgoingrule? Find(this ITable<CallcenterOutgoingrule> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOutgoingrule?> FindAsync(this ITable<CallcenterOutgoingrule> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterVirtualline? Find(this ITable<CallcenterVirtualline> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterVirtualline?> FindAsync(this ITable<CallcenterVirtualline> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentercallstatelog? Find(this ITable<Callcentercallstatelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentercallstatelog?> FindAsync(this ITable<Callcentercallstatelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentercallstatetimeslot? Find(this ITable<Callcentercallstatetimeslot> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentercallstatetimeslot?> FindAsync(this ITable<Callcentercallstatetimeslot> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentercallstatetype? Find(this ITable<Callcentercallstatetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentercallstatetype?> FindAsync(this ITable<Callcentercallstatetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentergroupcalltype? Find(this ITable<Callcentergroupcalltype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentergroupcalltype?> FindAsync(this ITable<Callcentergroupcalltype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterincomeline? Find(this ITable<Callcenterincomeline> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterincomeline?> FindAsync(this ITable<Callcenterincomeline> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterivrmenuitem? Find(this ITable<Callcenterivrmenuitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterivrmenuitem?> FindAsync(this ITable<Callcenterivrmenuitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterivrmenu? Find(this ITable<Callcenterivrmenu> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterivrmenu?> FindAsync(this ITable<Callcenterivrmenu> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterivrrecordfile? Find(this ITable<Callcenterivrrecordfile> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterivrrecordfile?> FindAsync(this ITable<Callcenterivrrecordfile> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenteroperator? Find(this ITable<Callcenteroperator> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenteroperator?> FindAsync(this ITable<Callcenteroperator> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenteroperatorsgroup? Find(this ITable<Callcenteroperatorsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenteroperatorsgroup?> FindAsync(this ITable<Callcenteroperatorsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenteroperatorsingroup? Find(this ITable<Callcenteroperatorsingroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenteroperatorsingroup?> FindAsync(this ITable<Callcenteroperatorsingroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentertelbutton? Find(this ITable<Callcentertelbutton> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentertelbutton?> FindAsync(this ITable<Callcentertelbutton> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callsrecord? Find(this ITable<Callsrecord> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callsrecord?> FindAsync(this ITable<Callsrecord> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcPrioritycall? Find(this ITable<CcPrioritycall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcPrioritycall?> FindAsync(this ITable<CcPrioritycall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcSchedulecall? Find(this ITable<CcSchedulecall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcSchedulecall?> FindAsync(this ITable<CcSchedulecall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcStatecall? Find(this ITable<CcStatecall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcStatecall?> FindAsync(this ITable<CcStatecall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcUnsuccessfulcall? Find(this ITable<CcUnsuccessfulcall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcUnsuccessfulcall?> FindAsync(this ITable<CcUnsuccessfulcall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ChatActivity? Find(this ITable<ChatActivity> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ChatActivity?> FindAsync(this ITable<ChatActivity> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ChatActivityattachment? Find(this ITable<ChatActivityattachment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ChatActivityattachment?> FindAsync(this ITable<ChatActivityattachment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        //public static Cleartablessetting? Find(this ITable<Cleartablessetting> table, Guid id)
        //{
        //    return table.FirstOrDefault(e => e.Id == id);
        //}

        //public static Task<Cleartablessetting?> FindAsync(this ITable<Cleartablessetting> table, Guid id, CancellationToken cancellationToken = default)
        //{
        //    return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        //}

        public static ClipboardContent? Find(this ITable<ClipboardContent> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ClipboardContent?> FindAsync(this ITable<ClipboardContent> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CommonSetting? Find(this ITable<CommonSetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CommonSetting?> FindAsync(this ITable<CommonSetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsAccount? Find(this ITable<ConnectorsAccount> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsAccount?> FindAsync(this ITable<ConnectorsAccount> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsClasstimesync? Find(this ITable<ConnectorsClasstimesync> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsClasstimesync?> FindAsync(this ITable<ConnectorsClasstimesync> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsExchangedirection? Find(this ITable<ConnectorsExchangedirection> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsExchangedirection?> FindAsync(this ITable<ConnectorsExchangedirection> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsExchangeitem? Find(this ITable<ConnectorsExchangeitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsExchangeitem?> FindAsync(this ITable<ConnectorsExchangeitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsExchangelog? Find(this ITable<ConnectorsExchangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsExchangelog?> FindAsync(this ITable<ConnectorsExchangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsGrpcconnection? Find(this ITable<ConnectorsGrpcconnection> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsGrpcconnection?> FindAsync(this ITable<ConnectorsGrpcconnection> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsObjectidentity? Find(this ITable<ConnectorsObjectidentity> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsObjectidentity?> FindAsync(this ITable<ConnectorsObjectidentity> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsProduct? Find(this ITable<ConnectorsProduct> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsProduct?> FindAsync(this ITable<ConnectorsProduct> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsSetting? Find(this ITable<ConnectorsSetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsSetting?> FindAsync(this ITable<ConnectorsSetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContact? Find(this ITable<ConsoleContact> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContact?> FindAsync(this ITable<ConsoleContact> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsemail? Find(this ITable<ConsoleContactsemail> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsemail?> FindAsync(this ITable<ConsoleContactsemail> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsgroup? Find(this ITable<ConsoleContactsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsgroup?> FindAsync(this ITable<ConsoleContactsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsgroupsmember? Find(this ITable<ConsoleContactsgroupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsgroupsmember?> FindAsync(this ITable<ConsoleContactsgroupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsphone? Find(this ITable<ConsoleContactsphone> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsphone?> FindAsync(this ITable<ConsoleContactsphone> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleEventhistory? Find(this ITable<ConsoleEventhistory> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleEventhistory?> FindAsync(this ITable<ConsoleEventhistory> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleEventresulttype? Find(this ITable<ConsoleEventresulttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleEventresulttype?> FindAsync(this ITable<ConsoleEventresulttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleEventtype? Find(this ITable<ConsoleEventtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleEventtype?> FindAsync(this ITable<ConsoleEventtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUser? Find(this ITable<ConsoleUser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUser?> FindAsync(this ITable<ConsoleUser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUserscontactsgroup? Find(this ITable<ConsoleUserscontactsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUserscontactsgroup?> FindAsync(this ITable<ConsoleUserscontactsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUserscontactsgroupsmember? Find(this ITable<ConsoleUserscontactsgroupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUserscontactsgroupsmember?> FindAsync(this ITable<ConsoleUserscontactsgroupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUserscontactsperson? Find(this ITable<ConsoleUserscontactsperson> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUserscontactsperson?> FindAsync(this ITable<ConsoleUserscontactsperson> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Constant? Find(this ITable<Constant> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Constant?> FindAsync(this ITable<Constant> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Cweinstallation? Find(this ITable<Cweinstallation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Cweinstallation?> FindAsync(this ITable<Cweinstallation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DctLemmaresult? Find(this ITable<DctLemmaresult> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DctLemmaresult?> FindAsync(this ITable<DctLemmaresult> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentincidentassigneduser? Find(this ITable<Departmentincidentassigneduser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Departmentincidentassigneduser?> FindAsync(this ITable<Departmentincidentassigneduser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentnotifychannel? Find(this ITable<Departmentnotifychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Departmentnotifychannel?> FindAsync(this ITable<Departmentnotifychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentnotifyuser? Find(this ITable<Departmentnotifyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Departmentnotifyuser?> FindAsync(this ITable<Departmentnotifyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Department? Find(this ITable<Department> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Department?> FindAsync(this ITable<Department> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentssetting? Find(this ITable<Departmentssetting> table, Guid deptid)
        {
            return table.FirstOrDefault(e => e.Deptid == deptid);
        }

        public static Task<Departmentssetting?> FindAsync(this ITable<Departmentssetting> table, Guid deptid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Deptid == deptid, cancellationToken);
        }

        public static Discount? Find(this ITable<Discount> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Discount?> FindAsync(this ITable<Discount> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhCcCallstime? Find(this ITable<DwhCcCallstime> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhCcCallstime?> FindAsync(this ITable<DwhCcCallstime> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetric? Find(this ITable<DwhMetric> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetric?> FindAsync(this ITable<DwhMetric> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsAlertslog? Find(this ITable<DwhMetricsAlertslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsAlertslog?> FindAsync(this ITable<DwhMetricsAlertslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsgroup? Find(this ITable<DwhMetricsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsgroup?> FindAsync(this ITable<DwhMetricsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsoperand? Find(this ITable<DwhMetricsoperand> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsoperand?> FindAsync(this ITable<DwhMetricsoperand> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsoperandsVoiceCheckpoint? Find(this ITable<DwhMetricsoperandsVoiceCheckpoint> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsoperandsVoiceCheckpoint?> FindAsync(this ITable<DwhMetricsoperandsVoiceCheckpoint> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhPhraseclusterDialog? Find(this ITable<DwhPhraseclusterDialog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhPhraseclusterDialog?> FindAsync(this ITable<DwhPhraseclusterDialog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Exclog? Find(this ITable<Exclog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Exclog?> FindAsync(this ITable<Exclog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ExportResource? Find(this ITable<ExportResource> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ExportResource?> FindAsync(this ITable<ExportResource> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Frequencyincidentresolution? Find(this ITable<Frequencyincidentresolution> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Frequencyincidentresolution?> FindAsync(this ITable<Frequencyincidentresolution> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsBrand? Find(this ITable<GoodsBrand> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsBrand?> FindAsync(this ITable<GoodsBrand> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsGood? Find(this ITable<GoodsGood> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsGood?> FindAsync(this ITable<GoodsGood> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsGoodschemeattribute? Find(this ITable<GoodsGoodschemeattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsGoodschemeattribute?> FindAsync(this ITable<GoodsGoodschemeattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsWordprocessing? Find(this ITable<GoodsWordprocessing> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsWordprocessing?> FindAsync(this ITable<GoodsWordprocessing> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Group? Find(this ITable<Group> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Group?> FindAsync(this ITable<Group> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Groupsmember? Find(this ITable<Groupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Groupsmember?> FindAsync(this ITable<Groupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentattribute? Find(this ITable<Guiincidentattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentattribute?> FindAsync(this ITable<Guiincidentattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentattributesondynamicscontainer? Find(this ITable<Guiincidentattributesondynamicscontainer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentattributesondynamicscontainer?> FindAsync(this ITable<Guiincidentattributesondynamicscontainer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbuttonenabledattribute? Find(this ITable<Guiincidentbuttonenabledattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbuttonenabledattribute?> FindAsync(this ITable<Guiincidentbuttonenabledattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbutton? Find(this ITable<Guiincidentbutton> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbutton?> FindAsync(this ITable<Guiincidentbutton> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbuttonsetattribute? Find(this ITable<Guiincidentbuttonsetattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbuttonsetattribute?> FindAsync(this ITable<Guiincidentbuttonsetattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbuttonsondynamicscontainer? Find(this ITable<Guiincidentbuttonsondynamicscontainer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbuttonsondynamicscontainer?> FindAsync(this ITable<Guiincidentbuttonsondynamicscontainer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentdynamicscontainer? Find(this ITable<Guiincidentdynamicscontainer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentdynamicscontainer?> FindAsync(this ITable<Guiincidentdynamicscontainer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentform? Find(this ITable<Guiincidentform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentform?> FindAsync(this ITable<Guiincidentform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentgridattributecolumn? Find(this ITable<Guiincidentgridattributecolumn> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentgridattributecolumn?> FindAsync(this ITable<Guiincidentgridattributecolumn> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentgridcalccolumn? Find(this ITable<Guiincidentgridcalccolumn> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentgridcalccolumn?> FindAsync(this ITable<Guiincidentgridcalccolumn> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentscript? Find(this ITable<Guiincidentscript> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentscript?> FindAsync(this ITable<Guiincidentscript> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidenttattributesonform? Find(this ITable<Guiincidenttattributesonform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidenttattributesonform?> FindAsync(this ITable<Guiincidenttattributesonform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributecontroltype? Find(this ITable<Guiincidentuserattributecontroltype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributecontroltype?> FindAsync(this ITable<Guiincidentuserattributecontroltype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattribute? Find(this ITable<Guiincidentuserattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattribute?> FindAsync(this ITable<Guiincidentuserattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributesourceparam? Find(this ITable<Guiincidentuserattributesourceparam> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributesourceparam?> FindAsync(this ITable<Guiincidentuserattributesourceparam> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributesourcetype? Find(this ITable<Guiincidentuserattributesourcetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributesourcetype?> FindAsync(this ITable<Guiincidentuserattributesourcetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributetype? Find(this ITable<Guiincidentuserattributetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributetype?> FindAsync(this ITable<Guiincidentuserattributetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrCandidateonstagingitemstatus? Find(this ITable<HrCandidateonstagingitemstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrCandidateonstagingitemstatus?> FindAsync(this ITable<HrCandidateonstagingitemstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrCandidateonstepstatus? Find(this ITable<HrCandidateonstepstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrCandidateonstepstatus?> FindAsync(this ITable<HrCandidateonstepstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrCandidateratingstatus? Find(this ITable<HrCandidateratingstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrCandidateratingstatus?> FindAsync(this ITable<HrCandidateratingstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmploymentcandidatesonstagingitem? Find(this ITable<HrEmploymentcandidatesonstagingitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmploymentcandidatesonstagingitem?> FindAsync(this ITable<HrEmploymentcandidatesonstagingitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmployment? Find(this ITable<HrEmployment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmployment?> FindAsync(this ITable<HrEmployment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmploymentsearchcandidate? Find(this ITable<HrEmploymentsearchcandidate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmploymentsearchcandidate?> FindAsync(this ITable<HrEmploymentsearchcandidate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmploymentsearchresult? Find(this ITable<HrEmploymentsearchresult> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmploymentsearchresult?> FindAsync(this ITable<HrEmploymentsearchresult> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrReferenceitem? Find(this ITable<HrReferenceitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrReferenceitem?> FindAsync(this ITable<HrReferenceitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrReferencetype? Find(this ITable<HrReferencetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrReferencetype?> FindAsync(this ITable<HrReferencetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrStagingemploymentitemhrcoworker? Find(this ITable<HrStagingemploymentitemhrcoworker> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrStagingemploymentitemhrcoworker?> FindAsync(this ITable<HrStagingemploymentitemhrcoworker> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrStagingemploymentitem? Find(this ITable<HrStagingemploymentitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrStagingemploymentitem?> FindAsync(this ITable<HrStagingemploymentitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrStagingemployment? Find(this ITable<HrStagingemployment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrStagingemployment?> FindAsync(this ITable<HrStagingemployment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Languagecode? Find(this ITable<Languagecode> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Languagecode?> FindAsync(this ITable<Languagecode> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Localizedtext? Find(this ITable<Localizedtext> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Localizedtext?> FindAsync(this ITable<Localizedtext> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogObjectsprocess? Find(this ITable<LogObjectsprocess> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogObjectsprocess?> FindAsync(this ITable<LogObjectsprocess> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogsObjectstype? Find(this ITable<LogsObjectstype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogsObjectstype?> FindAsync(this ITable<LogsObjectstype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogsTransactiontype? Find(this ITable<LogsTransactiontype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogsTransactiontype?> FindAsync(this ITable<LogsTransactiontype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogsVisitsobjectsbyuser? Find(this ITable<LogsVisitsobjectsbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogsVisitsobjectsbyuser?> FindAsync(this ITable<LogsVisitsobjectsbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringDeviceparam? Find(this ITable<MonitoringDeviceparam> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringDeviceparam?> FindAsync(this ITable<MonitoringDeviceparam> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringDevice? Find(this ITable<MonitoringDevice> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringDevice?> FindAsync(this ITable<MonitoringDevice> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringDevicestype? Find(this ITable<MonitoringDevicestype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringDevicestype?> FindAsync(this ITable<MonitoringDevicestype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringEventslog? Find(this ITable<MonitoringEventslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringEventslog?> FindAsync(this ITable<MonitoringEventslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringStatuslog? Find(this ITable<MonitoringStatuslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringStatuslog?> FindAsync(this ITable<MonitoringStatuslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceDistributiongroup? Find(this ITable<NotificationserviceDistributiongroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceDistributiongroup?> FindAsync(this ITable<NotificationserviceDistributiongroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceDistributiongroupsmember? Find(this ITable<NotificationserviceDistributiongroupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceDistributiongroupsmember?> FindAsync(this ITable<NotificationserviceDistributiongroupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceMessage? Find(this ITable<NotificationserviceMessage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceMessage?> FindAsync(this ITable<NotificationserviceMessage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceQueue? Find(this ITable<NotificationserviceQueue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceQueue?> FindAsync(this ITable<NotificationserviceQueue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Notifychannel? Find(this ITable<Notifychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Notifychannel?> FindAsync(this ITable<Notifychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Objectpermission? Find(this ITable<Objectpermission> table, Guid objectid, string objecttype, Guid usergroupid)
        {
            return table.FirstOrDefault(e => e.Objectid == objectid && e.Objecttype == objecttype && e.Usergroupid == usergroupid);
        }

        public static Task<Objectpermission?> FindAsync(this ITable<Objectpermission> table, Guid objectid, string objecttype, Guid usergroupid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Objectid == objectid && e.Objecttype == objecttype && e.Usergroupid == usergroupid, cancellationToken);
        }

        public static Otheremailsbyuser? Find(this ITable<Otheremailsbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Otheremailsbyuser?> FindAsync(this ITable<Otheremailsbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Otherphonesbyuser? Find(this ITable<Otherphonesbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Otherphonesbyuser?> FindAsync(this ITable<Otherphonesbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Pitstate? Find(this ITable<Pitstate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Pitstate?> FindAsync(this ITable<Pitstate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Queue? Find(this ITable<Queue> table, Guid rid)
        {
            return table.FirstOrDefault(e => e.Rid == rid);
        }

        public static Task<Queue?> FindAsync(this ITable<Queue> table, Guid rid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Rid == rid, cancellationToken);
        }

        public static Region? Find(this ITable<Region> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Region?> FindAsync(this ITable<Region> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Relatedincidentandcall? Find(this ITable<Relatedincidentandcall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Relatedincidentandcall?> FindAsync(this ITable<Relatedincidentandcall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ReportsEnabledcustomreport? Find(this ITable<ReportsEnabledcustomreport> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ReportsEnabledcustomreport?> FindAsync(this ITable<ReportsEnabledcustomreport> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ReportsExternalreport? Find(this ITable<ReportsExternalreport> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ReportsExternalreport?> FindAsync(this ITable<ReportsExternalreport> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Role? Find(this ITable<Role> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Role?> FindAsync(this ITable<Role> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Rolesmember? Find(this ITable<Rolesmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Rolesmember?> FindAsync(this ITable<Rolesmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        //public static Schemaversion? Find(this ITable<Schemaversion> table, int schemaversionsid)
        //{
        //    return table.FirstOrDefault(e => e.Schemaversionsid == schemaversionsid);
        //}

        //public static Task<Schemaversion?> FindAsync(this ITable<Schemaversion> table, int schemaversionsid, CancellationToken cancellationToken = default)
        //{
        //    return table.FirstOrDefaultAsync(e => e.Schemaversionsid == schemaversionsid, cancellationToken);
        //}

        public static Script? Find(this ITable<Script> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Script?> FindAsync(this ITable<Script> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdEntitieschangelog? Find(this ITable<SdEntitieschangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdEntitieschangelog?> FindAsync(this ITable<SdEntitieschangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdEntitytype? Find(this ITable<SdEntitytype> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdEntitytype?> FindAsync(this ITable<SdEntitytype> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdExchangeEventtype? Find(this ITable<SdExchangeEventtype> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdExchangeEventtype?> FindAsync(this ITable<SdExchangeEventtype> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdExchangelog? Find(this ITable<SdExchangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdExchangelog?> FindAsync(this ITable<SdExchangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdExchangeout? Find(this ITable<SdExchangeout> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdExchangeout?> FindAsync(this ITable<SdExchangeout> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdKnowledgearticle? Find(this ITable<SdKnowledgearticle> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdKnowledgearticle?> FindAsync(this ITable<SdKnowledgearticle> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdKnowledgearticlesFolder? Find(this ITable<SdKnowledgearticlesFolder> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdKnowledgearticlesFolder?> FindAsync(this ITable<SdKnowledgearticlesFolder> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSetting? Find(this ITable<SdSetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSetting?> FindAsync(this ITable<SdSetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSla? Find(this ITable<SdSla> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSla?> FindAsync(this ITable<SdSla> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaColor? Find(this ITable<SdSlaColor> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaColor?> FindAsync(this ITable<SdSlaColor> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaMetric? Find(this ITable<SdSlaMetric> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaMetric?> FindAsync(this ITable<SdSlaMetric> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaSlacategoryitem? Find(this ITable<SdSlaSlacategoryitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaSlacategoryitem?> FindAsync(this ITable<SdSlaSlacategoryitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaSlametricitem? Find(this ITable<SdSlaSlametricitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaSlametricitem?> FindAsync(this ITable<SdSlaSlametricitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdTierqueuesenummember? Find(this ITable<SdTierqueuesenummember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdTierqueuesenummember?> FindAsync(this ITable<SdTierqueuesenummember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWebrequest? Find(this ITable<SdWebrequest> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWebrequest?> FindAsync(this ITable<SdWebrequest> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemColor? Find(this ITable<SdWorkitemColor> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemColor?> FindAsync(this ITable<SdWorkitemColor> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemComment? Find(this ITable<SdWorkitemComment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemComment?> FindAsync(this ITable<SdWorkitemComment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemCommentsauthortype? Find(this ITable<SdWorkitemCommentsauthortype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemCommentsauthortype?> FindAsync(this ITable<SdWorkitemCommentsauthortype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemCommentstype? Find(this ITable<SdWorkitemCommentstype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemCommentstype?> FindAsync(this ITable<SdWorkitemCommentstype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemConditionsforsendingsm? Find(this ITable<SdWorkitemConditionsforsendingsm> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemConditionsforsendingsm?> FindAsync(this ITable<SdWorkitemConditionsforsendingsm> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemElapsedtime? Find(this ITable<SdWorkitemElapsedtime> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemElapsedtime?> FindAsync(this ITable<SdWorkitemElapsedtime> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemEnum? Find(this ITable<SdWorkitemEnum> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemEnum?> FindAsync(this ITable<SdWorkitemEnum> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemEnumtype? Find(this ITable<SdWorkitemEnumtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemEnumtype?> FindAsync(this ITable<SdWorkitemEnumtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemIncident? Find(this ITable<SdWorkitemIncident> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemIncident?> FindAsync(this ITable<SdWorkitemIncident> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemListingsetting? Find(this ITable<SdWorkitemListingsetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemListingsetting?> FindAsync(this ITable<SdWorkitemListingsetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemRelatedknowledgearticle? Find(this ITable<SdWorkitemRelatedknowledgearticle> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemRelatedknowledgearticle?> FindAsync(this ITable<SdWorkitemRelatedknowledgearticle> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemSourceitem? Find(this ITable<SdWorkitemSourceitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemSourceitem?> FindAsync(this ITable<SdWorkitemSourceitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemsFactsla? Find(this ITable<SdWorkitemsFactsla> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemsFactsla?> FindAsync(this ITable<SdWorkitemsFactsla> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemsSla? Find(this ITable<SdWorkitemsSla> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemsSla?> FindAsync(this ITable<SdWorkitemsSla> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ServicedeskSmsintegrationNotificationqueue? Find(this ITable<ServicedeskSmsintegrationNotificationqueue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ServicedeskSmsintegrationNotificationqueue?> FindAsync(this ITable<ServicedeskSmsintegrationNotificationqueue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Settingschangelog? Find(this ITable<Settingschangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Settingschangelog?> FindAsync(this ITable<Settingschangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Signatureuser? Find(this ITable<Signatureuser> table, Guid userid)
        {
            return table.FirstOrDefault(e => e.Userid == userid);
        }

        public static Task<Signatureuser?> FindAsync(this ITable<Signatureuser> table, Guid userid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Userid == userid, cancellationToken);
        }

        public static SmsOperation? Find(this ITable<SmsOperation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SmsOperation?> FindAsync(this ITable<SmsOperation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Solution? Find(this ITable<Solution> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Solution?> FindAsync(this ITable<Solution> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Textmessage? Find(this ITable<Textmessage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Textmessage?> FindAsync(this ITable<Textmessage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementSchedule? Find(this ITable<TimemanagementSchedule> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementSchedule?> FindAsync(this ITable<TimemanagementSchedule> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleOffice? Find(this ITable<TimemanagementScheduleOffice> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleOffice?> FindAsync(this ITable<TimemanagementScheduleOffice> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleOfficeroleassignment? Find(this ITable<TimemanagementScheduleOfficeroleassignment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleOfficeroleassignment?> FindAsync(this ITable<TimemanagementScheduleOfficeroleassignment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleRole? Find(this ITable<TimemanagementScheduleRole> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleRole?> FindAsync(this ITable<TimemanagementScheduleRole> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleWorkday? Find(this ITable<TimemanagementScheduleWorkday> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleWorkday?> FindAsync(this ITable<TimemanagementScheduleWorkday> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleassignment? Find(this ITable<TimemanagementScheduleassignment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleassignment?> FindAsync(this ITable<TimemanagementScheduleassignment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Trustedapp? Find(this ITable<Trustedapp> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Trustedapp?> FindAsync(this ITable<Trustedapp> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPagegroup? Find(this ITable<UiPagegroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPagegroup?> FindAsync(this ITable<UiPagegroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPage? Find(this ITable<UiPage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPage?> FindAsync(this ITable<UiPage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPagesingroup? Find(this ITable<UiPagesingroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPagesingroup?> FindAsync(this ITable<UiPagesingroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiRoleaccesstopage? Find(this ITable<UiRoleaccesstopage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiRoleaccesstopage?> FindAsync(this ITable<UiRoleaccesstopage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usercontact? Find(this ITable<Usercontact> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usercontact?> FindAsync(this ITable<Usercontact> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usercontacttype? Find(this ITable<Usercontacttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usercontacttype?> FindAsync(this ITable<Usercontacttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotification? Find(this ITable<Usernotification> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotification?> FindAsync(this ITable<Usernotification> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationsmacrose? Find(this ITable<Usernotificationsmacrose> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationsmacrose?> FindAsync(this ITable<Usernotificationsmacrose> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationssendedbychannel? Find(this ITable<Usernotificationssendedbychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationssendedbychannel?> FindAsync(this ITable<Usernotificationssendedbychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationstemplate? Find(this ITable<Usernotificationstemplate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationstemplate?> FindAsync(this ITable<Usernotificationstemplate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationstemplatesonbackgroundtask? Find(this ITable<Usernotificationstemplatesonbackgroundtask> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationstemplatesonbackgroundtask?> FindAsync(this ITable<Usernotificationstemplatesonbackgroundtask> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationstemplatesview? Find(this ITable<Usernotificationstemplatesview> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationstemplatesview?> FindAsync(this ITable<Usernotificationstemplatesview> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotifychannel? Find(this ITable<Usernotifychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotifychannel?> FindAsync(this ITable<Usernotifychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static User? Find(this ITable<User> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<User?> FindAsync(this ITable<User> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UsersProperty? Find(this ITable<UsersProperty> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UsersProperty?> FindAsync(this ITable<UsersProperty> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViAvitochatstatus? Find(this ITable<ViAvitochatstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViAvitochatstatus?> FindAsync(this ITable<ViAvitochatstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViCall? Find(this ITable<ViCall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViCall?> FindAsync(this ITable<ViCall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatactivityattachment? Find(this ITable<ViChatactivityattachment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatactivityattachment?> FindAsync(this ITable<ViChatactivityattachment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatloading? Find(this ITable<ViChatloading> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatloading?> FindAsync(this ITable<ViChatloading> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatlog? Find(this ITable<ViChatlog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatlog?> FindAsync(this ITable<ViChatlog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatlogtype? Find(this ITable<ViChatlogtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatlogtype?> FindAsync(this ITable<ViChatlogtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatoperatorslog? Find(this ITable<ViChatoperatorslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatoperatorslog?> FindAsync(this ITable<ViChatoperatorslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatoperatorsstatus? Find(this ITable<ViChatoperatorsstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatoperatorsstatus?> FindAsync(this ITable<ViChatoperatorsstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatplatform? Find(this ITable<ViChatplatform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatplatform?> FindAsync(this ITable<ViChatplatform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatrequest? Find(this ITable<ViChatrequest> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatrequest?> FindAsync(this ITable<ViChatrequest> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatrichmediatemplate? Find(this ITable<ViChatrichmediatemplate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatrichmediatemplate?> FindAsync(this ITable<ViChatrichmediatemplate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatrichmediatemplatesbyplatform? Find(this ITable<ViChatrichmediatemplatesbyplatform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatrichmediatemplatesbyplatform?> FindAsync(this ITable<ViChatrichmediatemplatesbyplatform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatsystemmessage? Find(this ITable<ViChatsystemmessage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatsystemmessage?> FindAsync(this ITable<ViChatsystemmessage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChattimeout? Find(this ITable<ViChattimeout> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChattimeout?> FindAsync(this ITable<ViChattimeout> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViCheckpoint? Find(this ITable<ViCheckpoint> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViCheckpoint?> FindAsync(this ITable<ViCheckpoint> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViClassificationstatistic? Find(this ITable<ViClassificationstatistic> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViClassificationstatistic?> FindAsync(this ITable<ViClassificationstatistic> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViExternalresource? Find(this ITable<ViExternalresource> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViExternalresource?> FindAsync(this ITable<ViExternalresource> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotificationbychannel? Find(this ITable<ViNotificationbychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotificationbychannel?> FindAsync(this ITable<ViNotificationbychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotificationbyuser? Find(this ITable<ViNotificationbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotificationbyuser?> FindAsync(this ITable<ViNotificationbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotification? Find(this ITable<ViNotification> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotification?> FindAsync(this ITable<ViNotification> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotificationsendedbysession? Find(this ITable<ViNotificationsendedbysession> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotificationsendedbysession?> FindAsync(this ITable<ViNotificationsendedbysession> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViObjectschemeAttributeValue? Find(this ITable<ViObjectschemeAttributeValue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViObjectschemeAttributeValue?> FindAsync(this ITable<ViObjectschemeAttributeValue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViObjectschemeAttribute? Find(this ITable<ViObjectschemeAttribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViObjectschemeAttribute?> FindAsync(this ITable<ViObjectschemeAttribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViObjectscheme? Find(this ITable<ViObjectscheme> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViObjectscheme?> FindAsync(this ITable<ViObjectscheme> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViPlatformlog? Find(this ITable<ViPlatformlog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViPlatformlog?> FindAsync(this ITable<ViPlatformlog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViScriptbychannel? Find(this ITable<ViScriptbychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViScriptbychannel?> FindAsync(this ITable<ViScriptbychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViSessionchannel? Find(this ITable<ViSessionchannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViSessionchannel?> FindAsync(this ITable<ViSessionchannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViSessionrelation? Find(this ITable<ViSessionrelation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViSessionrelation?> FindAsync(this ITable<ViSessionrelation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViSessiontype? Find(this ITable<ViSessiontype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViSessiontype?> FindAsync(this ITable<ViSessiontype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentaccountingtype? Find(this ITable<VoiceAbonentaccountingtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentaccountingtype?> FindAsync(this ITable<VoiceAbonentaccountingtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentaddress? Find(this ITable<VoiceAbonentaddress> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentaddress?> FindAsync(this ITable<VoiceAbonentaddress> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdebt? Find(this ITable<VoiceAbonentdebt> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdebt?> FindAsync(this ITable<VoiceAbonentdebt> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdevicerate? Find(this ITable<VoiceAbonentdevicerate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdevicerate?> FindAsync(this ITable<VoiceAbonentdevicerate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdeviceratetype? Find(this ITable<VoiceAbonentdeviceratetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdeviceratetype?> FindAsync(this ITable<VoiceAbonentdeviceratetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdevice? Find(this ITable<VoiceAbonentdevice> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdevice?> FindAsync(this ITable<VoiceAbonentdevice> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonent? Find(this ITable<VoiceAbonent> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonent?> FindAsync(this ITable<VoiceAbonent> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAppsetting? Find(this ITable<VoiceAppsetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAppsetting?> FindAsync(this ITable<VoiceAppsetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAtm? Find(this ITable<VoiceAtm> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAtm?> FindAsync(this ITable<VoiceAtm> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceBilling? Find(this ITable<VoiceBilling> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceBilling?> FindAsync(this ITable<VoiceBilling> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceBingcache? Find(this ITable<VoiceBingcache> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceBingcache?> FindAsync(this ITable<VoiceBingcache> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceCellblockingreason? Find(this ITable<VoiceCellblockingreason> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceCellblockingreason?> FindAsync(this ITable<VoiceCellblockingreason> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceCell? Find(this ITable<VoiceCell> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceCell?> FindAsync(this ITable<VoiceCell> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceClerkstoplist? Find(this ITable<VoiceClerkstoplist> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceClerkstoplist?> FindAsync(this ITable<VoiceClerkstoplist> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceContextparameter? Find(this ITable<VoiceContextparameter> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceContextparameter?> FindAsync(this ITable<VoiceContextparameter> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDialog? Find(this ITable<VoiceDialog> table, long id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDialog?> FindAsync(this ITable<VoiceDialog> table, long id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDocumentitem? Find(this ITable<VoiceDocumentitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDocumentitem?> FindAsync(this ITable<VoiceDocumentitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDocumentitemscannedmark? Find(this ITable<VoiceDocumentitemscannedmark> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDocumentitemscannedmark?> FindAsync(this ITable<VoiceDocumentitemscannedmark> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDocument? Find(this ITable<VoiceDocument> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDocument?> FindAsync(this ITable<VoiceDocument> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceEmployee? Find(this ITable<VoiceEmployee> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceEmployee?> FindAsync(this ITable<VoiceEmployee> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceGrammaritem? Find(this ITable<VoiceGrammaritem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceGrammaritem?> FindAsync(this ITable<VoiceGrammaritem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceGrammar? Find(this ITable<VoiceGrammar> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceGrammar?> FindAsync(this ITable<VoiceGrammar> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterviewquestionanswer? Find(this ITable<VoiceInterviewquestionanswer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterviewquestionanswer?> FindAsync(this ITable<VoiceInterviewquestionanswer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterviewquestion? Find(this ITable<VoiceInterviewquestion> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterviewquestion?> FindAsync(this ITable<VoiceInterviewquestion> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterview? Find(this ITable<VoiceInterview> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterview?> FindAsync(this ITable<VoiceInterview> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterviewuseranswer? Find(this ITable<VoiceInterviewuseranswer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterviewuseranswer?> FindAsync(this ITable<VoiceInterviewuseranswer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceLocation? Find(this ITable<VoiceLocation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceLocation?> FindAsync(this ITable<VoiceLocation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceMethod? Find(this ITable<VoiceMethod> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceMethod?> FindAsync(this ITable<VoiceMethod> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceMethodsargument? Find(this ITable<VoiceMethodsargument> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceMethodsargument?> FindAsync(this ITable<VoiceMethodsargument> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceNoun? Find(this ITable<VoiceNoun> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceNoun?> FindAsync(this ITable<VoiceNoun> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceObjecttype? Find(this ITable<VoiceObjecttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceObjecttype?> FindAsync(this ITable<VoiceObjecttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductbox? Find(this ITable<VoiceProductbox> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductbox?> FindAsync(this ITable<VoiceProductbox> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductcategory? Find(this ITable<VoiceProductcategory> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductcategory?> FindAsync(this ITable<VoiceProductcategory> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductimage? Find(this ITable<VoiceProductimage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductimage?> FindAsync(this ITable<VoiceProductimage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductmark? Find(this ITable<VoiceProductmark> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductmark?> FindAsync(this ITable<VoiceProductmark> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductmarkstatus? Find(this ITable<VoiceProductmarkstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductmarkstatus?> FindAsync(this ITable<VoiceProductmarkstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProduct? Find(this ITable<VoiceProduct> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProduct?> FindAsync(this ITable<VoiceProduct> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductseries? Find(this ITable<VoiceProductseries> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductseries?> FindAsync(this ITable<VoiceProductseries> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceRecognizedphrase? Find(this ITable<VoiceRecognizedphrase> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceRecognizedphrase?> FindAsync(this ITable<VoiceRecognizedphrase> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceRecruitmentInterval? Find(this ITable<VoiceRecruitmentInterval> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceRecruitmentInterval?> FindAsync(this ITable<VoiceRecruitmentInterval> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceReplacement? Find(this ITable<VoiceReplacement> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceReplacement?> FindAsync(this ITable<VoiceReplacement> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScript? Find(this ITable<VoiceScript> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScript?> FindAsync(this ITable<VoiceScript> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptsgroup? Find(this ITable<VoiceScriptsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptsgroup?> FindAsync(this ITable<VoiceScriptsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptsteplink? Find(this ITable<VoiceScriptsteplink> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptsteplink?> FindAsync(this ITable<VoiceScriptsteplink> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptstep? Find(this ITable<VoiceScriptstep> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptstep?> FindAsync(this ITable<VoiceScriptstep> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptstepsfreeanswerswitcher? Find(this ITable<VoiceScriptstepsfreeanswerswitcher> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptstepsfreeanswerswitcher?> FindAsync(this ITable<VoiceScriptstepsfreeanswerswitcher> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSettingsparameter? Find(this ITable<VoiceSettingsparameter> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSettingsparameter?> FindAsync(this ITable<VoiceSettingsparameter> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSettingsparametersvalue? Find(this ITable<VoiceSettingsparametersvalue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSettingsparametersvalue?> FindAsync(this ITable<VoiceSettingsparametersvalue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceStepfrequency? Find(this ITable<VoiceStepfrequency> table, Guid stepid)
        {
            return table.FirstOrDefault(e => e.Stepid == stepid);
        }

        public static Task<VoiceStepfrequency?> FindAsync(this ITable<VoiceStepfrequency> table, Guid stepid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Stepid == stepid, cancellationToken);
        }

        public static VoiceSwop? Find(this ITable<VoiceSwop> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSwop?> FindAsync(this ITable<VoiceSwop> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSwopsystemobject? Find(this ITable<VoiceSwopsystemobject> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSwopsystemobject?> FindAsync(this ITable<VoiceSwopsystemobject> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSwopsystem? Find(this ITable<VoiceSwopsystem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSwopsystem?> FindAsync(this ITable<VoiceSwopsystem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSynthcache? Find(this ITable<VoiceSynthcache> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSynthcache?> FindAsync(this ITable<VoiceSynthcache> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUnitbarcode? Find(this ITable<VoiceUnitbarcode> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUnitbarcode?> FindAsync(this ITable<VoiceUnitbarcode> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUnit? Find(this ITable<VoiceUnit> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUnit?> FindAsync(this ITable<VoiceUnit> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUnittype? Find(this ITable<VoiceUnittype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUnittype?> FindAsync(this ITable<VoiceUnittype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUserrequesttype? Find(this ITable<VoiceUserrequesttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUserrequesttype?> FindAsync(this ITable<VoiceUserrequesttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUserrequesttypesargument? Find(this ITable<VoiceUserrequesttypesargument> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUserrequesttypesargument?> FindAsync(this ITable<VoiceUserrequesttypesargument> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Way? Find(this ITable<Way> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Way?> FindAsync(this ITable<Way> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Workcalendardayexception? Find(this ITable<Workcalendardayexception> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Workcalendardayexception?> FindAsync(this ITable<Workcalendardayexception> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Workcalendardayrange? Find(this ITable<Workcalendardayrange> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Workcalendardayrange?> FindAsync(this ITable<Workcalendardayrange> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Workcalendar? Find(this ITable<Workcalendar> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Workcalendar?> FindAsync(this ITable<Workcalendar> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Время? Find(this ITable<Время> table, DateTime pkДата)
        {
            return table.FirstOrDefault(e => e.PkДата == pkДата);
        }

        public static Task<Время?> FindAsync(this ITable<Время> table, DateTime pkДата, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.PkДата == pkДата, cancellationToken);
        }
        #endregion
    }
}
