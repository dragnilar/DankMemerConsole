using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DankMemerConsole.Messages
{
    public class CooldownMessage
    {
        public string CommandOnCooldownName { get; set; }

        public CooldownMessage(string cooldownName)
        {
            CommandOnCooldownName = cooldownName;
        }
    }
}
