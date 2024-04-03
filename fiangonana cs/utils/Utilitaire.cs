using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Threading.Tasks;
using fiangonana_cs.Models;
using fiangonana_cs.database;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace fiangonana_cs.utils
{
    public class Utilitaire
    {
        public static DateTime GetMondayDateFromSundayNumber(int year, int sundayNumber)
        {
            DateTime date = new DateTime(year, 1, 1);
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            for (int i = 1; i < sundayNumber; i++)
            {
                date = date.AddDays(7);
            }
            date = date.AddDays(1);
            return date;
        }  
        
        public static DateTime GetDateFromSundayNumber(int year, int sundayNumber)
        {
            DateTime date = new DateTime(year, 1, 1);
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            for (int i = 1; i < sundayNumber; i++)
            {
                date = date.AddDays(7);
            }
            return date;
        }

        public static List<(int, int)> GetLastSundaysOfYear(DateTime sundayDate, int duree)
        {
            List<(int, int)> last = new List<(int, int)>();
            List<(string month, int year, string nthSunday)> lastSundays = new List<(string, int, string)>();
            int year = sundayDate.Year;
            int month = sundayDate.Month;
            DateTime currentMonth = new DateTime(year, month, 1);

            DateTime endOfCurrentMonthExt = currentMonth.AddMonths(1).AddDays(-1);
            DateTime lastSundayOfMonthExt = endOfCurrentMonthExt.AddDays(-(int)endOfCurrentMonthExt.DayOfWeek + 7);
            int weekOfYearExt = GetWeekOfYear(lastSundayOfMonthExt);
            DateTime verify = GetDateFromSundayNumber(year, weekOfYearExt - 1);
            if (sundayDate >= verify)
            {
                Console.WriteLine(verify + " " + sundayDate);
                string sunday = $"{weekOfYearExt}-{year}";
                lastSundays.Add((Format(currentMonth, "MMMM"), year, sunday));
                currentMonth = currentMonth.AddMonths(1);
            }
            for (int i = month; i < duree+month; i++)
            {
                DateTime endOfCurrentMonth = currentMonth.AddMonths(1).AddDays(-1);
                DateTime lastSundayOfMonth = endOfCurrentMonth.AddDays(-(int)endOfCurrentMonth.DayOfWeek + 7);
                int weekOfYear = GetWeekOfYear(lastSundayOfMonth);
                last.Add((weekOfYear - 1, year));
                string nthSunday = $"{weekOfYear}-{year}";
                lastSundays.Add((Format(currentMonth, "MMMM"), year, nthSunday));
                currentMonth = currentMonth.AddMonths(1);
                if (i % 12 == 0)
                {
                    last[last.Count - 1] = (52, year);
                    year++;
                }
            }
            return last;
        }

        public static List<(int, int)> GetFirstSundaysOfYear(int annee)
        {
            List<(int, int)> first = new List<(int, int)>();
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDayOfMonth = new DateTime(annee, month, 1);
                int daysToAdd = (7 - (int)firstDayOfMonth.DayOfWeek) % 7;
                DateTime firstSundayOfMonth = firstDayOfMonth.AddDays(daysToAdd);
                int weekOfYear = GetWeekOfYear(firstSundayOfMonth);
                first.Add((weekOfYear, annee));
            }
            return first;
        }

        public static List<(int, int)> GetLastSundaysOfMonths(int year)
        {
            List<(int, int)> last = new List<(int, int)>();
            List<int> lastSundays = new List<int>();

            DateTime currentMonth = new DateTime(year, 1, 1);

            for (int month = 0; month < 12; month++)
            {
                DateTime endOfCurrentMonth = new DateTime(currentMonth.Year, currentMonth.Month, DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month));
                DateTime lastSundayOfMonth = endOfCurrentMonth.AddDays(-(int)endOfCurrentMonth.DayOfWeek);

                int weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(lastSundayOfMonth, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);

                last.Add((weekOfYear - 1, year));

                lastSundays.Add(weekOfYear);

                currentMonth = currentMonth.AddMonths(1);
            }

            last[last.Count - 1] = (52, year);
            return last;
        }


        private static int GetWeekOfYear(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        private static string Format(DateTime date, string format)
        {
            return date.ToString(format);
        }

        public static List<double> FindAllRakitraOfYear(int year)
        {
            string query = $"SELECT montant FROM rakitra r JOIN dimanche d ON r.idDimanche = d.idDimanche WHERE d.annee = {year}";
            try
            {
                using IDbConnection con = SqlServerConnectivity.NewConnection();
                con.Open();
                using IDbCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                using IDataReader reader = cmd.ExecuteReader();
                List<double> result = new List<double>();
                while (reader.Read())
                {
                    result.Add(reader.GetDouble(0));
                }
                return result;
            }
            catch (Exception error)
            {
                Console.Error.WriteLine("Error fetching rakitra:", error);
                throw new Exception("Error: ", error);
            }
        }

        public static double Proportions()
        {
            DemandePret demandePret = new DemandePret();
            demandePret.GetLastDemande();
            Dimanche dimanche = new Dimanche();
            dimanche.GetDimancheDemande(demandePret.IdDemande);

            List<double> rakitraVingtDeux = FindAllRakitraOfYear(2022);
            List<double> rakitraVingtTrois = FindAllRakitraOfYear(2023);
            List<double> rakitraVingtQuatre = FindAllRakitraOfYear(2024);

            List<double> proportions = new List<double>();
            for (int i = 1; i <= dimanche.NumeroDimanche; i++)
            {
                double tempValue = rakitraVingtQuatre[i - 1] / ((rakitraVingtDeux[i - 1] + rakitraVingtTrois[i - 1]) / 2);
                proportions.Add(tempValue);
            }

            double result = 0;
            foreach (double value in proportions)
            {
                result += value;
            }

            return result / proportions.Count;
        }

        public static List<double> FindRakitraResteDimanche(int numeroDimanche, List<List<double>> extensionAnnee = null)
        {
            List<double> reste = new List<double>();
            List<double> rakitraVingtDeux = FindAllRakitraOfYear(2022);
            List<double> rakitraVingtTrois = FindAllRakitraOfYear(2023);

            if (extensionAnnee != null && extensionAnnee.Count > 0)
            {
                Console.WriteLine("Elements of the list: " + string.Join(", ", rakitraVingtDeux)); 
                Console.WriteLine("Elements of the list: " + string.Join(", ", rakitraVingtTrois));
                List<List<double>> rakitras = new List<List<double>> { rakitraVingtDeux, rakitraVingtTrois };
                rakitras.AddRange(extensionAnnee);
                for (int i = 1; i < 53; i++)
                {
                    double temp = 0;
                    foreach (List<double> rakitra in rakitras)
                    {
                        temp += rakitra[i - 1];
                    }
                    reste.Add(temp / rakitras.Count);
                }
            }
            else
            {
                for (int i = numeroDimanche + 1; i < 53; i++)
                {
                    double tempValue = (rakitraVingtDeux[i - 1] + rakitraVingtTrois[i - 1]) / 2;
                    reste.Add(tempValue);
                }
            }
            return reste;
        }

        public static double TotalPretEnCours()
        {
            string query = "SELECT * FROM montantEnCours";
            try
            {
                using IDbConnection con = SqlServerConnectivity.NewConnection();
                con.Open();
                using IDbCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                    Console.WriteLine("ZIZI");
                using IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.IsDBNull(0)) return 0;
                    else return Convert.ToDouble(reader.GetDecimal(0));
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error fetching montantEnCours:", error);
            }
            return 0;
        }

