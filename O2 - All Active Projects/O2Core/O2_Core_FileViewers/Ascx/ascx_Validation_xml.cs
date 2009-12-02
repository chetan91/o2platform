using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using O2.Core.FileViewers.J2EE;
using O2.DotNetWrappers.DotNet;
using O2.Core.FileViewers.ViewHelpers;
using O2.Kernel.Interfaces.FrameworkSupport.J2EE;

namespace O2.Core.FileViewers.Ascx
{
    public partial class ascx_Validation_xml : UserControl
    {
        private string loadedFile = "";
        private bool runOnLoad = true;
        public void onLoad()
        {
            if (DesignMode == false && runOnLoad)
            {
                //var listView_Form = tableList_Forms.getListViewControl();
                //listView_Form.SelectedIndexChanged += new EventHandler(listView_Form_SelectedIndexChanged);
                runOnLoad = false;
            }
            
        }
        
        public ascx_Validation_xml()
        {
            InitializeComponent();
        }

        private void btMapLoadedFile_Click(object sender, EventArgs e)
        {
            maploadedFile();
        }

        public void maploadedFile()
        {
            mapFile(loadedFile);
        }

        public void mapFile(string fileToMap)
        {
            loadedFile = fileToMap;            
            var validationXml = J2eeConfigFiles.getValidationXml(fileToMap);
            this.invokeOnThread(() => refreshTreeView(validationXml));

            //tableList_Forms.setDataTable(CreateDataTable.fromGenericList(validationXml.forms));
            
            /*tableList_FormBeans.setDataTable(CreateDataTable.fromGenericList(strutsConfigXml.formBeans));
            tableList_GlobalForwards.setDataTable(CreateDataTable.fromDictionary_StringString(strutsConfigXml.globalForwards, "name", "path"));
            tableList_ActionMappings.setDataTable(CreateDataTable.fromGenericList(strutsConfigXml.actionmappings));            */
            //lbDescription.Text = webXml.description;
            //lbDisplayName.Text = webXml.displayName;
            //tableList_Filter.setDataTable(CreateDataTable.fromGenericList(webXml.filters));
            //tableList_FilterMappings.setDataTable(CreateDataTable.fromGenericList(webXml.filterMappings));
            //tableList_Servlets.setDataTable(CreateDataTable.fromGenericList(webXml.servlets));
            //tableList_ServletMappings.setDataTable(CreateDataTable.fromGenericList(webXml.servletMappings));    
        }

        public void refreshTreeView(IValidationXml validationXml)
        {
            lbValidatatorForms.Items.Clear();
            //foreach(var form in validationXml.forms)
            lbValidatatorForms.Items.AddRange(validationXml.forms.ToArray());
            if (lbValidatatorForms.Items.Count > 0)
                lbValidatatorForms.SelectedIndex = 0;
        }



        private void tvMappings_DragEnter(object sender, DragEventArgs e)
        {
            Dnd.setEffect(e);
        }

        private void tvMappings_DragDrop(object sender, DragEventArgs e)
        {
            mapFile(Dnd.tryToGetFileOrDirectoryFromDroppedObject(e));
        }

        private void ascx_J2EE_web_xml_Load(object sender, EventArgs e)
        {
            onLoad();
        }

        private void lbValidatatorForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbValidatatorForms.SelectedItem != null && lbValidatatorForms .SelectedItem is IValidation_Form)
            {
                var validatorForm = (IValidation_Form) lbValidatatorForms.SelectedItem;
                tableList_FormFields.setDataTable(CreateDataTable_Local.fromGenericList(validatorForm.fields.Values.ToList()));
            }
            
        }

        private void _onTableListDrop(DragEventArgs e)
        {
            handleDrop(e);
        }

        private void handleDrop(DragEventArgs e)
        {
            var file = Dnd.tryToGetFileOrDirectoryFromDroppedObject(e);
            mapFile(file);
        }

        private void lbValidatatorForms_DragDrop(object sender, DragEventArgs e)
        {
            handleDrop(e);
        }

        private void lbValidatatorForms_DragEnter(object sender, DragEventArgs e)
        {
            Dnd.setEffect(e);
        }
        
    }
}