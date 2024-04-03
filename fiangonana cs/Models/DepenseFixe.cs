using fiangonana_cs.database;
using System.Data;

namespace fiangonana_cs.Models
{
    public class DepenseFixe
    {
        private int idFixe;
        private int idCategorie;
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
        public double Montant
        {
            get { return montant; } 
            set { montant = value; }
        }

        public static List<(int, double)> GetDepensesFixe()
        {
            List<(int, double)> result = new();
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            using IDbCommand cmd = conn.CreateCommand();
            string query = "select 12/c.frequence as freq, df.montant from depensefixe df join categorie c on c.idcategorie = df.idcategorie";
            cmd.CommandText = query;
            using IDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                int freq = reader.GetInt32(reader.GetOrdinal("freq"));
                double montant = reader.GetDouble(reader.GetOrdinal("montant"));
                result.Add((freq, montant));
            }
            return result;
        }

        public static List<double> GetTotalDepenseParMois()
        {
            List<double> result = new(Enumerable.Repeat(0.0, 12));
            List<(int, double)> depenseFixe = GetDepensesFixe();
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < depenseFixe.Count; j++)
                {
                    if ((i) % depenseFixe[j].Item1 == 0)
                    {
                        result[i] += depenseFixe[j].Item2;
                    }
                }

            }
            return result;
        }

    }
}
