// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using O2.Kernel;
using O2.Kernel.Interfaces.O2Core;
using O2.Kernel.Interfaces.DotNet;
using O2.DotNetWrappers.DotNet;
using O2.DotNetWrappers.Windows;
using O2.Core.CIR.Ascx.DotNet;
using O2.Views.ASCX;
using O2.Views.ASCX.MerlinWizard;
using O2.Views.ASCX.MerlinWizard.O2Wizard_ExtensionMethods;
//O2Tag_AddReferenceFile:merlin.dll
using Merlin;
using MerlinStepLibrary;
//O2Tag_AddReferenceFile:nunit.framework.dll
using NUnit.Framework; 
//O2_File:C:\O2\O2 - All Active Projects\O2 - All Active Projects\O2Core\O2_DotNetWrappers\DotNet\GacUtils.cs
//O2_File:C:\O2\O2 - All Active Projects\O2 - All Active Projects\O2Core\O2_DotNetWrappers\DI.cs

//O2File:C:\O2\O2 - All Active Projects\O2 - All Active Projects\O2Core\O2_Views_ASCX\MerlinWizard\MerlinWizard_ExtensionMethods_2.cs

namespace O2.Script
{
	[TestFixture]
    public class Wizard_CopyGacDlls
    {    
    	
    	private static IO2Log log = PublicDI.log;
    	string defaultFilter = "Web";		
		string targetFolder = Path.Combine(PublicDI.config.O2TempDir,"_DllsFromGac"); 
		bool deleteFilesFromTargetFolder = false;
		
		[Test]
		public void runWizard()
		{			
			var o2Wizard = new O2Wizard("Copy GAC Assemblies");			
									
			// step 1
			o2Wizard.Steps.add_Control(typeof(ascx_GAC_Browser),"Select GAC Assemblies to Copy","Gac Browser", onStepLoad);			
			// step 2
			o2Wizard.Steps.add_Action("Confirm GAC Dlls to Copy", showListOfAssembliesToCopy);
			// step 3
			var selectFolderStep = o2Wizard.Steps.add_SelectFolder("Select folder to copy files", targetFolder, (newValue) => targetFolder = newValue);
			selectFolderStep.add_CheckBox("Delete files from target folder?", deleteFilesFromTargetFolder, (newValue)=> deleteFilesFromTargetFolder = newValue);			
			// step 4
			o2Wizard.Steps.add_Action("Copying files to target folder", copyFilesToTargetFolder);
			// step 5
			o2Wizard.Steps.add_Directory("Target Folder Contents", targetFolder);
			
			o2Wizard.start(); 					
		
		/*	var gacDlls = GacUtils.currentGacAssemblies();
			foreach(var gacDll in gacDlls)
				log.debug("  -  {0}", gacDll.name);
			return "done";*/
		}
		
		public void onStepLoad(IStep step)
		{
			var gacBrowser = (ascx_GAC_Browser)step.Controller.steps[0].FirstControl;			
			gacBrowser.loadListOfGacAssemblies();
							
			gacBrowser.setGacAssemblyFilter(defaultFilter);
		}
		
		public void showListOfAssembliesToCopy(IStep step)
		{			
			var message = new StringBuilder();
			message.AppendLine(String.Format("There are {0} assemblies to copy", getAssembliesToCopy(step).Count));	
			message.AppendLine(" ");
			foreach(var gacDll in getAssembliesToCopy(step))
				message.AppendLine(String.Format("  - {0}   \t\t\t\t ->  {1}", gacDll, gacDll.fullPath));
			step.set_Text(message.ToString());
		}
            
        public void copyFilesToTargetFolder(IStep step)
        {        
        	O2Thread.mtaThread(
        	()=> {
        		step.set_Text("");
	       		var gacDlls = getAssembliesToCopy(step);
	        	var message = string.Format("Copying {0} files to {1}", gacDlls.Count,targetFolder);
	        	step.append_Line(message);
	        	if(false == Directory.Exists(targetFolder))
	        	{
	        		step.append_Line("Creating folder: " +  targetFolder);
	        		Directory.CreateDirectory(targetFolder);
	        	}
	        	else
		        	if (deleteFilesFromTargetFolder)
		        	{
	        			step.append_Line("Deleting all files from folder: " +  targetFolder);
	        			Files.deleteAllFilesFromDir(targetFolder);
	        		}	
	        	foreach(var gacDll in gacDlls)
	        	{
	        		step.append_Line(".. copying file: {0}", gacDll.fullPath);
	        		Files.Copy(gacDll.fullPath,targetFolder);
	        	}
	        	step.append_Line(" ");
	        	step.append_Line("Copy complete");
	        });
        	
        }
        
            
        public List<IGacDll> getAssembliesToCopy(IStep step)
        {
        	var gacBrowser = (ascx_GAC_Browser)step.Controller.steps[0].FirstControl;
			return gacBrowser.getListOfCurrentFilteredAssemblies();
        }
    }
}
