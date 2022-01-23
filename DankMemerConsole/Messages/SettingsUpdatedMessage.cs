using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DankMemerConsole.Messages
{
    public class SettingsUpdatedMessage
    {
        public bool SettingsUpdated { get; set; }

        public SettingsUpdatedMessage()
        {
            SettingsUpdated = true;
        }
    }

}
