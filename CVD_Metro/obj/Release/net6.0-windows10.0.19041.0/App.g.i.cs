﻿#pragma checksum "..\..\..\App.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CE0E5C6635BA29BEA4B847C7E8776E0B0413507"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CVD {
    
    
    /// <summary>
    /// App
    /// </summary>
    public partial class App : System.Windows.Application {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            
            #line 5 "..\..\..\App.xaml"
            this.Startup += new System.Windows.StartupEventHandler(this.OnStartup);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\App.xaml"
            this.Exit += new System.Windows.ExitEventHandler(this.OnExit);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\App.xaml"
            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(this.OnDispatcherUnhandledException);
            
            #line default
            #line hidden
            System.Uri resourceLocater = new System.Uri("/CVD;V1.0.0.0;component/app.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\App.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public static void Main() {
            CVD.App app = new CVD.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}

