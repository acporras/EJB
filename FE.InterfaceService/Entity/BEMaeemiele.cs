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
        public string no_emirazsoc { get; set; }
        public string co_emicodage { get; set; }
        public string no_estemiele { get; set; }
        public string no_conemiele { get; set; }
        public string no_emiubigeo { get; set; }
        public string no_emidepart { get; set; }
        public string no_emiprovin { get; set; }
        public string no_emidistri { get; set; }
        public string no_emidirfis { get; set; }
        public string no_bastipbas { get; set; }
        public string no_basnomsrv { get; set; }
        public string no_basnombas { get; set; }
        public string no_basusrbas { get; set; }
        public string no_basusrpas { get; set; }
        public string no_tabfaccab { get; set; }
        public string no_tabfacdet { get; set; }
        public string no_rutcerdig { get; set; }
        public string no_ususolsun { get; set; }
        public string no_passolsun { get; set; }
        public int nid_cfgseremi { get; set; }
        public DateTime? fe_regcreaci { get; set; }
        public DateTime? fe_regmodifi { get; set; }
        public string fl_reginacti { get; set; }
    }

    public partial class ListBEMaeemiele : List<BEMaeemiele>
    {

    }
}