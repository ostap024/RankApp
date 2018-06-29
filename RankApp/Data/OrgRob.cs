using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankApp.Data
{
    public class OrgRob
    {
        public int Id { get; set; }
        public double? OrgZagalUniverZahid { get; set; }
        public bool OrgZagalUniverZahidBool { get; set; } = false;

        public double? OrgKafedraZahid { get; set; }
        public bool OrgKafedraZahidBool { get; set; } = false;
        public double? ProvedennyaBesid { get; set; }
        public bool ProvedennyaBesidBool { get; set; } = false;
        public double? OrganizaciaEkskurs { get; set; }
        public bool OrganizaciaEkskursBool { get; set; } = false;
        public double? RozrobkaMaterialivZahid { get; set; }
        public bool RozrobkaMaterialivZahidPhotoBool { get; set; } = false;
        public bool RozrobkaMaterialivZahidVideoBool { get; set; } = false;
        public bool RozrobkaMaterialivZahidPrezentaciaBool { get; set; } = false;
        public double? RobotaVchenaRada { get; set; }
        public bool RobotaVchenaRadaGolovaBool { get; set; } = false;
        public bool RobotaVchenaRadaSekretarBool { get; set; } = false;
        public bool RobotaVchenaRadaClenBool { get; set; } = false;
        public double? KerivnukKafedra { get; set; }
        public bool KerivnukKafedraBool { get; set; } = false;
        public double? ObovjazokKafedra { get; set; }
        public bool ObovjazokKafedraZastupnikBool { get; set; } = false;
        public bool ObovjazokKafedraSekretarBool { get; set; } = false;
        public double? RobotaTrudKolektiv { get; set; }
        public bool RobotaTrudKolektivGolovaBool { get; set; } = false;
        public bool RobotaTrudKolektivZastupnikBool { get; set; } = false;
        public bool RobotaTrudKolektivSekretarBool { get; set; } = false;
        public bool RobotaTrudKolektivClenBool { get; set; } = false;
        public double? RobotaRevizia { get; set; }
        public bool RobotaReviziaGolovaBool { get; set; } = false;
        public bool RobotaReviziaZastupnikBool { get; set; } = false;
        public bool RobotaReviziaSekretarBool { get; set; } = false;
        public double? UchastProfOrient { get; set; }
        public bool UchastProfOrientBool { get; set; } = false;
        public double? SekretarPrijomKomis { get; set; }
        public bool SekretarPrijomKomisBool { get; set; } = false;
        public double? SekretarNaukMetodSeminar { get; set; }
        public double? SekretarNaukMetodSeminarNZasid { get; set; }
        public double? PidtrumkaWEB { get; set; }
        public bool PidtrumkaWEBBool { get; set; } = false;
        public double? ZasidannyaKafedra { get; set; }
        public double? ZasidannyaKafedraNZasid { get; set; }
        public double? EstetKaredra { get; set; }
        public bool EstetKaredraBool { get; set; } = false;
        public double? Sum { get; set; }
        public string PIB { get; set; }
        public string User { get; set; }
    }
}
