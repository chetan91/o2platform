﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WatiN.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WatiN.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Collection is read-only.
        /// </summary>
        internal static string BaseComponentCollection_CollectionIsReadonly {
            get {
                return ResourceManager.GetString("BaseComponentCollection_CollectionIsReadonly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Collection does not support searching by equality..
        /// </summary>
        internal static string BaseComponentCollection_DoesNotSupportSearchingByEquality {
            get {
                return ResourceManager.GetString("BaseComponentCollection_DoesNotSupportSearchingByEquality", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The control has already been initialized..
        /// </summary>
        internal static string Control_HasAlreadyBeenInitialized {
            get {
                return ResourceManager.GetString("Control_HasAlreadyBeenInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Closing IE instance.
        /// </summary>
        internal static string IE_Dispose {
            get {
                return ResourceManager.GetString("IE_Dispose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The page type is expected to be a subclass of Page..
        /// </summary>
        internal static string PageMetadata_PageTypeIsExpectedToBeASubclassOfPage {
            get {
                return ResourceManager.GetString("PageMetadata_PageTypeIsExpectedToBeASubclassOfPage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A match operation has been aborted because it appeared to be re-entrant.  The exception occurred in an instance of &apos;{0}&apos; with constraint: {1}..
        /// </summary>
        internal static string ReEntryException_MessageFormat {
            get {
                return ResourceManager.GetString("ReEntryException_MessageFormat", resourceCulture);
            }
        }
    }
}