using System;
using System.Data;
using System.Data.Odbc;
using fiangonana_cs.database;

namespace fiangonana_cs.Models
{
    public class PretEnCours
    {
        private int idPretEnCours;
        private int idDemande;
        private int numeroDimanche;
        private int annee;
        private double montant;

        public int IdPretEnCours
        {
            get { return idPretEnCours; }
            set { idPretEnCours = value; }
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

        public PretEnCours()
        {
            
        }

        public PretEnCours(int idPretEnCours, int idDemande, int numeroDimanche, int annee, double montant)
        {
            IdPretEnCours = idPretEnCours;
            IdDemande = idDemande;
            NumeroDimanche = numeroDimanche;
            Annee = annee;
            Montant = montant;
        }

        public static void InsertPretEnCours(int idDemande, int numeroDimanche, int annee, double montant)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "INSERT INTO pretEnCours VALUES (NEXT VALUE FOR seq_pretEnCours, ?, ?, ?, ?)";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new OdbcParameter("@p1", idDemande));
            cmd.Parameters.Add(new OdbcParameter("@p2", numeroDimanche));
            cmd.Parameters.Add(new OdbcParameter("@p3", annee));
            cmd.Parameters.Add(new OdbcParameter("@p4", montant));
            cmd.ExecuteNonQuery();
        }

        public void GetLastPretEnCours()
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "SELECT * FROM pretEnCours WHERE idPretEnCours = (SELECT current_value FROM sys.sequences WHERE name = 'seq_pretEnCours')";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdPretEnCours = reader.GetInt32(reader.GetOrdinal("idPretEnCours"));
                IdDemande = reader.GetInt32(reader.GetOrdinal("idDemande"));
                NumeroDimanche = reader.GetInt32(reader.GetOrdinal("numeroDimanche"));
                Annee = reader.GetInt32(reader.GetOrdinal("annee"));
                Montant = reader.GetDouble(reader.GetOrdinal("montant"));
            }
        }
    }
}
