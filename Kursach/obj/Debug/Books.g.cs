﻿#pragma checksum "..\..\Books.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A0DEE9BD03667CAFC4A289A01D1F4270DF64922C6AC9A7A53BC0FCC3F991C14C"
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
    /// Books
    /// </summary>
    public partial class Books : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_cat;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortingBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock c1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock c2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock c3;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock c4;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox CatalogItems;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBar;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BasketButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Kursach;component/books.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Books.xaml"
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
            this.B_cat = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Books.xaml"
            this.B_cat.Click += new System.Windows.RoutedEventHandler(this.B_cat_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SortingBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\Books.xaml"
            this.SortingBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortingBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.c1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.c2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.c3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.c4 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.CatalogItems = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\Books.xaml"
            this.CatalogItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CatalogItems_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SearchBar = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\Books.xaml"
            this.SearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBar_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BasketButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\Books.xaml"
            this.BasketButton.Click += new System.Windows.RoutedEventHandler(this.BasketButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

