using System;
using System.ComponentModel;
using System.Threading;
using System.Web;
using SubSonic;

// <auto-generated />

namespace Vietbait.Lablink.Model
{
    /// <summary>
    ///     Controller class for L_Test_Status
    /// </summary>
    [DataObject]
    public class LTestStatusController
    {
        // Preload our schema..
        private LTestStatus thisSchemaLoad = new LTestStatus();
        private string userName = String.Empty;

        protected string UserName
        {
            get
            {
                if (userName.Length == 0)
                {
                    if (HttpContext.Current != null)
                    {
                        userName = HttpContext.Current.User.Identity.Name;
                    }
                    else
                    {
                        userName = Thread.CurrentPrincipal.Identity.Name;
                    }
                }
                return userName;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public LTestStatusCollection FetchAll()
        {
            var coll = new LTestStatusCollection();
            var qry = new Query(LTestStatus.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LTestStatusCollection FetchByID(object TestStatusId)
        {
            LTestStatusCollection coll = new LTestStatusCollection().Where("TestStatus_ID", TestStatusId).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LTestStatusCollection FetchByQuery(Query qry)
        {
            var coll = new LTestStatusCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TestStatusId)
        {
            return (LTestStatus.Delete(TestStatusId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TestStatusId)
        {
            return (LTestStatus.Destroy(TestStatusId) == 1);
        }


        /// <summary>
        ///     Inserts a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void Insert(short TestStatusId, string TestStatusName, bool? InUse)
        {
            var item = new LTestStatus();

            item.TestStatusId = TestStatusId;

            item.TestStatusName = TestStatusName;

            item.InUse = InUse;


            item.Save(UserName);
        }

        /// <summary>
        ///     Updates a record, can be used with the Object Data Source
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void Update(short TestStatusId, string TestStatusName, bool? InUse)
        {
            var item = new LTestStatus();
            item.MarkOld();
            item.IsLoaded = true;

            item.TestStatusId = TestStatusId;

            item.TestStatusName = TestStatusName;

            item.InUse = InUse;

            item.Save(UserName);
        }
    }
}