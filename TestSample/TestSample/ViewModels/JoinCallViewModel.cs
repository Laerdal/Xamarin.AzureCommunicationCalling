using TestSample.Interfaces;
using TestSample.Model;
using TestSample.Pages;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestSample.ViewModels
{
    public class JoinCallViewModel : BaseViewModel
    {
        public ICommand StartCommand { get; set; }

        public TypeCall _typeCall = TypeCall.Group;
        public TypeCall TypeCalls
        {
            get => _typeCall;
            set { SetProperty(ref _typeCall, value); }
        }
        public bool _teams;
        public bool Teams
        {
            get => _teams;
            set {
                if (value) { TypeCalls = TypeCall.Teams; MeetingValidationEntry(); }
                SetProperty(ref _teams, value); }
        }
        public bool _bot;
        public bool Bot
        {
            get => _bot;
            set
            {
                if (value) { TypeCalls = TypeCall.Bot; MeetingValidationEntry(); }
                SetProperty(ref _bot, value);
            }
        }
        public bool _pstn;
        public bool PSTN
        {
            get => _pstn;
            set
            {
                if (value) { TypeCalls = TypeCall.PSTN; MeetingValidationEntry(); }
                SetProperty(ref _pstn, value);
            }
        }
        public bool _group;
        public bool Group
        {
            get => _group;
            set {
                if (value) { TypeCalls = TypeCall.Group; MeetingValidationEntry(); }
                SetProperty(ref _group, value); }
        }
        public bool _direct;
        public bool Direct
        {
            get => _direct;
            set { if (value) { TypeCalls = TypeCall.Direct; MeetingValidationEntry(); } SetProperty(ref _direct, value); }
        }  
        public bool _meetingValidation;
        public bool MeetingValidation
        {
            get => _meetingValidation;
            set { SetProperty(ref _meetingValidation, value); }
        }
        public string _placeholderExample;
        public string PlaceholderExample
        {
            get => _placeholderExample;
            set { SetProperty(ref _placeholderExample, value); }
        } 
        public string _code;
        public string Code
        {
            get => _code;
            set {  SetProperty(ref _code, value); ValidationJoinMeetingOrDirectCall(); }
        }
        public void MeetingValidationEntry()
        {
            switch (TypeCalls)
            {
                case TypeCall.Teams:
                    Group = false;
                    Direct = false;
                    PSTN = false;
                    Bot = false;
                    Code = "";
                    PlaceholderExample = "ex: https://teams.microsoft.com/l/meetup-join/";
                    break;
                case TypeCall.Group:
                    Teams = false;
                    Direct = false;
                    PSTN = false;
                    Bot = false;
                    Code = "";
                    PlaceholderExample = "ex: 54df4ggdfg6fd4gd2g1d65fg4";
                    break;
                case TypeCall.Direct:
                    Group = false;
                    Teams = false;
                    PSTN = false;
                    Bot = false;
                    Code = "";
                    PlaceholderExample = "ex: 8:acs:876e6017-1032-4f75-9116-c26a738b5aaf_00000012-5a16-d463-69ff-9c3a0d001013";
                    break;
                case TypeCall.Bot:
                    Group = false;
                    Teams = false;
                    Direct = false;
                    PSTN = false;
                    Code = "8:echo123";
                    PlaceholderExample = "ex: 8:echo123";
                    break;
                case TypeCall.PSTN:
                    Group = false;
                    Teams = false;
                    Direct = false;
                    Bot = false;
                    Code = "";
                    PlaceholderExample = "ex: +55 11 943000000";
                    break;
            }

        }
        public void ValidationJoinMeetingOrDirectCall()
        {
            MeetingValidation = false;

            switch (TypeCalls)
            {
                case TypeCall.Teams:
                    if (Code.Contains("https://teams.microsoft.com/l/meetup-join/"))
                    MeetingValidation = true;
                    break;
                case TypeCall.Group:
                    Guid groupIdGuid;
                    var guidValid = Guid.TryParse(Code, out groupIdGuid);
                    if (guidValid)
                        MeetingValidation = true;
                    break;
                case TypeCall.Direct:
                    if (Code.Contains("8:acs:"))
                        MeetingValidation = true;
                    break;
                case TypeCall.PSTN:
                    if (Code.Contains("+"))
                        MeetingValidation = true;
                    break;
                case TypeCall.Bot:
                    if (Code.Contains("8:echo123"))
                        MeetingValidation = true;
                    break;
                default:
                    MeetingValidation = false;
                    break;
            }
        }        
        public JoinCallViewModel()
        {
            Group = true;
            MeetingValidationEntry();
            StartCommand = new Command(Start);
        }
        private async void Start()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SetupPage(new Model.AzureSetupRoom(false, true, TypeCalls, SelectedCamera.Front, TypeSpeaker.Default,"", Code)));

        }
    }
}
