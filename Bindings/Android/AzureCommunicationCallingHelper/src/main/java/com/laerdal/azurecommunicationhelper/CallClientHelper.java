package com.laerdal.azurecommunicationhelper;

import android.content.Context;
import com.azure.android.communication.calling.Call;
import com.azure.android.communication.calling.CallAgent;
import com.azure.android.communication.calling.CallClient;
import com.azure.android.communication.calling.Call;
import com.azure.android.communication.calling.CallAgent;
import com.azure.android.communication.calling.CallAgentOptions;
import com.azure.android.communication.calling.CallClient;
import com.azure.android.communication.calling.DeviceManager;
import com.azure.android.communication.calling.HangUpOptions;
import com.azure.android.communication.calling.LocalVideoStream;
import com.azure.android.communication.calling.StartCallOptions;
import com.azure.android.communication.calling.VideoDeviceInfo;
import com.azure.android.communication.common.CommunicationIdentifier;
import com.azure.android.communication.common.CommunicationTokenCredential;

import java.util.List;
import java.util.concurrent.ExecutionException;

public class CallClientHelper {
    public static CallAgent GetCallAgent(
            CallClient callClient,
            Context context,
            CommunicationTokenCredential credentials) throws ExecutionException, InterruptedException {
        return callClient.createCallAgent(context, credentials).get();
    }
    public static CallAgent GetCallAgent(
            CallClient callClient,
            Context context,
            CommunicationTokenCredential credentials,
            CallAgentOptions callAgentOptions) throws ExecutionException, InterruptedException {
        return callClient.createCallAgent(context, credentials, callAgentOptions).get();
    }
    public static void HangUp(Call call, HangUpOptions options) throws ExecutionException, InterruptedException {
        call.hangUp(options).get();
    }
    public static Call Call(
            CallAgent callAgent,
            Context context,
            List<CommunicationIdentifier> participants,
            StartCallOptions startCallOptions) {
        return callAgent.startCall(context, participants, startCallOptions);
    }
    public static DeviceManager GetDeviceManager(
            CallClient callClient,
            Context context
    ) throws ExecutionException, InterruptedException {
        return callClient.getDeviceManager(context).get();
    }
    public static void Mute(Call call, Context context) throws ExecutionException, InterruptedException {
        call.mute(context).get();
    }
    public static void UnMute(Call call, Context context) throws ExecutionException, InterruptedException {
        call.unmute(context).get();
    }
    public static void SwitchCameraSource(LocalVideoStream localVideoStream, VideoDeviceInfo camera) throws ExecutionException, InterruptedException {
        localVideoStream.switchSource(camera).get();
    }    
    public static void StartVideo(Call call, LocalVideoStream localVideoStream, Context context) throws ExecutionException, InterruptedException {
        call.startVideo(context, localVideoStream).get();
    }
    public static void StopVideo(Call call, LocalVideoStream localVideoStream, Context context) throws ExecutionException, InterruptedException {
        call.stopVideo(context, localVideoStream).get();
    }
}

