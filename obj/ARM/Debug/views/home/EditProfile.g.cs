﻿

#pragma checksum "D:\Work\v1_payzan\views\home\EditProfile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "23A2DE8CAB2C2C203F7F347FC1E71C23"
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
    partial class EditProfile : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 30 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Image_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 35 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.editname_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 37 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.text_firstname_KeyDown;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 51 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.text_displayname_KeyDown;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 57 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.selectDate_DateChanged;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 101 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.save_btn_Click;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 91 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Checked += this.RadioButton_Checked;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 75 "..\..\..\..\views\home\EditProfile.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Checked += this.RadioButton_Checked;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

