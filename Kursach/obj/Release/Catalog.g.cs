﻿#pragma checksum "..\..\Catalog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49C43E0B8AEF6EB71FFAA047EC54CCA0DFB7DBC24A4C922948A30446160BBCF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursach;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Kursach {
    
    
    /// <summary>
    /// Catalog
    /// </summary>
    public partial class Catalog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_classic;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_phycological;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_child;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_business;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Catalog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_hand_craft;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kursach;component/catalog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Catalog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.B_classic = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Catalog.xaml"
            this.B_classic.Click += new System.Windows.RoutedEventHandler(this.B_classic_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.B_phycological = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Catalog.xaml"
            this.B_phycological.Click += new System.Windows.RoutedEventHandler(this.B_phycological_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.B_child = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Catalog.xaml"
            this.B_child.Click += new System.Windows.RoutedEventHandler(this.B_child_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.B_business = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Catalog.xaml"
            this.B_business.Click += new System.Windows.RoutedEventHandler(this.B_business_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.B_hand_craft = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Catalog.xaml"
            this.B_hand_craft.Click += new System.Windows.RoutedEventHandler(this.B_hand_craft_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