/*        verifier depense du mois
            lister depenses du mois*/

        public static (int, int) Predictions(DemandePret demandePret)
        {
            double caisse = 0;
            double enCours = TotalPretEnCours();
            double caisseTemp = caisse - enCours;

            Dimanche dimanche = new Dimanche();
            dimanche.GetById(demandePret.IdDimanche);

            int numeroDimanche = dimanche.NumeroDimanche + 1;
            int annee = dimanche.Annee;

            List<double> caisseThisYear = new List<double>();
            List<List<double>> faminaniana = new List<List<double>>();
            List<(int, int, double)> remboursement = DetailsRemboursement.GetDetailsRemboursements();
            int indRemb = 0;
            
            List<(int, int)> finMois = GetLastSundaysOfMonths(annee);
            List<double> depensesFixe = DepenseFixe.GetTotalDepenseParMois();
            List<double> depensesVariable = DepenseVariable.GetTotalDepenseParMois();

            while (caisseTemp < demandePret.Montant)
            {
                List<double> tempFaminaniana = new List<double>();
                if (annee == dimanche.Annee)
                {
                    caisseThisYear = FindRakitraResteDimanche(numeroDimanche-1);
                    tempFaminaniana = FindAllRakitraOfYear(2024);
                }
                foreach (double rakitra in caisseThisYear)
                {
                    for (int i = 0; i < finMois.Count; i++)
                    {
                        if (finMois[i].Item1 == numeroDimanche && finMois[i].Item2 == annee)
                        {
                            Console.WriteLine($"Nanalana depense fixe de {depensesFixe[i]} tamin'ny {GetDateFromSundayNumber(annee, numeroDimanche)}");
                            Console.WriteLine($"Nanalana depense variable de {depensesVariable[i]} tamin'ny {GetDateFromSundayNumber(annee, numeroDimanche)}");
                            caisseTemp -= depensesFixe[i];
                            caisseTemp -= depensesVariable[i];
                        }
                    }
                    double rakitraPredicted = 0;
                    if (remboursement.Count > 0 && remboursement[indRemb].Item1 == numeroDimanche && remboursement[indRemb].Item2 == annee)
                    {
                        rakitraPredicted += rakitra * Proportions() + remboursement[indRemb].Item3;
                        indRemb++;
                    } else
                    {
                        rakitraPredicted += rakitra * Proportions();
                    }
                    Console.WriteLine(rakitraPredicted);
                    caisseTemp += rakitraPredicted;
                    if (caisseTemp > demandePret.Montant)
                    {
                        return (numeroDimanche, annee);
                    }
                    tempFaminaniana.Add(rakitraPredicted);
                    numeroDimanche += 1;
                    if (numeroDimanche % 52 == 0)
                    {
                        annee += 1;
                        numeroDimanche = 1;
                        finMois = GetFirstSundaysOfYear(annee);
                    }
                }
                if (numeroDimanche == 1)
                {
                    faminaniana.Add(tempFaminaniana);
                    Console.WriteLine(faminaniana);
                    Console.WriteLine(tempFaminaniana.Count);
                    caisseThisYear = FindRakitraResteDimanche(numeroDimanche, faminaniana);
                }
            }
            return (0, 0);
        }

        public static void PayementPret()
        {
            DemandePret demandePret = new DemandePret();
            demandePret.GetLastDemande();

            (int numeroDimanche, int annee) = Predictions(demandePret);
            PretEnCours.InsertPretEnCours(demandePret.IdDemande, numeroDimanche, annee, demandePret.Montant);
            PretEnCours pretEnCours = new PretEnCours();
            pretEnCours.GetLastPretEnCours();
            DemandePret demande = new DemandePret();
            demande.GetDemandeById(pretEnCours.IdDemande);
            DateTime receptionArgent = GetMondayDateFromSundayNumber(pretEnCours.Annee, pretEnCours.NumeroDimanche);
            List<(int, int)> dateRemboursement = GetLastSundaysOfYear(receptionArgent, demande.DureeRemboursement);
            foreach(var item in dateRemboursement)
            {
                DetailsRemboursement.InsertDetails(demande.IdDemande, item.Item1, item.Item2, demande.Montant / demande.DureeRemboursement);
            }
        }
    }
}
