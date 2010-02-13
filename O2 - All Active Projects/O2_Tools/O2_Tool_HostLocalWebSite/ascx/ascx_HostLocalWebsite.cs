// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.IO;
using System.Windows.Forms;
using O2.DotNetWrappers.ExtensionMethods;
using O2.Kernel;
using O2.Tool.HostLocalWebsite;
using O2.Tool.HostLocalWebsite.classes;

namespace O2.Tool.HostLocalWebsite.ascx
{
    public partial class ascx_HostLocalWebsite : UserControl
    {
    	public WebServices webservices;
    	
        public ascx_HostLocalWebsite()
        {
            InitializeComponent();
            ascx_DropObject1.Text = "Drop Folder To Run";
            webservices = new WebServices();
        }

        private void onDispose()
        {
            webservices.StopWebService();
        }

        private void ascx_WebServiceScan_Load(object sender, EventArgs e) // this is not being fired at the moent
        {
            if (DesignMode == false)
            {
                PublicDI.log.error("THIS WAS NOT BEING FIRED IN DEVELOPMENT!!!");
                setupGui();
            }
        }

        public void setupGui()
        {            
            tbSettings_Exe.Text = webservices.sExe;
            tbSettings_Port.Text = webservices.sPort;
            tbSettings_Path.Text = webservices.sPath;
            tbSettings_VPath.Text = webservices.sVPath;
        }

        private void btStartWebService_Click(object sender, EventArgs e)
        {
        	try
        	{
	            if (tbSettings_Path.Text == "")
	                setupGui();
	
	            if (tbSettings_Path.Text[tbSettings_Path.Text.Length - 1] == '\\')
	                tbSettings_Path.Text = tbSettings_Path.Text.Substring(0, tbSettings_Path.Text.Length - 1);
	
	            webservices.StopWebService();
	            webservices.StartWebService();
	        }
	        catch (Exception ex)
	        {
	        	PublicDI.log.error("in btStartWebService_Click: {0}", ex);
	        }
	        var webServiceUrl = webservices.GetWebServiceURL();
            tbUrlToLoad.Text = webServiceUrl;
        }

        private void btSetTestEnvironment_Click(object sender, EventArgs e)
        {
            setupGui();
        }

        private void tbSettings_TextChanged(object sender, EventArgs e)
        {
            webservices.setExe(tbSettings_Exe.Text);
            webservices.setPort(tbSettings_Port.Text);
            webservices.setPath(tbSettings_Path.Text);
            webservices.setVPath(tbSettings_VPath.Text);
        }

        private void tbUrlToLoad_TextChanged(object sender, EventArgs e)
        {
            wbWebServices.Navigate(tbUrlToLoad.Text);
        }

        private void btReloadUrl_Click(object sender, EventArgs e)
        {
            wbWebServices.Navigate(tbUrlToLoad.Text);
        }

        private void ascx_DropObject1_eDnDAction_ObjectDataReceived_Event(object oObject)
        {
            String sItemToLoad = oObject.ToString();
            if (Directory.Exists(sItemToLoad))
                startWebServerOnDirectory(sItemToLoad);
            else
                PublicDI.log.error("Item dropped must be a folder");
        }

		public string startWebServerOnDirectory(string sDirectoryToProcess)	
		{
			var randomPort = (50000 + new Random().Next(10000)).ToString();
			return startWebServerOnDirectory(sDirectoryToProcess,randomPort);
			
		}
		
        public string startWebServerOnDirectory(string sDirectoryToProcess, string port)
        {
        	return (string)this.invokeOnThread(
        			()=> {        				
				            if (tbSettings_Exe.Text == "")
				                tbSettings_Exe.Text = webservices.sExe;
				            tbSettings_Port.Text = port;
				            tbSettings_Path.Text = sDirectoryToProcess;
				            tbSettings_VPath.Text = "/" + Path.GetFileName(sDirectoryToProcess);
				            btStartWebService_Click(null, null);
				            return tbUrlToLoad.Text;
				         });
        }
    }
}
