using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RankApp.Models;
namespace RankApp.Data
{
    public class NavchRob
    {
        public int Id { get; set; }
        public double? Spivbesida { get; set; }
        public double? SpivbesidaNStud { get; set; }
        public double? EkzamenUsn { get; set; }
        public double? EkzamenUsnNStud { get; set; }
        public double? EkzamenUkrMovaDyktant { get; set; }
        public double? EkzamenUkrMovaDyktantNGrup { get; set; }
        public double? EkzamenUkrMovaDyktantNRobit { get; set; }
        public double? EkzamenUkrMovaPerekaz { get; set; }
        public double? EkzamenUkrMovaPerekazNGrup { get; set; }
        public double? EkzamenUkrMovaPerekazNRobit { get; set; }
        public double? EkzamenUkrMovaTvir { get; set; }
        public double? EkzamenUkrMovaTvirNGrup { get; set; }//є в контроллері
        public double? EkzamenUkrMovaTvirNRobit { get; set; }//є в контроллері
        public double? EkzamenInshiPred { get; set; }//є в контроллері
        public double? EkzamenInshiPredNGrup { get; set; }//є в контроллері
        public double? EkzamenInshiPredNRobit { get; set; }//є в контроллері
        public double? EkzamenTest { get; set; }//є в контроллері//є в View
        public double? EkzamenTestNGrup { get; set; }//є в контроллері//є в View
        public double? Lekcii { get; set; }//є в контроллері//є в View
        public double? Prakticni { get; set; }//є в контроллері//є в View
        public double? Laboratorni { get; set; }//є в контроллері//є в View
        public double? Seminar { get; set; }//просто ввід//нема в View
        public double? Individual { get; set; }////просто ввід//нема в View
        public double? KonsultNavch { get; set; }//розподіл в контроллері//нема в View
        public double? KonsultEkzamVstup { get; set; }//є в контроллері
        public double? KonsultEkzamVstupNGrup { get; set; }//є в контроллері
        public double? KonsultEkzamSemestr { get; set; }//ДОРОБИТИ
        public double? KonsultEkzamSemestrNGrup { get; set; }//ДОРОБИТИ
        public double? KonsultEkzamDerj { get; set; }//ДОРОБИТИ
        public double? KonsultEkzamDerjNGrup { get; set; }//ДОРОБИТИ
        public double? PerevirkaKontr { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKontrN { get; set; }//є в контроллері//нема в View
        public double? PerevirkaRefer { get; set; }//є в контроллері//нема в View
        public double? PerevirkaReferN { get; set; }//є в контроллері//нема в View
        public double? PerevirkaGraf { get; set; }//є в контроллері//нема в View
        public double? PerevirkaGrafN { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursRobZagOsv { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursRobZagOsvNRobit { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursRobFah { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursRobFahNRobit { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursProjZagIng { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursProjZagIngNRobit { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursProjFah { get; set; }//є в контроллері//нема в View
        public double? PerevirkaKursProjFahNrobit { get; set; }//є в контроллері//нема в View
        public double? Zalik { get; set; }//з розподілу//є в контроллері
        public double? SemestEkzUsn { get; set; }//є в контроллері//нема в View
        public double? SemestEkzUsnNGrup { get; set; }//є в контроллері//нема в View
        public double? SemestEkzPism { get; set; }//є в контроллері//нема в View
        public double? SemestEkzPismNGrup { get; set; }//є в контроллері//нема в View
        public double? SemestEkzPismNRobit { get; set; }//є в контроллері//нема в View
        public double? PraktikNavchalna { get; set; }//непотрібно
        public double? PraktikVirobn { get; set; }//є в контроллері
        public double? PraktikDiplomna { get; set; }//з розподілу//є в контроллері
        public double? EkzamenDerjavn { get; set; }//є в контроллері
        public double? EkzamenDerjavnNStud { get; set; }//є в контроллері
        public double? DyplomBakalavr { get; set; }//є в контроллері
        public double? DyplomBakalavrNKeriv { get; set; }//з розподілу
        public double? DyplomBakalavrNChlen { get; set; }//є в контроллері
        public double? DyplomBakalavrNKonsult { get; set; }//є в контроллері
        public double? DyplomSpecialist { get; set; }
        public double? DyplomSpecialistNKeriv { get; set; }//з розподілу
        public double? DyplomSpecialistNChlen { get; set; }
        public double? DyplomSpecialistNKonsult { get; set; }
        public double? DyplomMagistr { get; set; }//є в контроллері
        public double? DyplomMagistrNKeriv { get; set; }//з розподілу//є в контроллері
        public double? DyplomMagistrNChlen { get; set; }//є в контроллері
        public double? DyplomMagistrNKonsult { get; set; }//є в контроллері

        public double? RecenzReferat { get; set; }//є в контроллері
        public double? RecenzReferatNRobit { get; set; }//є в контроллері
        public double? EkzamenAspirant { get; set; }//є в контроллері
        public double? EkzamenAspirantNStud { get; set; }//є в контроллері
        public double? KerivnukAspirant { get; set; }//є в контроллері
        public double? KerivnukAspirantN { get; set; }//є в контроллері
        public double? KonsultDokrtor { get; set; }//непонятно//є в контроллері//нема в View
        public double? KonsultDokrtorN { get; set; }//непонятно//є в контроллері//нема в View
        public double? KerivnukZdobuvach { get; set; }//є в контроллері
        public double? KerivnukZdobuvachN { get; set; }//є в контроллері
        public double? KerivnukStajVikladach { get; set; }//непонятно//є в контроллері
        public double? TematDisc { get; set; }//є в контроллері
        public double? KerivnukStajSluhach { get; set; }//є в контроллері
        public double? KerivnukStajSluhachN { get; set; }//є в контроллері
        public double? KerivnukSluhach { get; set; }//непонятно//є в контроллері
        public double? KerivnukSluhachNKonsult { get; set; }//є в контроллері
        public double? KerivnukSluhachNChlen { get; set; }//є в контроллері
        public double? KerivnukSluhachNKeriv { get; set; }//є в контроллері
        public double? EkzamenSluhach { get; set; }//є в контроллері
        public double? EkzamenSluhachNChlen { get; set; }//є в контроллері
        public double? Sum { get; set; }
        public string PIB { get; set; }
        public string User { get; set; }
    }
}
