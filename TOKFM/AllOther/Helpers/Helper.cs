using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using TOKFM.Model;
using TOKFM.ViewModel.ViewModelPartial;

namespace TOKFM.Helpers
{
    public static class Helper
    {
        public static bool Ping()
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send("8.8.8.8");
                if (reply.Status == IPStatus.Success)
                {
                    pingable = true;
                } 
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
    }
}