using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankApp.Data
{
    public class MetodRob
    {
        public int Id { get; set; }
        public double? VidannyaPidruch { get; set; }//на усіх авторів
        public double? RecenzPidruch { get; set; }
        public double? RecenzPidruchNStor { get; set; }
        public double? VidannyaRozrobok { get; set; }//на усіх авторів
        public double? RecenzRozrobok { get; set; }
        public double? RecenzRozrobokNStor { get; set; }
        public double? EkspertDyplom { get; set; }
        public double? EkspertDyplomNRobit { get; set; }
        public double? PidgotovkaMater { get; set; }//на усіх авторів
        public double? UchastRobGrup { get; set; }
        public double? UchastRobGrupNDniv { get; set; }
        public double? SiteKafedra { get; set; }
        public double? RobotaNavchGrup { get; set; }//непонятно
        public double? PidgotovkaLekciiBakalavr { get; set; }
        public double? PidgotovkaLekciiBakalavrN { get; set; }
        public double? PidgotovkaLekciiMagistr { get; set; }
        public double? PidgotovkaLekciiMagistrN { get; set; }
        public double? PidgotovkaLabPrakt { get; set; }
        public double? RozrobkaVNS { get; set; }//на усіх авторів
        public double? RozrobkaVNSNDisc { get; set; }//на усіх авторів
        public double? RozrobkaLab { get; set; }//на усіх авторів
        public double? RozrobkaLabNRobit { get; set; }//на усіх авторів
        public double? RozrobkaNavchMat { get; set; }//на усіх авторів
        public double? RozrobkaNavchMatNZanyat { get; set; }//на усіх авторів
        public double? RozrobkaInterMet { get; set; }//на усіх авторів
        public double? RozrobkaInterMetNZanyat { get; set; }//на усіх авторів
        public double? Rozrobka15 { get; set; }//на усіх авторів
        public double? PerevirkaOlimp { get; set; }
        public double? PerevirkaOlimpNRobit { get; set; }
        public double? PidgotovkaDopovidTaVistup { get; set; }
        public double? PidgotovkaDopovidTaVistupNVistup { get; set; }
        public double? VzaemVidvid { get; set; }

        public double? PidgotovkaRecenzVidkr { get; set; }
        public double? PidgotovkaRecenzVidkrNZanat { get; set; }
        public double? RozrobkaZavdan { get; set; }
        public double? RozrobkaZavdanNZavdan { get; set; } 
        public double? StagBezVidr { get; set; }
        public bool StagBezVidrBool { get; set; } = false;
        public double? StagZVidr { get; set; }
        public bool StagZVidrBool { get; set; } = false;
        public double? PidvKval { get; set; }
        public double? PerekladStat { get; set; }
        public double? PerekladStatNStor { get; set; }
        public double? Sum { get; set; }
        public string PIB { get; set; }
        public string User { get; set; }
    }
}
