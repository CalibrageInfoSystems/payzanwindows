

#pragma checksum "D:\Work\v1_payzan\views\home\mobileRechargeView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8097B3BC937260A04A9950D139AC9B07"
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
    partial class mobileRechargeView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 41 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Image_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 49 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.Edit_Mobilenumber_KeyDown;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 78 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.contact_img_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 82 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.recharge_btn_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 92 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.talktime_btn_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 93 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.specilrecharge_btn_Click;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 60 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.Controls.ListPickerFlyout)(target)).ItemsPicked += this.serviceList_ItemsPicked;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 47 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Checked += this.RadioButton_Checked;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 44 "..\..\..\..\views\home\mobileRechargeView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Checked += this.RadioButton_Checked;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


