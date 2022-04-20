using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PayZan.Helpers
{
    public class SuspensionManager
    {
        
            public static void RegisterFrame(Frame rootFrame, string v)
            {

            }
            private void CreateRootFrame()
            {
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null)
                {
                    rootFrame = new Frame();
                    SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
                    Window.Current.Content = rootFrame;
                }
            }

            public static Task SaveAsync()
            {
                throw new NotImplementedException();
            }

            public static Task RestoreAsync()
            {
                throw new NotImplementedException();
            }
        }
    }

