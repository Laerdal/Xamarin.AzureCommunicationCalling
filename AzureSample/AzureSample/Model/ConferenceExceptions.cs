using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSample
{
    public class ConferenceExceptions: Exception
    {
        public ConferenceExceptions(Exception ex) 
        {
           // Crashes.TrackError(ex);
        }
    }
}
