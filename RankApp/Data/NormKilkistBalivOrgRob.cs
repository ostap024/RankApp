using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankApp.Data
{
    public class NormatKilkistBalivOrgRob
    {
        public int Id { get; set; }
        public double? RobotaPrimKomis { get; set; }
        public bool RobotaPrimKomisOsobamBool { get; set; } = false;
        public bool RobotaPrimKomisSekretarBool { get; set; } = false;
        public double? ProfOrientRob { get; set; }
        public double? ProfOrientRobNDniv { get; set; }
        public double? RobotaVKomisMON { get; set; }
        public double? RobotaVKomisMONNZasid { get; set; }
        public double? RobotaRadaDesert { get; set; }
        public double? RobotaRadaDesertGolovaNZasid { get; set; }
        public double? RobotaRadaDesertSekretarNZasid { get; set; }
        public double? RobotaRadaDesertChlenNZasid { get; set; }
        public double? RobotaEksperKomisDesertKandidat { get; set; }
        public double? RobotaEksperKomisDesertDoktor { get; set; }
        public double? RobotaNaukMetodNaukTehRadah { get; set; }
        public double? RobotaNaukMetodNaukTehRadahNZasid { get; set; }
        public double? RobotaVchenaRadaUniver { get; set; }
        public double? RobotaVchenaRadaUniverClenNZasid { get; set; }
        public bool RobotaVchenaRadaUniverSekretarUniverBool { get; set; } = false;
        public bool RobotaVchenaRadaUniverSekretarNNIBool { get; set; } = false;
        public double? RobotaMetodRad { get; set; }
        public double? RobotaMetodRadNZasid { get; set; }
        public double? RobotaEkspKonkursKomis { get; set; }
        public double? RobotaEkspKonkursKomisUniverNZasid { get; set; }
        public double? RobotaEkspKonkursKomisNNINZasid { get; set; }
        public double? OrgMijnarodZahid { get; set; }
        public double? OrgVseUkrZahid { get; set; }
        public double? OrgDistancZahid { get; set; }
        public double? OrgUniverStudZahid { get; set; }
        public double? OrgNaukSemNAN { get; set; }
        public bool OrgNaukSemNANSekretarBool { get; set; } = false;
        public bool OrgNaukSemNANGolovaBool { get; set; } = false;
        public double? OrgOlimpPershEtap { get; set; }
        public double? OrgOlimpDrugEtap { get; set; }
        public double? PidgotDyplomVseUkr { get; set; }
        public double? PidgotDyplomVseUkrNRobit { get; set; }
        public double? RobotaRedakNaukVidan { get; set; }
        public double? RobotaRedakNaukVidanNVipusk { get; set; }
        public double? RobotaFormNaukVidanScopus { get; set; }
        public double? RobotaFormNaukVidanMijnarod { get; set; }
        public double? RobotaFormNaukVidanUkr { get; set; }
        public double? UchastTovarMolodVchen { get; set; }
        public bool UchastTovarMolodVchenBool { get; set; } = false;
        public double? OrgTaSuprovidNaukMetRobKafedra { get; set; }
        public bool OrgTaSuprovidNaukMetRobKafedraBool { get; set; } = false;
        public double? SekretarKafedra { get; set; }
        public bool SekretarKafedraBool { get; set; } = false;
        public double? RozpodilNavchNavant { get; set; }
        public bool RozpodilNavchNavantBool { get; set; } = false;
        public double? FormKontingentVstupMagistr { get; set; }
        public double? FormKontingentVstupMagistrNStud { get; set; }
        public double? RobotaKomisPoperedZahistDyplom { get; set; }
        public bool RobotaKomisPoperedZahistDyplomBool { get; set; } = false;
        public double? SekretarEK { get; set; }
        public bool SekretarEKBool { get; set; } = false;
        public double? OrgPislyaDiplomOsv { get; set; }
        public bool OrgPislyaDiplomOsvBool { get; set; } = false;
        public double? ZvyazokPidprPrakt { get; set; }
        public bool ZvyazokPidprPraktBool { get; set; } = false;
        public double? CivilOboron { get; set; }
        public bool CivilOboronBool { get; set; } = false;
        public double? OhoronaPraci { get; set; }
        public bool OhoronaPraciBool { get; set; } = false;
        public double? ZvyazokBiblioteka { get; set; }
        public bool ZvyazokBibliotekaBool { get; set; } = false;
        public double? OcinRobVikladach { get; set; }
        public bool OcinRobVikladachBool { get; set; } = false;
        public double? UchastURozrobSystemUniver { get; set; }
        public bool UchastURozrobSystemUniverBool { get; set; } = false;
        public double? RobotaIzPracevlashtuvannya { get; set; }
        public bool RobotaIzPracevlashtuvannyaBool { get; set; } = false;
        public double? RobotaRozvitokMijnarodZvyazok { get; set; }
        public bool RobotaRozvitokMijnarodZvyazokNNIBool { get; set; } = false;
        public bool RobotaRozvitokMijnarodZvyazokKafedraBool { get; set; } = false;
        public double? UchastRadHimRozvidka { get; set; }
        public bool UchastRadHimRozvidkaBool { get; set; } = false;
        public double? RobotaVikladachKurator { get; set; }
        public bool RobotaVikladachKuratorBool { get; set; } = false;
        public double? OrgNavchDiscInozemMova { get; set; }
        public double? OrgNavchDiscInozemMovaNDisc { get; set; }
        public double? OrgMijnarodMobil { get; set; }
        public double? OrgMijnarodMobilNStud { get; set; }
        public double? OrgPodvDyplom { get; set; }
        public double? OrgPodvDyplomNStud { get; set; }
        public double? StajVikladach { get; set; }

        public double? FormIndividPlanStud { get; set; }
        public double? FormIndividPlanStudNStud { get; set; }

        public double? OrgZyazokZVipusk { get; set; }
        public bool OrgZyazokZVipuskBool { get; set; } = false;

        public double? VprovSystemVipuskPrac { get; set; }
        public bool VprovSystemVipuskPracBool { get; set; } = false;


        public double? RozrobkaDodatkivMijnarod { get; set; }
        public bool RozrobkaDodatkivMijnarodBool { get; set; } = false;
        public double? SuprovidVirtNavchSered { get; set; }
        public bool SuprovidVirtNavchSeredBool { get; set; } = false;
        public double? RozrobSaitKafedra { get; set; }
        public double? SuprovidWebStorKafedra { get; set; }

        public double? AdminWebMerejKafedra { get; set; }
        public bool AdminWebMerejKafedraBool { get; set; } = false;
        public double? ProvedennyaEkskurs { get; set; }
        public double? ProvedennyaEkskursNZahid { get; set; }
        public double? OrgTaProvKultZahid { get; set; }
        public double? OrgTaProvTematVechir { get; set; }

        public double? KerivSudKlubSekciya { get; set; }
        public bool KerivSudKlubSekciyaBool { get; set; } = false;

        public double? PidOrgTaProvSvorchZahod { get; set; }
        public double? EstetKaredra { get; set; }
        public double? KontrolYakostiPidgFah { get; set; }
        public double? KontrolYakostiPidgFahKontrRobNStud { get; set; }
        public double? KontrolYakostiPidgFahRozrahGrafRobNStud { get; set; }
        public double? KontrolYakostiPidgFahIndividZavdNStud { get; set; }
        public double? KontrolYakostiPidgFahKontrRobZaochNStud { get; set; }
        public double? Sum { get; set; }
        public string PIB { get; set; }
        public string User { get; set; }
    }
}
