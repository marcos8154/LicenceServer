using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doware_LicenceServer.LicenceObjects
{
    [Serializable]
    public class LicenceUser
    {
        public int ID { get; set; }

        public string NAME { get; set; }

        public bool ACTIVE { get; set; }
    }
}
