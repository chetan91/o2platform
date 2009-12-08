// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2.Core.FileViewers.Ascx.O2Rules;
using O2.Core.FileViewers.Struts_1_5;
using O2.Kernel;
using System.Threading;
using O2.ImportExport.OunceLabs.Ozasmt_OunceV6;
using O2.DotNetWrappers.O2Findings;
using O2.DotNetWrappers.DotNet;
using O2.Kernel.Interfaces.O2Findings;
using O2.Kernel.Interfaces.O2Core;
using O2.Kernel.Interfaces.Views;
using O2.Kernel.Interfaces.XRules;
using O2.Kernel.Interfaces.FrameworkSupport.J2EE;
using O2.Core.FileViewers.Ascx;
using O2.External.WinFormsUI.Forms;


namespace O2.XRules.Database._Rules
{
    public class XUtils_Struts_v0_1: KXRule
    {
        static IO2Log  log = PublicDI.log;
    	
        public XUtils_Struts_v0_1()
        {
            Name = "XRule Utils (to help with Stuts analysis) v0.1";
        }

        [XRule(Name="Show web config")]
        public static string showWebXml(List<String> files)
        {
            if (files!= null)
            {
                log.debug("There are  files available: {0}", files.Count.ToString());
                foreach(var file in files)
                {
                    if (Path.GetFileName(file) == "web.xml")
                    {
                        showWebXml(file);
                        break;
                    }
                }        			        		
            }
            else
                log.error("files was null");
            return "all done...";
        }
        
        public static void showWebXml(string file)
        {
            var control = (ascx_J2EE_web_xml)O2AscxGUI.openAscx(typeof(ascx_J2EE_web_xml), O2DockState.Float, "web.xml");
            control.mapFile(file);        				
        }
        
        public static void showStrutsConfigXml(string file)
        {
            var control = (ascx_Struts_config_xml)O2AscxGUI.openAscx(typeof(ascx_Struts_config_xml), O2DockState.Float, "struts-config.xml");
            control.mapFile(file);        				
        }
        
        public static void showTilesDefinitionXml(string file)
        {
            var control = (ascx_TilesDefinition_xml)O2AscxGUI.openAscx(typeof(ascx_TilesDefinition_xml), O2DockState.Float, "diles-definition.xml");
            control.mapFile(file);        				
        }

        public static void showValidationXml(string file)
        {
            var control = (ascx_Validation_xml)O2AscxGUI.openAscx(typeof(ascx_Validation_xml), O2DockState.Float, "validation.Xml");
            control.mapFile(file);
        }

        public static void showStrutsMappingFileXml(string file)
        {
            var control = (ascx_StrutsMappings)O2AscxGUI.openAscx(typeof(ascx_StrutsMappings), O2DockState.Float, "Struts Mapping File");
            control.loadO2StrutsMappingFile(file);
        }

        public static void showStrutsMappings(IStrutsMappings strutsMappings)
        {
            var control = (ascx_StrutsMappings)O2AscxGUI.openAscx(typeof(ascx_StrutsMappings), O2DockState.Float, "Struts Mapping File");
            control.loadStrutsMappings(strutsMappings);
        }

        public static void calculateAndShowStrutsMappings(string webXmlFile, string strutsConfigFile, string tilesDefinitionsFile, string validationXmlFile)
        {
            var strutsMappings = StrutsMappingsHelpers.calculateStrutsMapping(webXmlFile, strutsConfigFile,
                                                                                 tilesDefinitionsFile, validationXmlFile);
            showStrutsMappings(strutsMappings);
        }

        public static string calculateAndSaveStrutsMappings(string targetFileOrFolder, string webXmlFile, string strutsConfigFile, string tilesDefinitionsFile, string validationXmlFile)
        {
            var strutsMappings = StrutsMappingsHelpers.calculateStrutsMapping(webXmlFile, strutsConfigFile,
                                                                              tilesDefinitionsFile, validationXmlFile);
            return StrutsMappingsHelpers.saveStrutsMappings(strutsMappings, targetFileOrFolder);
        }


        public static IStrutsMappings loadStrutsMappingsFromFile(string strutsMappingsFile)
        {
            return (IStrutsMappings)Serialize.getDeSerializedObjectFromBinaryFile(strutsMappingsFile, typeof(KStrutsMappings));
        }
    }
}
