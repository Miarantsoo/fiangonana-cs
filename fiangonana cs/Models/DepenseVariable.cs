using fiangonana_cs.database;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace fiangonana_cs.Models
{
    public class DepenseVariable
    {
        private int idFixe;
        private int idCategorie;
        private int mois;
        private int annee;
        private double montant;

        public int IdFixe
        {
            get { return idFixe; }
            set { idFixe = value; }
        }
        public int IdCategorie
        {
            get { return idCategorie; }
            set { idCategorie = value; }
        }
        public int Mois
        {
            get { return mois; }
            set { mois = value; }
        } 
        public int Annee
        {
            get { return annee; }
            set { annee = value; }
        }
        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public static List<List<double>> FindAllDepensesOfYear(int year)
        {
            List<List<double>> result = new();
            List<Categorie> categories = Categorie.GetCategorieByType("variable");
            for (int i = 0; i < categories.Count; i++)
            {
                string query = $"SELECT montant FROM depenseVariable dv JOIN categorie c ON c.idCategorie = dv.idCategorie WHERE dv.annee = {year} and c.idCategorie = {categories[i].IdCategorie}";
                try
                {
                    using IDbConnection con = SqlServerConnectivity.NewConnection();
                    con.Open();
                    using IDbCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    using IDataReader reader = cmd.ExecuteReader();
                    List<double> temp = new List<double>();
                    while (reader.Read())
                    {
                        temp.Add(reader.GetDouble(0));
                    }
                    result.Add(temp);
                }
                catch (Exception error)
                {
                    Console.Error.WriteLine("Error fetching rakitra:", error);
                    throw new Exception("Error: ", error);
                }                
            }
            return result;
        }

        public static List<double> Proportions()
        {
            List<double> result = new();
            DemandePret demandePret = new DemandePret();
            demandePret.GetLastDemande();
            Dimanche dimanche = new Dimanche();
            dimanche.GetDimancheDemande(demandePret.IdDemande);

            List<List<double>> depensesVingtDeux = FindAllDepensesOfYear(2022);
            List<List<double>> depensesVingtTrois = FindAllDepensesOfYear(2023);
            List<List<double>> depensesVingtQuatre = FindAllDepensesOfYear(2024);
            for (int i = 0; i < depensesVingtTrois.Count; i++)
            {
                List<double> prop = new List<double>();
                for (int j = 0; j < depensesVingtQuatre[i].Count; j++)
                {
                    double tempValue = 0;
                    if (depensesVingtDeux[i].Count == 0)
                    {
                        tempValue += depensesVingtQuatre[i][j] / depensesVingtTrois[i][j];
                        
                    } else
                    {
                        tempValue += depensesVingtQuatre[i][j] / (depensesVingtTrois[i][j] + depensesVingtDeux[i][j]) / 2;
                    }
                    prop.Add(tempValue);
                }
                double temp = 0;
                foreach (double value in prop)
                {
                    temp += value;
                }

                result.Add(temp / prop.Count);
            }
            return result;
        }

        public static List<(int, List<double>)> GetDepensesVariables()
        {
            List<(int, List <double>)> result = new();
            List<List<double>> depensesVingtTrois = FindAllDepensesOfYear(2023);
            List<List<double>> depensesVingtQuatre = FindAllDepensesOfYear(2024);
            List<double> proportions = Proportions();
            for (int i = 0; i < depensesVingtQuatre.Count; i++)
            {
                for (int j = depensesVingtQuatre[i].Count; j < depensesVingtTrois[i].Count; j++)
                {
                    depensesVingtQuatre[i].Add(depensesVingtTrois[i][j] * proportions[i]);
                }
                result.Add((12 / depensesVingtQuatre[i].Count, depensesVingtQuatre[i]));
            }
            return result;
        }

        public static List<double> GetTotalDepenseParMois()
        {
            List<double> result = new(Enumerable.Repeat(0.0, 12));
            List<(int, List<double>)> depenseVariable = GetDepensesVariables();
            for (int j = 0; j < depenseVariable.Count; j++)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    for (int k = 0; k < depenseVariable[j].Item2.Count; k++)
                    {
                        if ((i+1) % depenseVariable[j].Item1 == 0)
                        {
                            Console.WriteLine(depenseVariable[j].Item2[k]+" "+i);
                            result[i] += depenseVariable[j].Item2[k];
                            i += depenseVariable[j].Item1;
                        }
                    }
                }
            }
            return result;
        }

    }
}
