using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AzureCommunicationVideoTest
{
    public class PermissionService
    {

        public PermissionService()
        {
        }

        public async Task<bool> CheckAndAskForCameraPermission()
        {
            return await CheckAndAskPermission<Permissions.Camera>();
        }
        public async Task<bool> CheckAndAskForMicrophonePermission()
        {
            return await CheckAndAskPermission<Permissions.Microphone>();
        }
        public async Task<bool> CheckAndAskForLocationPermission()
        {
            return await CheckAndAskPermission<Permissions.LocationWhenInUse>();
        }
        
        private async Task<bool> CheckAndAskPermission<T>() where T : Permissions.BasePermission, new()
        {
            var status = await Permissions.CheckStatusAsync<T>();
            // If we have access we are finished
            if (status == PermissionStatus.Granted) return true;
            
            status = await Permissions.RequestAsync<T>();
            var hasPermission = status == PermissionStatus.Granted;

            return hasPermission;
        }

    }
}