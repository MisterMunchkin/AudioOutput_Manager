﻿using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AudioOutput_Manager.Utility
{
    public class CoreAudioProcesses
    {
        private CoreAudioController coreAudioController;
        public List<CoreAudioDevice> coreAudioDeviceList;

        public CoreAudioProcesses()
        {
            this.coreAudioController = new CoreAudioController();
            this.coreAudioDeviceList = this.coreAudioController.GetPlaybackDevices().ToList();
        }

        public CoreAudioDevice GetCoreAudioDevice(string id)
        {
            Guid guid = new Guid(id);

            CoreAudioDevice result = coreAudioDeviceList.Find(a => a.Id.Equals(guid));
            return result;
        }

        public bool SetDefaultDevice(CoreAudioDevice device)
        {
            return coreAudioController.SetDefaultDevice(device);
        }

        public void ActivateDefaultSettings()
        {
            if (Properties.Settings.Default.CycledList == null)
            {
                Properties.Settings.Default.CycledList = new List<string>();
            }
            else if (Properties.Settings.Default.CycledList.Count > 0)
            {
                string defaultAudio = Properties.Settings.Default.CycledList[Properties.Settings.Default.SelectedCycledIndex];

                var defaultAudioArray = defaultAudio.Split(',');

                Guid guid = new Guid(defaultAudioArray[0]);

                CoreAudioDevice defaultCoreAudioDevice = coreAudioDeviceList.Find(a => a.Id.Equals(guid));

                coreAudioController.SetDefaultDevice(defaultCoreAudioDevice);
            }
        }
    }
}