using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware.Display;
using Android.Media.Projection;
using Android.Media;
using Android.Opengl;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Azure.Android.Communication.Calling;
using Com.Laerdal.Azurecommunicationhelper;
using Java.Lang;
using Java.Nio;
using Java.Util.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSample.Droid.Implementations.Screensharing
{
    public class FrameGenerator : Java.Lang.Object, IVideoFrameSenderChangedListener, ImageReader.IOnImageAvailableListener
    {
        private VideoFrameSender videoFrameSender;
        private Thread frameIteratorThread;
        private Java.Util.Random random;
        private bool stopFrameIterator = false;
        ImageReader mImageReader;
        public FrameGenerator()
        {
            random = new Java.Util.Random();
        }
        public void FrameIterator()
        {

            ByteBuffer plane = null;
            while (!stopFrameIterator && videoFrameSender != null)
            {

                plane = GenerateFrame(plane);
            }
        }
        private ByteBuffer GenerateFrame(ByteBuffer plane)
        {

            try
            {
                VideoFormat videoFormat = videoFrameSender.VideoFormat;
                if (plane == null || videoFormat.Stride1 * videoFormat.Height != plane.Capacity())
                {

                    plane = ByteBuffer.AllocateDirect(videoFormat.Stride1 * videoFormat.Height);
                    plane.Order(ByteOrder.NativeOrder());
                }

                int bandsCount = random.NextInt(15) + 1;
                int bandBegin = 0;
                int bandThickness = videoFormat.Height * videoFormat.Stride1 / bandsCount;

                for (int i = 0; i < bandsCount; ++i)
                {

                    byte greyValue = (byte)random.NextInt(254);
                    //Wait for android nuget helper publication to add. CallClientHelper.FillFrame(plane, bandBegin, bandBegin + bandThickness, (sbyte)greyValue);
                    bandBegin += bandThickness;
                }
                if (videoFrameSender is SoftwareBasedVideoFrameSender)
                {
                    SoftwareBasedVideoFrameSender sender = (SoftwareBasedVideoFrameSender)videoFrameSender;

                    long timeStamp = sender.TimestampInTicks;
                    //Wait for android nuget helper publication to add. CallClientHelper.ScreensharingVideoFrameSender(sender, plane, timeStamp);
                }
                else
                {
                    HardwareBasedVideoFrameSender sender = (HardwareBasedVideoFrameSender)videoFrameSender;

                    int[] textureIds = new int[1];
                    int targetId = GLES20.GlTexture2d;

                    GLES20.GlEnable(targetId);
                    GLES20.GlGenTextures(1, textureIds, 0);
                    GLES20.GlActiveTexture(GLES20.GlTexture0);
                    GLES20.GlBindTexture(targetId, textureIds[0]);
                    GLES20.GlTexImage2D(targetId,
                            0,
                            GLES20.GlRgb,
                            videoFormat.Width,
                            videoFormat.Height,
                            0,
                            GLES20.GlRgb,
                            GLES20.GlUnsignedByte,
                            plane);

                    long timeStamp = sender.TimestampInTicks;
                    //Wait for android nuget helper publication to add. CallClientHelper.ScreensharingVideoFrameSender(sender, targetId, textureIds, timeStamp);
                };
                Thread.Sleep((long)(1000.0f / videoFormat.FramesPerSecond));
            }
            catch (InterruptedException ex)
            {
                new ConferenceExceptions(ex);
            }
            catch (ExecutionException ex2)
            {
                new ConferenceExceptions(ex2);
            }

            return plane;
        }

        private void StartFrameIterator()
        {

            frameIteratorThread = new Thread(FrameIterator);
            frameIteratorThread.Start();
        }
        public void StopFrameIterator()
        {

            try
            {

                if (frameIteratorThread != null)
                {

                    stopFrameIterator = true;

                    frameIteratorThread.Join();
                    frameIteratorThread = null;

                    stopFrameIterator = false;
                }
            }
            catch (InterruptedException ex)
            {
                new ConferenceExceptions(ex);

            }
        }

        public void OnVideoFrameSenderChanged(VideoFrameSenderChangedEvent p0)
        {
            StopFrameIterator();
            this.videoFrameSender = p0.VideoFrameSender;         
            StartFrameIterator();
        }

        public void OnImageAvailable(ImageReader reader)
        {
            //We are going to use this feature to send our screen frames to the application,
            //I am analyzing the possible possibilities for the best implementation of this.
            Image image = reader.AcquireLatestImage();
            if (image != null)
            {

                var planes = image.GetPlanes();
                if (planes.Length > 0)
                {

                    Image.Plane plane = planes[0];
                    var buffer = plane.Buffer;
                    try
                    {

                        SoftwareBasedVideoFrameSender sender = (SoftwareBasedVideoFrameSender)videoFrameSender;
                        //Wait for android nuget helper publication to add. CallClientHelper.ScreensharingVideoFrameSender(sender, buffer, sender.TimestampInTicks);
                    }
                    catch (System.Exception ex)
                    {
                        new ConferenceExceptions(ex);

                    }
                }
                image.Close();
            }
        }
    }

}