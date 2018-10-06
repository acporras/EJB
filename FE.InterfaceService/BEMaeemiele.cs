using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.InterfaceService
{
    public partial class BEMaeemiele
    {
        public BEMaeemiele()
        {

        }

        public int? nid_maeemiele { get; set; }
        public string nu_eminumruc { get; set; }
        public string co_emicodane { get; set; }
        public string no_bastipbas { get; set; }
        public string no_basnomsrv { get; set; }
        public string no_basnombas { get; set; }
        public string no_basusrbas { get; set; }
        public string no_basusrpas { get; set; }
        public DateTime? fe_regcreaci { get; set; }
        public DateTime? fe_regmodifi { get; set; }
        public string fl_reginacti { get; set; }
    }

    public partial class ListBEMaeemiele : List<BEMaeemiele>
    {

    }
}