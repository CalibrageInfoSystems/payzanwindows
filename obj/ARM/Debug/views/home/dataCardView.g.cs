﻿

#pragma checksum "D:\Work\v1_payzan\views\home\dataCardView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "083BF54F6865C7CF432527FC192C6938"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayZan.views.home
{
    partial class dataCardView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 42 "..\..\..\..\views\home\dataCardView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Image_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 54 "..\..\..\..\views\home\dataCardView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.text_datacardnumber_KeyDown;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 79 "..\..\..\..\views\home\dataCardView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Recharge_btn_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 63 "..\..\..\..\views\home\dataCardView.xaml"
                ((global::Windows.UI.Xaml.Controls.ListPickerFlyout)(target)).ItemsPicked += this.datacardlist_ItemsPicked;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


