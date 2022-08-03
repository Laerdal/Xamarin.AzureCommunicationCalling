using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace TestSample.UWP.Implementations
{
    public class StatusBarWindows
    {
        public void HideStatusBar()
        {
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }

        public void ShowStatusBar()
        {
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().ExitFullScreenMode();
        }
    }
}
