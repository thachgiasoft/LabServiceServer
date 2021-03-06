using System;
using System.Management;
using System.ServiceProcess;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace Vietbait.Lablink.Config
{
    public partial class FrmServiceConfig : Office2007RibbonForm
    {
        #region Contructor

        public FrmServiceConfig()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Method

        /// <summary>
        ///     Load Service to Listbox
        /// </summary>
        /// <param name="allservice"> allService =1 to Load All Service else load Vietba Service Only</param>
        private void LoadServiceToListbox(int allservice)
        {
            lbxServices.Items.Clear();
            foreach (object obj in groupPanel20.Controls)
            {
                if (obj.GetType() == typeof (TextBoxX))
                {
                    var t = (TextBoxX) obj;
                    t.Text = "";
                }
            }
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (allservice == 1)
                {
                    var li = new ListItem(service.DisplayName, service.ServiceName);
                    lbxServices.Items.Add(li);
                }
                if (service.ServiceName.ToUpper().StartsWith("VIETBA"))
                {
                    var li = new ListItem(service.DisplayName, service.ServiceName);
                    lbxServices.Items.Add(li);
                }
                //Console .WriteLine(service.);
            }
            if (lbxServices.Items.Count > 0) lbxServices.SelectedIndex = 0;
        }

        /// <summary>
        ///     Get Service Path from ServiceName
        /// </summary>
        /// <param name="pServiceName">Name of Service (Not Display Name)</param>
        /// <returns>Service Executive command</returns>
        private static ManagementObject GetServiceFromName(string pServiceName)
        {
            ManagementObject ret = null;
            //using (var searcher = new
            //    ManagementObjectSearcher("SELECT PathName from Win32_Service where Name = " + "\"" + pServiceName + "\""))
            //    ret = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

            var class1 = new ManagementClass("Win32_Service");

            foreach (ManagementObject ob in class1.GetInstances())
            {
                if (ob.GetPropertyValue("Name").ToString().Trim() == pServiceName)
                {
                    ret = ob;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        ///     This routine updates the start mode of the provided service.
        ///     Add Reference to System.Management .net Assembly
        /// </summary>
        /// <param name="serviceName">Name of the service to be updated</param>
        /// <param name="serviceStart"></param>
        /// <param name="errorMsg">If applicable, error message assoicated with exception</param>
        /// <returns>Success or failure.  False is returned if service is not found.</returns>
        public bool SetServiceStartupMode(string serviceName, ServiceStartMode serviceStart, out string errorMsg)
        {
            uint success = 1;
            errorMsg = string.Empty;
            string startMode = serviceStart.ToString();

            string filter =
                String.Format("SELECT * FROM Win32_Service WHERE Name = '{0}'", serviceName);

            var query = new ManagementObjectSearcher(filter);

            try
            {
                ManagementObjectCollection services = query.Get();

                foreach (ManagementObject service in services)
                {
                    ManagementBaseObject inParams =
                        service.GetMethodParameters("ChangeStartMode");
                    inParams["startmode"] = startMode;

                    ManagementBaseObject outParams =
                        service.InvokeMethod("ChangeStartMode", inParams, null);
                    success = Convert.ToUInt16(outParams.Properties["ReturnValue"].Value);
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                throw;
            }
            return (success == 0);
        }

        #endregion

        #region Form Events Handles

        private void FrmConfigLoad(object sender, EventArgs e)
        {
            LoadServiceToListbox(1);
            chkVietbaService.Checked = true;
        }

        private void BtnStartServiceClick(object sender, EventArgs e)
        {
            myService.Start();
            myService.WaitForStatus(ServiceControllerStatus.Running);
            MessageBox.Show(@"Start Service Success");
            LoadServiceToListbox(0);
        }

        private void BtnStopServiceClick(object sender, EventArgs e)
        {
            myService.Stop();
            myService.WaitForStatus(ServiceControllerStatus.Stopped);
            MessageBox.Show(@"Stop Service Success");
            LoadServiceToListbox(1);
        }

        private void RbtServiceAutomaticCheckedChanged(object sender, EventArgs e)
        {
            string err;
            bool ret = SetServiceStartupMode(txtServiceName.Text, ServiceStartMode.Automatic, out err);
        }

        private void RbtServiceManualCheckedChanged(object sender, EventArgs e)
        {
            string err;
            bool ret = SetServiceStartupMode(txtServiceName.Text, ServiceStartMode.Manual, out err);
        }

        private void RbtServiceDisableCheckedChanged(object sender, EventArgs e)
        {
            string err;
            bool ret = SetServiceStartupMode(txtServiceName.Text, ServiceStartMode.Disabled, out err);
        }

        private void ChkVietbaServiceCheckedChanged(object sender, EventArgs e)
        {
            if (chkVietbaService.Checked)
            {
                LoadServiceToListbox(0);
            }
            else
            {
                LoadServiceToListbox(1);
            }
        }

        private void LbxServicesSelectedIndexChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            var li = (ListItem) lbxServices.SelectedItem;
            ManagementObject mo = GetServiceFromName(li.Value);
            if (mo == null) return;
            try
            {
                txtServiceName.Text = li.Value;
                txtServicePath.Text = mo["PathName"].ToString();
                txtServiceState.Text = mo.GetPropertyValue("State").ToString();
                txtServiceStartupMode.Text = mo["StartMode"].ToString();
                if (txtServiceStartupMode.Text == "Auto") rbtServiceAutomatic.Checked = true;
                if (txtServiceStartupMode.Text == "Manual") rbtServiceManual.Checked = true;
                if (txtServiceStartupMode.Text == "Disabled") rbtServiceDisable.Checked = true;
                txtServiceType.Text = mo["ServiceType"].ToString();
                if (mo["Description"] == null)
                {
                    txtServiceDescription.Text = "";
                }
                else
                {
                    txtServiceDescription.Text = mo["Description"].ToString();
                }
            }
            catch (Exception)
            {
            }


            myService = new ServiceController(li.Value);
            if (myService.Status == ServiceControllerStatus.Running)
            {
                btnStartService.HotTrackingStyle = eHotTrackingStyle.Color;
                btnStartService.Enabled = false;
                btnStopService.HotTrackingStyle = eHotTrackingStyle.Default;
                btnStopService.Enabled = true;
            }
            else
            {
                btnStartService.HotTrackingStyle = eHotTrackingStyle.Default;
                btnStartService.Enabled = true;
                btnStopService.HotTrackingStyle = eHotTrackingStyle.Color;
                btnStopService.Enabled = false;
            }
            UseWaitCursor = false;
        }

        #endregion

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }
    }
}