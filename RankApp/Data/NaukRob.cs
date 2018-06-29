using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankApp.Data
{
    public class NaukRob
    {
        public int Id { get; set; }
        public double? PidgotovkaMijnarodGrant { get; set; }//на усіх авторів
        public double? PidgotovkaMONGrant { get; set; }//на усіх авторів
        public double? PidgotovkaSpilnProekt { get; set; }//на усіх авторів
        public double? PidgotovkaNDR { get; set; }//на усіх авторів
        public double? StajZakordonVNZ { get; set; }
        public double? StajZakordonVNZNDniv { get; set; }
        public double? ZahistDoktor { get; set; }
        public bool ZahistDoktorBool { get; set; } = false;
        public double? ZahistKandidat { get; set; }
        public bool ZahistKandidatBool { get; set; } = false;
        public double? VidannyaMonografy { get; set; }//на усіх авторів
        public double? RecenzMonografy { get; set; }
        public double? RecenzMonografyNStor { get; set; }
        public double? StattyaScopusAngl { get; set; }//на усіх авторів
        public double? StattyaScopusUkr { get; set; }//на усіх авторів
        public double? StattyaMijnarodZakordon { get; set; }//на усіх авторів
        public double? StattyaMijnarodVitch { get; set; }//на усіх авторів
        public double? StattyaNeMignarod { get; set; }//на усіх авторів
        public double? VidannyaFahUkr { get; set; }//на усіх авторів
        public double? VidannyaNeFahUkr { get; set; }//на усіх авторів

        public double? MaterialScopus { get; set; }//на усіх авторів
        public double? MaterialMijnNeScopus { get; set; }//на усіх авторів
        public double? MaterialUkrNeScopus { get; set; }//на усіх авторів
        public double? TezMijn { get; set; }//на усіх авторів
        public double? TezUkr { get; set; }//на усіх авторів

        public double? DopovidMijnarod { get; set; }//на усіх авторів
        public double? DopovidUkr { get; set; }//на усіх авторів
        public double? DopovidKafedra { get; set; }//на усіх авторів
        public double? MijnarodDogovir { get; set; }//на усіх авторів

        public double? OformlennyaPatent { get; set; }//непонятно
        public double? OtrymannyaPatent { get; set; }//непонятно
        public double? OformlennyaKorMod { get; set; }//непонятно
        public double? OtrymannyaKorMod { get; set; }//непонятно
        public double? RecenzStattya { get; set; }
        public double? RecenzStattyaN { get; set; }
        public double? RecenzDesertDoktor { get; set; }
        public double? RecenzDesertDoktorN { get; set; }
        public double? RecenzDesertKandidat { get; set; }
        public double? RecenzDesertKandidatN { get; set; }
        public double? OponDesertDoktor { get; set; }
        public double? OponDesertDoktorN { get; set; }
        public double? OponDesertKandidat { get; set; }
        public double? OponDesertKandidatN { get; set; }

        public double? KerivStud { get; set; }
        public double? KerivStudStattyaN { get; set; }
        public double? KerivStudKonkursN { get; set; }
        public double? KerivStudOhoronDocN { get; set; }
        public double? KerivStudTezDopovidN { get; set; }
        public double? PidgotovkaStud { get; set; }
        public double? PidgotovkaStudMijn { get; set; }
        public double? PidgotovkaStudMijnUkr { get; set; }
        public double? PidgotovkaStudMijnZaKordonom { get; set; }
        public double? KerivNaukStud { get; set; }
        public double? KerivNaukStudVseukrain { get; set; }
        public double? KerivNaukStudMijnarodUkr { get; set; }
        public double? KerivNaukStudMijnarodZaKordon { get; set; }

        public double? KerivSudNaukGurtok { get; set; }
        public bool KerivSudNaukGurtokBool { get; set; } = false;

        public double? NaukEksped { get; set; }
        public double? NaukEkspedNDniv { get; set; }
        public double? VistavkaNaukDosMijnarod { get; set; }//на усіх авторів
        public double? VistavkaNaukDosVseukrain { get; set; }//на усіх авторів
        public double? VistavkaNaukDosRegion { get; set; }//на усіх авторів
        public double? Sum { get; set; }
        public string PIB { get; set; }
        public string User { get; set; }
    }
}
