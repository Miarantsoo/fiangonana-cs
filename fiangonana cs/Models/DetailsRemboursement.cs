using fiangonana_cs.database;
using System.Data.Odbc;
using System.Data;

namespace fiangonana_cs.Models
{
    public class DetailsRemboursement
    {
        private int idDetail;
        private int idDemande;
        private int numeroDimanche;
        private int annee;
        private double montant;

        public int IdDetail
        {
            get { return idDetail; }
            set { idDetail = value; }
        }

        public int IdDemande
        {
            get { return idDemande; }
            set { idDemande = value; }
        }

        public int NumeroDimanche
        {
            get { return numeroDimanche; }
            set { numeroDimanche = value; }
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

        public DetailsRemboursement()
        {
            
        }

        public DetailsRemboursement(int idDetail, int idDemande, int numeroDimanche, int annee, double montant)
        {
            IdDetail = idDetail;
            IdDemande = idDemande;
            NumeroDimanche = numeroDimanche;
            Annee = annee;
            Montant = montant;
        }

        public static void InsertDetails(int idDemande, int numeroDimanche, int annee, double montant)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "INSERT INTO detailsRemboursement VALUES (NEXT VALUE FOR seq_detailsRemboursement, ?, ?, ?, ?)";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new OdbcParameter("@p1", idDemande));
            cmd.Parameters.Add(new OdbcParameter("@p2", numeroDimanche));
            cmd.Parameters.Add(new OdbcParameter("@p3", annee));
            cmd.Parameters.Add(new OdbcParameter("@p4", montant));
            cmd.ExecuteNonQuery();
        }

        public static List<(int, int, double)> GetDetailsRemboursements()
        {
            List<(int, int, double)> result = new();
            string query = " select numeroDimanche, annee, sum(montant) as montant from detailsRemboursement group by numeroDimanche, annee ";
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            using IDbCommand com = conn.CreateCommand();
            com.CommandText = query;
            using IDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                int numeroDimanche = reader.GetInt32(reader.GetOrdinal("numeroDimanche"));
                int annee = reader.GetInt32(reader.GetOrdinal("annee"));
                double montant = reader.GetDouble(reader.GetOrdinal("montant"));
                result.Add((numeroDimanche, annee, montant));
            }
            result.Add((0, 0, 0));
            return result;
        }

    }
}
