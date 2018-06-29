using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RankApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Linq;
using RankApp.Models.RegistrationViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RankApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace RankApp.Controllers
{
    public class HomeController : Controller
    {
        private NavantagennyaContext dbNavant;
        private RegisterBufContext dbRegist;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
       public HomeController(IHostingEnvironment hostingEnvironment, NavantagennyaContext context, RegisterBufContext Regcontext, UserManager<ApplicationUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            dbNavant = context;
            dbRegist = Regcontext;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> OnPostImport()
        {
            IFormFile fileExcel = Request.Form.Files[0];
            string papkaName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, papkaName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (fileExcel.Length > 0)
            {
                string sFileExtension = Path.GetExtension(fileExcel.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, fileExcel.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    fileExcel.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); 
                        sheet = hssfwb.GetSheetAt(0);
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); 
                        sheet = hssfwb.GetSheetAt(0); 
                    }
                    List<Navantagennya> navantagennyaList = new List<Navantagennya>();
                    IRow headerRow = sheet.GetRow(0); 
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");

                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                        sb.AppendLine("</tr>");

                        navantagennyaList.Add(new Navantagennya
                        {
                            NumberPP = ConvertCellToInt(row.GetCell(0)),
                            NumberDisc = ConvertCellToInt(row.GetCell(1)),
                            Nazva = ConvertCellToString(row.GetCell(2)),
                            Grupa = ConvertCellToString(row.GetCell(3)),
                            Kurs = ConvertCellToInt(row.GetCell(4)),
                            Studentiv = ConvertCellToInt(row.GetCell(5)),
                            Grup = ConvertCellToInt(row.GetCell(6)),
                            Pidgrup = ConvertCellToInt(row.GetCell(7)),
                            Semestr = row.GetCell(8).ToString(),
                            Lekcii = ConvertCellToDouble(row.GetCell(9)),
                            Consultant = ConvertCellToDouble(row.GetCell(10)),
                            Laborant = ConvertCellToDouble(row.GetCell(11)),
                            Praktuchni = ConvertCellToDouble(row.GetCell(12)),
                            Modul = ConvertCellToDouble(row.GetCell(13)),
                            Kursovi = ConvertCellToDouble(row.GetCell(14)),
                            Zalik = ConvertCellToDouble(row.GetCell(15)),
                            Isput = ConvertCellToDouble(row.GetCell(16)),
                            Dyplom = ConvertCellToDouble(row.GetCell(17)),
                            DEK = ConvertCellToDouble(row.GetCell(18)),
                            Aspiranty = ConvertCellToDouble(row.GetCell(19)),
                            Praktyka = ConvertCellToDouble(row.GetCell(20)),
                            Kontrolny = ConvertCellToDouble(row.GetCell(21)),
                            Vsyogo = ConvertCellToDouble(row.GetCell(22)),
                            Primitka = ConvertCellToString(row.GetCell(23)),
                            Vikladach = row.GetCell(24).ToString()
                        });
                    }
                    sb.Append("</table>");
                    await dbNavant.Navantagennyas.AddRangeAsync(navantagennyaList);
                    dbNavant.SaveChanges();
                }
            }
            return this.Content(sb.ToString());
        }


        public async Task<IActionResult> Index()
        {
            MasterNavant master = new MasterNavant();
            if (User.Identity.IsAuthenticated)
            {          
                master.Navantagennya = await dbNavant.Navantagennyas.ToListAsync();
                master.NavchRob = await dbNavant.NavchRobs.ToListAsync();
                master.MetodRob = await dbNavant.MetodRobs.ToListAsync();
                master.NaukRob = await dbNavant.NaukRobs.ToListAsync();
                master.OrgRob = await dbNavant.OrgRobs.ToListAsync();
                master.NormatKilkist = await dbNavant.NormatKilkistBalivOrgRobs.ToListAsync();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userName = user.PIB;
                ViewBag.user = _userManager.GetUserId(HttpContext.User);
            }          
            return View(master);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegCode()
        {
            return View(await dbRegist.RegisterBufs.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
 
        public IActionResult Contact()
        {
            ViewData["Message"] = "Контактні дані";

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Registration(string returnUrl = null)
        {
            var result = dbNavant.Navantagennyas.Select(m => m.Vikladach).Distinct().ToList();
            List<SelectListItem> selectItems = new List<SelectListItem>();
            foreach (var role in result)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = role;
                listItem.Text = role;
                selectItems.Add(listItem);
            }
            ViewBag.listofitems = selectItems;
            return View(new RegistrationViewModel { ReturnUrl = returnUrl });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString("D");
                await dbRegist.RegisterBufs.AddAsync(new RegisterBuf { PIB = model.PIB, RegCode = guid });
                dbRegist.SaveChanges();
            }
            return RedirectToAction("RegCode");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("DeleteAll")]
        public IActionResult ConfirmDeleteAll()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteAll(int? id)
        {
            await dbNavant.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE [Navantagennyas]");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ImportExport()
        {
            ViewData["Message"] = "Іморт/Експорт";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Navantagennya navantagennya)
        {
            dbNavant.Navantagennyas.Add(navantagennya);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNavchRob(NavchRob navchRob)
        {
            var user = await GetCurrentUserAsync();
            navchRob.User = user?.Id;
            navchRob.PIB = user?.PIB;
            navchRob.Spivbesida = navchRob.SpivbesidaNStud * 0.25;
            navchRob.EkzamenUsn = navchRob.EkzamenUsnNStud * 0.25;
            navchRob.EkzamenUkrMovaDyktant = navchRob.EkzamenUkrMovaDyktantNGrup + navchRob.EkzamenUkrMovaDyktantNRobit * 0.33;
            navchRob.EkzamenUkrMovaPerekaz = navchRob.EkzamenUkrMovaPerekazNGrup * 2 + navchRob.EkzamenUkrMovaPerekazNRobit * 0.5;
            navchRob.EkzamenUkrMovaTvir = navchRob.EkzamenUkrMovaTvirNGrup * 3 + navchRob.EkzamenUkrMovaTvirNRobit * 0.25;
            navchRob.EkzamenInshiPred = navchRob.EkzamenInshiPredNGrup * 2 + navchRob.EkzamenInshiPredNRobit * 0.25;
            navchRob.EkzamenTest = navchRob.EkzamenTestNGrup;
            var id = _userManager.GetUserId(User);
            var result = _userManager.Users.SingleOrDefault(u => u.Id == id);
            string name = result.PIB;
            var navant = dbNavant.Navantagennyas.Where(e => e.Vikladach == name);
            navchRob.Lekcii = await navant.SumAsync(item => item.Lekcii);
            navchRob.Prakticni = await navant.SumAsync(item => item.Praktuchni);          
            navchRob.Laboratorni = await navant.SumAsync(item => item.Laborant);
            navchRob.KonsultNavch = await navant.SumAsync(item => item.Consultant);
            navchRob.KonsultEkzamVstup = navchRob.KonsultEkzamVstupNGrup * 2;
            navchRob.PerevirkaKontr = navchRob.PerevirkaKontrN * 0.25;
            navchRob.PerevirkaRefer = navchRob.PerevirkaReferN * 0.15;
            navchRob.PerevirkaGraf = navchRob.PerevirkaGrafN * 0.25;
            navchRob.PerevirkaKursRobZagOsv = navchRob.PerevirkaKursRobZagOsvNRobit;
            navchRob.PerevirkaKursRobFah = navchRob.PerevirkaKursRobFahNRobit * 1.5;
            navchRob.PerevirkaKursProjZagIng = navchRob.PerevirkaKursProjZagIngNRobit * 2;
            navchRob.PerevirkaKursProjFah = navchRob.PerevirkaKursProjFahNrobit * 3;
            navchRob.Zalik = await navant.SumAsync(item => item.Zalik);
            navchRob.SemestEkzUsn = navchRob.SemestEkzUsnNGrup * 2;
            navchRob.SemestEkzPism = navchRob.SemestEkzPismNGrup * 2 + navchRob.SemestEkzPismNRobit * 0.25;
            navchRob.PraktikVirobn = await navant.Where(item => item.Nazva.Contains("Проектно-технологічна практика")).SumAsync(item => item.Praktyka);
            navchRob.PraktikDiplomna = await navant.Where(item => item.Nazva.Contains("Переддипломна практика")).SumAsync(item => item.Praktyka);
            navchRob.EkzamenDerjavn = await navant.Where(item => item.Nazva.Contains("Державний екзамен")).SumAsync(item => item.DEK);        
            navchRob.DyplomBakalavrNKeriv = await navant.Where(item => item.Nazva.Contains("Комплексна кваліфікаційна робота")).SumAsync(item => item.Dyplom);
            navchRob.DyplomBakalavrNChlen = await navant.Where(item => item.Nazva.Contains("Захист бакалаврської роботи ДЕК") || item.Nazva.Contains("Комплексна кваліфікаційна робота ДЕК")).SumAsync(item => item.DEK);
            navchRob.DyplomMagistrNKeriv = await navant.Where(item => item.Nazva=="Дипломне проектування (магістр)").SumAsync(item => item.Dyplom);
            navchRob.DyplomMagistrNChlen = await navant.Where(item => item.Nazva == "Дипломне проектування (магістр) ДЕК").SumAsync(item => item.DEK);
           
            navchRob.RecenzReferat = navchRob.RecenzReferatNRobit * 3;
            navchRob.EkzamenAspirant = navchRob.EkzamenAspirantNStud;
            navchRob.KerivnukAspirant = await navant.Where(item => item.Nazva == "Аспіранти").SumAsync(item => item.Aspiranty);
            navchRob.KonsultDokrtor = navchRob.KonsultDokrtorN * 50;
            navchRob.KerivnukZdobuvach = await navant.Where(item => item.Nazva == "Здобувачі").SumAsync(item => item.Aspiranty);
            navchRob.KerivnukSluhach = navchRob.KerivnukSluhachNKeriv * 10 + navchRob.KerivnukSluhachNChlen * 0.25 + navchRob.KerivnukSluhachNKonsult * 0.5;
            navchRob.EkzamenSluhach = navchRob.EkzamenSluhachNChlen * 0.25;
            navchRob.Sum = 0;
            navchRob.Sum = navchRob.Spivbesida.GetValueOrDefault() + navchRob.EkzamenUsn.GetValueOrDefault() + navchRob.EkzamenUkrMovaDyktant.GetValueOrDefault() + 
                navchRob.EkzamenUkrMovaPerekaz.GetValueOrDefault() + navchRob.EkzamenUkrMovaTvir.GetValueOrDefault() + navchRob.EkzamenInshiPred.GetValueOrDefault() + 
                navchRob.EkzamenTest.GetValueOrDefault() + navchRob.Lekcii.GetValueOrDefault() + navchRob.Prakticni.GetValueOrDefault() + navchRob.Laboratorni.GetValueOrDefault() +
                navchRob.Seminar.GetValueOrDefault() + navchRob.Individual.GetValueOrDefault() + navchRob.KonsultNavch.GetValueOrDefault() +
                navchRob.KonsultEkzamSemestr.GetValueOrDefault() + navchRob.KonsultEkzamDerj.GetValueOrDefault() + navchRob.PerevirkaKontr.GetValueOrDefault() +
                navchRob.PerevirkaRefer.GetValueOrDefault() + navchRob.PerevirkaKursProjZagIng.GetValueOrDefault() + navchRob.PerevirkaKursRobZagOsv.GetValueOrDefault() +
                navchRob.PerevirkaKursRobFah.GetValueOrDefault() + navchRob.PerevirkaGraf.GetValueOrDefault() + navchRob.PerevirkaKursProjFah.GetValueOrDefault() +
                navchRob.KonsultEkzamVstup.GetValueOrDefault() + navchRob.Zalik.GetValueOrDefault() +   navchRob.PraktikNavchalna.GetValueOrDefault() +
                navchRob.SemestEkzUsn.GetValueOrDefault() + navchRob.SemestEkzPism.GetValueOrDefault() + navchRob.PraktikVirobn.GetValueOrDefault() +
                navchRob.PraktikDiplomna.GetValueOrDefault() + navchRob.EkzamenDerjavn.GetValueOrDefault() + navchRob.DyplomBakalavrNKeriv.GetValueOrDefault() +
                navchRob.DyplomBakalavrNChlen.GetValueOrDefault() +navchRob.DyplomMagistrNKeriv.GetValueOrDefault() + navchRob.DyplomMagistrNChlen.GetValueOrDefault() + 
                navchRob.RecenzReferat.GetValueOrDefault() + navchRob.EkzamenAspirant.GetValueOrDefault() + navchRob.KerivnukAspirant.GetValueOrDefault() +
                navchRob.KonsultDokrtor.GetValueOrDefault() + navchRob.KerivnukStajSluhach.GetValueOrDefault() +
                navchRob.KerivnukZdobuvach.GetValueOrDefault() +navchRob.KerivnukSluhach.GetValueOrDefault() + navchRob.EkzamenSluhach.GetValueOrDefault();
            dbNavant.NavchRobs.Update(navchRob);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMetodRob(MetodRob metodRob)
        {
            var user = await GetCurrentUserAsync();
            metodRob.User = user?.Id;
            metodRob.PIB = user?.PIB;
            metodRob.RecenzPidruch = metodRob.RecenzPidruchNStor * 3;
            metodRob.RecenzRozrobok = metodRob.RecenzRozrobokNStor * 2;
            metodRob.EkspertDyplom = metodRob.EkspertDyplomNRobit * 2;
            metodRob.UchastRobGrup = metodRob.UchastRobGrupNDniv * 6;
            metodRob.PidgotovkaLekciiBakalavr = metodRob.PidgotovkaLekciiBakalavrN * 1.2;
            metodRob.PidgotovkaLekciiMagistr = metodRob.PidgotovkaLekciiMagistrN * 1.5;
            metodRob.PerevirkaOlimp = metodRob.PerevirkaOlimpNRobit * 0.15;
            metodRob.PidgotovkaDopovidTaVistup = metodRob.PidgotovkaDopovidTaVistupNVistup * 7;
            metodRob.PidgotovkaRecenzVidkr = metodRob.PidgotovkaRecenzVidkrNZanat * 2;
            if (metodRob.StagBezVidrBool)
                metodRob.StagBezVidr = 30;
            else metodRob.StagBezVidr = 0;
            if (metodRob.StagZVidrBool)
                metodRob.StagZVidr = 70;
            else metodRob.StagZVidr = 0;
            metodRob.PerekladStat = metodRob.PerekladStatNStor * 20;
            metodRob.Sum = 0;
            metodRob.Sum = metodRob.VidannyaPidruch.GetValueOrDefault() + metodRob.VidannyaRozrobok.GetValueOrDefault() + metodRob.PidgotovkaMater.GetValueOrDefault() +
                metodRob.SiteKafedra.GetValueOrDefault() + metodRob.RobotaNavchGrup.GetValueOrDefault() + metodRob.PidgotovkaLabPrakt.GetValueOrDefault() +
                metodRob.RozrobkaVNS.GetValueOrDefault() + metodRob.RozrobkaLab.GetValueOrDefault() + metodRob.RozrobkaNavchMat.GetValueOrDefault() +
                metodRob.RozrobkaInterMet.GetValueOrDefault() + metodRob.VzaemVidvid.GetValueOrDefault() + metodRob.RozrobkaZavdan.GetValueOrDefault() +
                metodRob.StagZVidr.GetValueOrDefault() + metodRob.StagBezVidr.GetValueOrDefault() + metodRob.PidvKval.GetValueOrDefault() +
                metodRob.RecenzPidruch.GetValueOrDefault() + metodRob.RecenzRozrobok.GetValueOrDefault() + metodRob.EkspertDyplom.GetValueOrDefault() + 
                metodRob.UchastRobGrup.GetValueOrDefault() + metodRob.PidgotovkaLekciiBakalavr.GetValueOrDefault() + metodRob.PidgotovkaLekciiMagistr.GetValueOrDefault() +
                metodRob.PerevirkaOlimp.GetValueOrDefault() + metodRob.PidgotovkaDopovidTaVistup.GetValueOrDefault() + metodRob.PidgotovkaRecenzVidkr.GetValueOrDefault() + 
                metodRob.PerekladStat.GetValueOrDefault();
            dbNavant.MetodRobs.Update(metodRob);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNaukRob(NaukRob naukRob)
        {
            var user = await GetCurrentUserAsync();
            naukRob.User = user?.Id;
            naukRob.PIB = user?.PIB;
            naukRob.StajZakordonVNZ = naukRob.StajZakordonVNZNDniv * 8;
            if (naukRob.ZahistDoktorBool)
                naukRob.ZahistDoktor = 400;
            else naukRob.ZahistDoktor = 0;
            if (naukRob.ZahistKandidatBool)
                naukRob.ZahistKandidat = 250;
            else naukRob.ZahistKandidat = 0;
            naukRob.RecenzMonografy = naukRob.RecenzMonografyNStor * 2;
            naukRob.RecenzStattya = naukRob.RecenzStattyaN * 3;
            naukRob.RecenzDesertDoktor = naukRob.RecenzDesertDoktorN * 15;
            naukRob.RecenzDesertKandidat = naukRob.RecenzDesertKandidatN * 10;
            naukRob.OponDesertKandidat = naukRob.OponDesertKandidatN * 50;
            naukRob.OponDesertDoktor = naukRob.OponDesertDoktorN * 80;
            naukRob.KerivStud = naukRob.KerivStudStattyaN * 30 + naukRob.KerivStudKonkursN * 30 + naukRob.KerivStudOhoronDocN * 30 + naukRob.KerivStudTezDopovidN*5;
            naukRob.PidgotovkaStud = naukRob.PidgotovkaStudMijn * 40 + naukRob.PidgotovkaStudMijnUkr * 20 + naukRob.PidgotovkaStudMijnZaKordonom * 30;
            naukRob.KerivNaukStud = naukRob.KerivNaukStudVseukrain * 20 + naukRob.KerivNaukStudMijnarodUkr * 30 + naukRob.KerivNaukStudMijnarodZaKordon * 40;
            naukRob.NaukEksped = naukRob.NaukEkspedNDniv * 6;
            if (naukRob.KerivSudNaukGurtokBool)
                naukRob.KerivSudNaukGurtok = 50;
            else naukRob.KerivSudNaukGurtok = 0;
            naukRob.Sum = 0;
            naukRob.Sum = naukRob.PidgotovkaMijnarodGrant.GetValueOrDefault() + naukRob.PidgotovkaMONGrant.GetValueOrDefault() + naukRob.PidgotovkaSpilnProekt.GetValueOrDefault() +
            naukRob.PidgotovkaNDR.GetValueOrDefault() + naukRob.VidannyaMonografy.GetValueOrDefault() + naukRob.StattyaScopusAngl.GetValueOrDefault() +
            naukRob.StattyaScopusUkr.GetValueOrDefault() + naukRob.StattyaMijnarodZakordon.GetValueOrDefault() + naukRob.StattyaMijnarodVitch.GetValueOrDefault() +
            naukRob.StattyaNeMignarod.GetValueOrDefault() + naukRob.VidannyaFahUkr.GetValueOrDefault() + naukRob.VidannyaNeFahUkr.GetValueOrDefault() +
            naukRob.DopovidMijnarod.GetValueOrDefault() + naukRob.DopovidUkr.GetValueOrDefault() + naukRob.DopovidKafedra.GetValueOrDefault() +
            naukRob.MijnarodDogovir.GetValueOrDefault() + naukRob.OformlennyaPatent.GetValueOrDefault() + naukRob.OtrymannyaPatent.GetValueOrDefault() +
            naukRob.OformlennyaKorMod.GetValueOrDefault() + naukRob.OtrymannyaKorMod.GetValueOrDefault() + naukRob.VistavkaNaukDosMijnarod.GetValueOrDefault() +
            naukRob.VistavkaNaukDosVseukrain.GetValueOrDefault() + naukRob.VistavkaNaukDosRegion.GetValueOrDefault() +
            naukRob.StajZakordonVNZ.GetValueOrDefault() + naukRob.ZahistDoktor.GetValueOrDefault() + naukRob.ZahistKandidat.GetValueOrDefault() +
            naukRob.RecenzMonografy.GetValueOrDefault() + naukRob.RecenzStattya.GetValueOrDefault() +
            naukRob.RecenzDesertDoktor.GetValueOrDefault() + naukRob.RecenzDesertKandidat.GetValueOrDefault() + naukRob.OponDesertKandidat.GetValueOrDefault()+ 
            naukRob.OponDesertDoktor.GetValueOrDefault() + naukRob.KerivStud.GetValueOrDefault() + naukRob.PidgotovkaStud.GetValueOrDefault() +
            naukRob.KerivNaukStud.GetValueOrDefault() + naukRob.NaukEksped.GetValueOrDefault() ;
            dbNavant.NaukRobs.Update(naukRob);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrgRob(OrgRob orgRob)
        {
            var user = await GetCurrentUserAsync();
            orgRob.User = user?.Id;
            orgRob.PIB = user?.PIB;
            if (orgRob.OrgZagalUniverZahidBool)
                orgRob.OrgZagalUniverZahid = 50;
            else orgRob.OrgZagalUniverZahid=0;
            if (orgRob.OrgKafedraZahidBool)
                orgRob.OrgKafedraZahid = 15;
            else orgRob.OrgKafedraZahid = 0;
            if (orgRob.ProvedennyaBesidBool)
                orgRob.ProvedennyaBesid = 15;
            else orgRob.ProvedennyaBesid = 0;
            if (orgRob.OrganizaciaEkskursBool)
                orgRob.OrganizaciaEkskurs = 3;
            else orgRob.OrganizaciaEkskurs = 0;
            orgRob.RozrobkaMaterialivZahid = 0;
            if (orgRob.RozrobkaMaterialivZahidPhotoBool)
                orgRob.RozrobkaMaterialivZahid += 3;
            if (orgRob.RozrobkaMaterialivZahidVideoBool)
                orgRob.RozrobkaMaterialivZahid += 5;
            if (orgRob.RozrobkaMaterialivZahidPrezentaciaBool)
                orgRob.RozrobkaMaterialivZahid += 5;
            orgRob.RobotaVchenaRada = 0;
            if (orgRob.RobotaVchenaRadaGolovaBool)
                orgRob.RozrobkaMaterialivZahid += 50;
            if (orgRob.RobotaVchenaRadaSekretarBool)
                orgRob.RozrobkaMaterialivZahid += 50;
            if (orgRob.RobotaVchenaRadaClenBool)
                orgRob.RozrobkaMaterialivZahid += 30;

            if (orgRob.KerivnukKafedraBool)
                orgRob.KerivnukKafedra = 100;
            else orgRob.KerivnukKafedra = 0;

            orgRob.ObovjazokKafedra = 0;
            if (orgRob.ObovjazokKafedraZastupnikBool)
                orgRob.ObovjazokKafedra += 80;
            if (orgRob.ObovjazokKafedraSekretarBool)
                orgRob.ObovjazokKafedra += 50;
            orgRob.RobotaTrudKolektiv = 0;
            if (orgRob.RobotaTrudKolektivGolovaBool)
                orgRob.RobotaTrudKolektiv += 50;
            if (orgRob.RobotaTrudKolektivZastupnikBool)
                orgRob.RobotaTrudKolektiv += 50;
            if (orgRob.RobotaTrudKolektivSekretarBool)
                orgRob.RobotaTrudKolektiv += 30;
            if (orgRob.RobotaTrudKolektivClenBool)
                orgRob.RobotaTrudKolektiv += 10;
            orgRob.RobotaRevizia = 0;
            if (orgRob.RobotaReviziaGolovaBool)
                orgRob.RobotaRevizia += 50;
            if (orgRob.RobotaReviziaZastupnikBool)
                orgRob.RobotaRevizia += 50;
            if (orgRob.RobotaReviziaSekretarBool)
                orgRob.RobotaRevizia += 30;

            if (orgRob.UchastProfOrientBool)
                orgRob.UchastProfOrient = 100;
            else orgRob.UchastProfOrient = 0;

            orgRob.SekretarNaukMetodSeminar = orgRob.SekretarNaukMetodSeminarNZasid * 1.5;
            if (orgRob.PidtrumkaWEBBool)
                orgRob.PidtrumkaWEB = 20;
            else orgRob.PidtrumkaWEB = 0;

            orgRob.ZasidannyaKafedra = orgRob.ZasidannyaKafedraNZasid * 1.5;
            if (orgRob.EstetKaredraBool)
                orgRob.EstetKaredra = 30;
            else orgRob.EstetKaredra = 0;
            orgRob.Sum = 0;
            orgRob.Sum = orgRob.OrgZagalUniverZahid.GetValueOrDefault() + orgRob.OrgKafedraZahid.GetValueOrDefault() + orgRob.ProvedennyaBesid.GetValueOrDefault() +
                orgRob.OrganizaciaEkskurs.GetValueOrDefault() + orgRob.RozrobkaMaterialivZahid.GetValueOrDefault() +  orgRob.RobotaVchenaRada.GetValueOrDefault() +
                orgRob.ObovjazokKafedra.GetValueOrDefault() + orgRob.RobotaTrudKolektiv.GetValueOrDefault() + orgRob.RobotaRevizia.GetValueOrDefault() + 
                orgRob.UchastProfOrient.GetValueOrDefault() + orgRob.SekretarNaukMetodSeminar.GetValueOrDefault() +
                orgRob.PidtrumkaWEB.GetValueOrDefault() + orgRob.ZasidannyaKafedra.GetValueOrDefault() + orgRob.EstetKaredra.GetValueOrDefault();
            dbNavant.OrgRobs.Update(orgRob);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNormatKilkistBalivOrgRob(NormatKilkistBalivOrgRob normatGod)
        {
            var user = await GetCurrentUserAsync();
            normatGod.User = user?.Id;
            normatGod.PIB = user?.PIB;

            normatGod.RobotaPrimKomis = 0;
            if (normatGod.RobotaPrimKomisOsobamBool)
                normatGod.RobotaPrimKomis += 50;
            if (normatGod.RobotaPrimKomisSekretarBool)
                normatGod.RobotaPrimKomis += 250;
            normatGod.ProfOrientRob = normatGod.ProfOrientRobNDniv * 6;
            normatGod.RobotaVKomisMON = normatGod.RobotaVKomisMONNZasid * 6;
            normatGod.RobotaRadaDesert = normatGod.RobotaRadaDesertGolovaNZasid*15+normatGod.RobotaRadaDesertSekretarNZasid*12 + normatGod.RobotaRadaDesertChlenNZasid*4;
            normatGod.RobotaNaukMetodNaukTehRadah = normatGod.RobotaNaukMetodNaukTehRadahNZasid * 4;
            normatGod.RobotaVchenaRadaUniver = 0;
            normatGod.RobotaVchenaRadaUniver += normatGod.RobotaVchenaRadaUniverClenNZasid * 3;
            if (normatGod.RobotaVchenaRadaUniverSekretarUniverBool)
                normatGod.RobotaVchenaRadaUniver += 50;
            if (normatGod.RobotaVchenaRadaUniverSekretarNNIBool)
                normatGod.RobotaVchenaRadaUniver += 250;
            normatGod.RobotaMetodRad = normatGod.RobotaMetodRadNZasid * 3;
            normatGod.RobotaEkspKonkursKomis = normatGod.RobotaEkspKonkursKomisUniverNZasid * 3 + normatGod.RobotaEkspKonkursKomisNNINZasid * 2;
            normatGod.OrgNaukSemNAN = 0;
            if (normatGod.OrgNaukSemNANSekretarBool)
                normatGod.OrgNaukSemNAN += 5;
            if (normatGod.OrgNaukSemNANGolovaBool)
                normatGod.OrgNaukSemNAN += 10;
            normatGod.PidgotDyplomVseUkr = normatGod.PidgotDyplomVseUkrNRobit * 20;
            normatGod.RobotaRedakNaukVidan = normatGod.RobotaRedakNaukVidanNVipusk * 10;
            if (normatGod.UchastTovarMolodVchenBool)
                normatGod.UchastTovarMolodVchen = 30;
            else normatGod.UchastTovarMolodVchen = 0;
            if (normatGod.OrgTaSuprovidNaukMetRobKafedraBool)
                normatGod.OrgTaSuprovidNaukMetRobKafedra = 50;
            else normatGod.OrgTaSuprovidNaukMetRobKafedra = 0;
            if (normatGod.SekretarKafedraBool)
                normatGod.SekretarKafedra = 50;
            else normatGod.SekretarKafedra = 0;
            if (normatGod.RozpodilNavchNavantBool)
                normatGod.RozpodilNavchNavant = 50;
            else normatGod.RozpodilNavchNavant = 0;
            normatGod.FormKontingentVstupMagistr = normatGod.FormKontingentVstupMagistrNStud * 2.5;
            if (normatGod.RobotaKomisPoperedZahistDyplomBool)
                normatGod.RobotaKomisPoperedZahistDyplom = 50;
            else normatGod.RobotaKomisPoperedZahistDyplom = 0;
            if (normatGod.SekretarEKBool)
                normatGod.SekretarEK = 50;
            else normatGod.SekretarEK = 0;
            if (normatGod.OrgPislyaDiplomOsvBool)
                normatGod.OrgPislyaDiplomOsv = 50;
            else normatGod.OrgPislyaDiplomOsv = 0;
            if (normatGod.ZvyazokPidprPraktBool)
                normatGod.ZvyazokPidprPrakt = 50;
            else normatGod.ZvyazokPidprPrakt = 0;
            if (normatGod.CivilOboronBool)
                normatGod.CivilOboron = 30;
            else normatGod.CivilOboron = 0;
            if (normatGod.OhoronaPraciBool)
                normatGod.OhoronaPraci = 30;
            else normatGod.OhoronaPraci = 0;
            if (normatGod.ZvyazokBibliotekaBool)
                normatGod.ZvyazokBiblioteka = 30;
            else normatGod.ZvyazokBiblioteka = 0;
            if (normatGod.OcinRobVikladachBool)
                normatGod.OcinRobVikladach = 30;
            else normatGod.OcinRobVikladach = 0;
            if (normatGod.UchastURozrobSystemUniverBool)
                normatGod.UchastURozrobSystemUniver = 30;
            else normatGod.UchastURozrobSystemUniver = 0;
            if (normatGod.RobotaIzPracevlashtuvannyaBool)
                normatGod.RobotaIzPracevlashtuvannya = 50;
            else normatGod.RobotaIzPracevlashtuvannya = 0;

            normatGod.RobotaRozvitokMijnarodZvyazok = 0;
            if (normatGod.RobotaRozvitokMijnarodZvyazokNNIBool)
                normatGod.RobotaRozvitokMijnarodZvyazok += 30;
            if (normatGod.RobotaRozvitokMijnarodZvyazokKafedraBool)
                normatGod.RobotaRozvitokMijnarodZvyazok += 15;
            if (normatGod.UchastRadHimRozvidkaBool)
                normatGod.UchastRadHimRozvidka = 30;
            else normatGod.UchastRadHimRozvidka = 0;
            if (normatGod.RobotaVikladachKuratorBool)
                normatGod.RobotaVikladachKurator = 100;
            else normatGod.RobotaVikladachKurator = 0;
            normatGod.OrgNavchDiscInozemMova = normatGod.OrgNavchDiscInozemMovaNDisc * 10;
            normatGod.OrgMijnarodMobil = normatGod.OrgMijnarodMobilNStud * 10;
            normatGod.OrgPodvDyplom = normatGod.OrgPodvDyplomNStud * 10;
            normatGod.FormIndividPlanStud = normatGod.FormIndividPlanStudNStud * 2;
            if (normatGod.OrgZyazokZVipuskBool)
                normatGod.OrgZyazokZVipusk = 20;
            else normatGod.OrgZyazokZVipusk = 0;
            if (normatGod.VprovSystemVipuskPracBool)
                normatGod.VprovSystemVipuskPrac = 30;
            else normatGod.VprovSystemVipuskPrac = 0;
            if (normatGod.RozrobkaDodatkivMijnarodBool)
                normatGod.RozrobkaDodatkivMijnarod = 50;
            else normatGod.RozrobkaDodatkivMijnarod = 0;
            if (normatGod.SuprovidVirtNavchSeredBool)
                normatGod.SuprovidVirtNavchSered = 50;
            else normatGod.SuprovidVirtNavchSered = 0;
            if (normatGod.AdminWebMerejKafedraBool)
                normatGod.AdminWebMerejKafedra = 50;
            else normatGod.AdminWebMerejKafedra = 0;
            normatGod.ProvedennyaEkskurs = normatGod.ProvedennyaEkskursNZahid * 4;
            if (normatGod.KerivSudKlubSekciyaBool)
                normatGod.KerivSudKlubSekciya = 75;
            else normatGod.KerivSudKlubSekciya = 0;
            normatGod.KontrolYakostiPidgFah = normatGod.KontrolYakostiPidgFahKontrRobNStud * 0.25 + normatGod.KontrolYakostiPidgFahRozrahGrafRobNStud * 0.5 + normatGod.KontrolYakostiPidgFahIndividZavdNStud * 0.25 + normatGod.KontrolYakostiPidgFahKontrRobZaochNStud * 0.33;

            normatGod.Sum = 0;
            normatGod.Sum = normatGod.RobotaPrimKomis.GetValueOrDefault()+ normatGod.ProfOrientRob.GetValueOrDefault() + normatGod.RobotaVKomisMON.GetValueOrDefault()+
            normatGod.RobotaRadaDesert.GetValueOrDefault() + normatGod.RobotaEksperKomisDesertKandidat.GetValueOrDefault() + normatGod.RobotaEksperKomisDesertDoktor.GetValueOrDefault() +
            normatGod.RobotaNaukMetodNaukTehRadah.GetValueOrDefault() + normatGod.RobotaVchenaRadaUniver.GetValueOrDefault() + normatGod.RobotaMetodRad.GetValueOrDefault() +
            normatGod.RobotaEkspKonkursKomis.GetValueOrDefault() + normatGod.OrgMijnarodZahid.GetValueOrDefault() + normatGod.OrgVseUkrZahid.GetValueOrDefault() +          
            normatGod.OrgDistancZahid.GetValueOrDefault() + normatGod.OrgUniverStudZahid.GetValueOrDefault() + normatGod.OrgNaukSemNAN.GetValueOrDefault() +
            normatGod.OrgOlimpPershEtap.GetValueOrDefault() + normatGod.OrgOlimpDrugEtap.GetValueOrDefault() + normatGod.PidgotDyplomVseUkr.GetValueOrDefault() +
            normatGod.RobotaRedakNaukVidan.GetValueOrDefault() + normatGod.RobotaFormNaukVidanScopus.GetValueOrDefault() + normatGod.RobotaFormNaukVidanMijnarod.GetValueOrDefault() +
            normatGod.RobotaFormNaukVidanUkr.GetValueOrDefault() + normatGod.UchastTovarMolodVchen.GetValueOrDefault() + normatGod.OrgTaSuprovidNaukMetRobKafedra.GetValueOrDefault() +
            normatGod.SekretarKafedra.GetValueOrDefault() + normatGod.RozpodilNavchNavant.GetValueOrDefault() + normatGod.FormKontingentVstupMagistr.GetValueOrDefault() +
            normatGod.RobotaKomisPoperedZahistDyplom.GetValueOrDefault() + normatGod.SekretarEK.GetValueOrDefault() + normatGod.OrgPislyaDiplomOsv.GetValueOrDefault() +
            normatGod.ZvyazokPidprPrakt.GetValueOrDefault() + normatGod.CivilOboron.GetValueOrDefault() + normatGod.OhoronaPraci.GetValueOrDefault() +
            normatGod.ZvyazokBiblioteka.GetValueOrDefault() + normatGod.OcinRobVikladach.GetValueOrDefault() + normatGod.UchastURozrobSystemUniver.GetValueOrDefault() +
            normatGod.RobotaIzPracevlashtuvannya.GetValueOrDefault() + normatGod.RobotaRozvitokMijnarodZvyazok.GetValueOrDefault() + normatGod.UchastRadHimRozvidka.GetValueOrDefault() +
            normatGod.RobotaVikladachKurator.GetValueOrDefault() + normatGod.OrgNavchDiscInozemMova.GetValueOrDefault() + normatGod.OrgMijnarodMobil.GetValueOrDefault() +
            normatGod.OrgPodvDyplom.GetValueOrDefault() + normatGod.StajVikladach.GetValueOrDefault() + normatGod.FormIndividPlanStud.GetValueOrDefault() +
            normatGod.OrgZyazokZVipusk.GetValueOrDefault() + normatGod.VprovSystemVipuskPrac.GetValueOrDefault() + normatGod.RozrobkaDodatkivMijnarod.GetValueOrDefault() +
            normatGod.SuprovidVirtNavchSered.GetValueOrDefault() + normatGod.RozrobSaitKafedra.GetValueOrDefault() + normatGod.SuprovidWebStorKafedra.GetValueOrDefault() +
            normatGod.AdminWebMerejKafedra.GetValueOrDefault() + normatGod.ProvedennyaEkskurs.GetValueOrDefault() + normatGod.OrgTaProvKultZahid.GetValueOrDefault() +
            normatGod.OrgTaProvTematVechir.GetValueOrDefault() + normatGod.KerivSudKlubSekciya.GetValueOrDefault() + normatGod.PidOrgTaProvSvorchZahod.GetValueOrDefault() +
            normatGod.EstetKaredra.GetValueOrDefault() + normatGod.KontrolYakostiPidgFah.GetValueOrDefault();
            dbNavant.NormatKilkistBalivOrgRobs.Update(normatGod);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Navantagennya navantagennya = await dbNavant.Navantagennyas.FirstOrDefaultAsync(p => p.Id == id);
                if (navantagennya != null)
                    return View(navantagennya);
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Navantagennya navantagennya = await dbNavant.Navantagennyas.FirstOrDefaultAsync(p => p.Id == id);
                if (navantagennya != null)
                    return View(navantagennya);
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Navantagennya navantagennya)
        {
            dbNavant.Navantagennyas.Update(navantagennya);
            await dbNavant.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Navantagennya navantagennya = await dbNavant.Navantagennyas.FirstOrDefaultAsync(p => p.Id == id);
                if (navantagennya != null)
                    return View(navantagennya);
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Navantagennya navantagennya = new Navantagennya { Id = id.Value };
                dbNavant.Entry(navantagennya).State = EntityState.Deleted;
                await dbNavant.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public double ConvertCellToDouble(ICell cell)
        {
            return double.Parse(cell.ToString().Replace(".", ","));
        }
        public int ConvertCellToInt(ICell cell)
        {
            return int.Parse(cell.ToString().Replace(".", ","));
        }
        public string ConvertCellToString(ICell cell)
        {
            string s = " ";
            if (cell != null)
                s = cell.ToString();
            return s;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
