﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAdvices.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TestAdvices.Resources.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Advices.
        /// </summary>
        internal static string Advices {
            get {
                return ResourceManager.GetString("Advices", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are {0} active advices.
        /// </summary>
        internal static string AdvicesMultiActive {
            get {
                return ResourceManager.GetString("AdvicesMultiActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no active advices.
        /// </summary>
        internal static string AdvicesNoneActive {
            get {
                return ResourceManager.GetString("AdvicesNoneActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is one active advice.
        /// </summary>
        internal static string AdvicesOneActive {
            get {
                return ResourceManager.GetString("AdvicesOneActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ComboxboxArrow {
            get {
                object obj = ResourceManager.GetObject("ComboxboxArrow", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Active.
        /// </summary>
        internal static string StateActive {
            get {
                return ResourceManager.GetString("StateActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Inactive.
        /// </summary>
        internal static string StateInActive {
            get {
                return ResourceManager.GetString("StateInActive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting.
        /// </summary>
        internal static string StateStarting {
            get {
                return ResourceManager.GetString("StateStarting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stopping.
        /// </summary>
        internal static string StateStopping {
            get {
                return ResourceManager.GetString("StateStopping", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap T_client {
            get {
                object obj = ResourceManager.GetObject("T_client", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
