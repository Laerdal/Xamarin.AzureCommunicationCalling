using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Azure.Android.Communication.Calling
{
    public partial class CallClient
    {
        // These methods in the original lib used the RetroFuture library which I was unable to bind in Xamarin
        // The whole purpose of RetroFuture is to be a backwards compatible replacement for javas Future.
        // This hack just maps the methods we need to the "real"(not backwards compatible) java interface,
        // Caveat: this makes lowest supported SDK 24(Android 7)
        // Is this really a problem? I dont think there are many android 6 and lower capable of
        // running ACS anyway...

        // Metadata.xml XPath method reference: path="/api/package[@name='com.azure.android.communication.calling']/class[@name='CallClient']/method[@name='createCallAgent' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='com.azure.android.communication.common.CommunicationTokenCredential']]"
        [Register("createCallAgent", "(Landroid/content/Context;Lcom/azure/android/communication/common/CommunicationTokenCredential;)Ljava9/util/concurrent/CompletableFuture;", "")]
        public unsafe global::Java.Util.Concurrent.CompletableFuture CreateCallAgentAsync(global::Android.Content.Context appContext, global::Com.Azure.Android.Communication.Common.CommunicationTokenCredential communicationTokenCredential)
        {
            const string __id = "createCallAgent.(Landroid/content/Context;Lcom/azure/android/communication/common/CommunicationTokenCredential;)Ljava/util/concurrent/CompletableFuture;";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[2];
                __args[0] = new JniArgumentValue((appContext == null) ? IntPtr.Zero : ((global::Java.Lang.Object)appContext).Handle);
                __args[1] = new JniArgumentValue((communicationTokenCredential == null) ? IntPtr.Zero : ((global::Java.Lang.Object)communicationTokenCredential).Handle);
                var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
                return global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.CompletableFuture>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
            }
            finally
            {
                global::System.GC.KeepAlive(appContext);
                global::System.GC.KeepAlive(communicationTokenCredential);
            }
        }
    }
}
