using AzureSample.Interfaces;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace AzureSample.UWP.Services
{
    public class IncommingNotificationService
    {
        IConferenceManagerSpecificPlatform _conferenceManagerSpecificPlatform = ContainerDependencyInjectionService.GetService<IConferenceManagerSpecificPlatform>();
        private async void Toast_Activated(ToastNotification sender, object obj)
        {
            var startpushvoip = new Action<object>(async delegate (object e)
            {
                ToastActivatedEventArgs args = (ToastActivatedEventArgs)e;

                switch (args.Arguments)
                {
                    case VoipConstants.DeclineConferenceWindows:
                        await _conferenceManagerSpecificPlatform.RejectAsync();
                        break;
                    case VoipConstants.AcceptConferenceWindows:
                        await _conferenceManagerSpecificPlatform.AcceptAsync();
                        break;
                    default:
                        Remove(VoipConstants.RemoveNotificationConferenceWindows);
                        break;
                };
                //Remove(VoipConstants.RemoveNotificationConferenceWindows);
            });
            startpushvoip.Invoke(obj);
        }
        public void Remove(string tag)
        {
            ToastNotificationManagerCompat.History.Remove(tag);
        }
        public void Send()
        {
            var toastbuilder = new ToastContentBuilder();
            var toastNotifierCompat = ToastNotificationManagerCompat.CreateToastNotifier();
            string text = "Incoming Voice Call";
            toastbuilder
                .AddText(text);
            toastbuilder
                .AddText("Call from desktop");
            toastbuilder
                .AddButton(new ToastButton()
                .SetContent("Accept")
                .AddArgument(VoipConstants.AcceptConferenceWindows))
                .AddButton(new ToastButton()
                .SetContent("Decline")
                .AddArgument(VoipConstants.DeclineConferenceWindows));
            toastbuilder
                .SetToastScenario(ToastScenario.IncomingCall)
                .AddToastActivationInfo(null, ToastActivationType.Foreground);
            var toastXml = toastbuilder.Content.GetXml();
            ToastNotification toast = new ToastNotification(toastXml)
            {
                Priority = ToastNotificationPriority.High,
                Tag = VoipConstants.RemoveNotificationConferenceWindows,
            };
            toastNotifierCompat.Show(toast);
            toast.Activated += Toast_Activated;
            toast.Dismissed += Toast_Dismissed;
        }

        private async void Toast_Dismissed(ToastNotification sender, ToastDismissedEventArgs args)
        {
            switch (args.Reason)
            {
                case ToastDismissalReason.UserCanceled:
                    await _conferenceManagerSpecificPlatform.RejectAsync();
                    ToastNotificationManagerCompat.History.Remove(sender.Tag);
                    break;
                case ToastDismissalReason.ApplicationHidden:
                    ToastNotificationManagerCompat.History.Remove(sender.Tag);

                    break;
                case ToastDismissalReason.TimedOut:
                    break;
                default:
                    break;
            }
        }
    }
    public static class VoipConstants
    {
        public const string AcceptConferenceWindows = "ACCEPT_INCOMING_CONFERENCE";
        public const string DeclineConferenceWindows = "DECLINE_INCOMING_CONFERENCE";
        public const string RemoveNotificationConferenceWindows = "REMOVE_NOTIFICATION_CONFERENCE";
        public const string RemoveNotificationConferenceMissedWindows = "REMOVE_NOTIFICATION_CONFENRENCE_MISSED";

    }
}
