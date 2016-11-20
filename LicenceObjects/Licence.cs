using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doware_LicenceServer.LicenceObjects
{
    [Serializable]
    public class Licence
    {
        public Licence()
        {
            USUARIOS = "0";
            VENCIMENTO = DateTime.Now.AddDays(1);
            ID_CPU = string.Empty;
            ID_CLIENTE = string.Empty;
            ID_CONTRATO = string.Empty;
            ID_INSTALACAO = string.Empty;
        }

        public string ID_CLIENTE { get; set; }

        public string ID_CONTRATO { get; set; }

        public string ID_INSTALACAO { get; set; }

        public string ID_CPU { get; set; }

        public DateTime VENCIMENTO { get; set; }

        public string USUARIOS { get; set; }
    }
}
