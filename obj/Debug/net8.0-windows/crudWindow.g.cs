﻿#pragma checksum "..\..\..\crudWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D9C62D9B0DD1F3C350CF42DED472665DC3D42228"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using crud;


namespace crud {
    
    
    /// <summary>
    /// crudWindow
    /// </summary>
    public partial class crudWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\crudWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox costumerList;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\crudWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox orderList;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\crudWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox allOrdersList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/crud;component/crudwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\crudWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\crudWindow.xaml"
            ((crud.crudWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.windowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.costumerList = ((System.Windows.Controls.ListBox)(target));
            
            #line 29 "..\..\..\crudWindow.xaml"
            this.costumerList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.costumerListSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.orderList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.allOrdersList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            
            #line 35 "..\..\..\crudWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteButton);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\..\crudWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.createCostumerButton);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 37 "..\..\..\crudWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.createOrderButton);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\..\crudWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Disconnect);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

