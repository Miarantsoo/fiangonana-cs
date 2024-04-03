using System;
using System.Data;
using System.Data.Odbc;
using fiangonana_cs.database;

namespace fiangonana_cs.Models
{
    public class DemandePret
    {
        private int idDemande;
        private int idMpiangona;
        private int idDimanche;
        private double montant;
        private int dureeRemboursement;

        public int IdDemande
        {
            get { return idDemande; }
            set { idDemande = value; }
        }

        public int IdMpiangona
        {
            get { return idMpiangona; }
            set { idMpiangona = value; }
        }

        public int IdDimanche
        {
            get { return idDimanche; }
            set { idDimanche = value; }
        }

        public double Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public int DureeRemboursement
        {
            get { return dureeRemboursement; }
            set { dureeRemboursement = value; }
        }

        public DemandePret()
        {
            
        }

        public DemandePret(int idDemande, int idMpiangona, int idDimanche, double montant, int dureeRemboursement)
        {
            IdDemande = idDemande;
            IdMpiangona = idMpiangona;
            IdDimanche = idDimanche;
            Montant = montant;
            DureeRemboursement = dureeRemboursement;
        }

        public static void InsertDemande(int idMpiangona, int idDimanche, double montant, int dureeRemboursement)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "INSERT INTO demandePret VALUES (NEXT VALUE FOR seq_demandePret, ?, ?, ?, ?)";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new OdbcParameter("@p1", idMpiangona));
            cmd.Parameters.Add(new OdbcParameter("@p2", idDimanche));
            cmd.Parameters.Add(new OdbcParameter("@p3", montant));
            cmd.Parameters.Add(new OdbcParameter("@p4", dureeRemboursement));
            cmd.ExecuteNonQuery();
        }

        public void GetLastDemande()
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "SELECT * FROM demandePret WHERE idDemande = (SELECT current_value FROM sys.sequences WHERE name = 'seq_demandePret')";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdDemande = reader.GetInt32(reader.GetOrdinal("idDemande"));
                IdMpiangona = reader.GetInt32(reader.GetOrdinal("idMpiangona"));
                IdDimanche = reader.GetInt32(reader.GetOrdinal("idDimanche"));
                Montant = reader.GetDouble(reader.GetOrdinal("montant"));
                DureeRemboursement = reader.GetInt32(reader.GetOrdinal("dureeRemboursement"));
            }
        }

        public void GetDemandeById(int idDemande)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = $"SELECT * FROM demandePret WHERE idDemande = {idDemande}";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdDemande = reader.GetInt32(reader.GetOrdinal("idDemande"));
                IdMpiangona = reader.GetInt32(reader.GetOrdinal("idMpiangona"));
                IdDimanche = reader.GetInt32(reader.GetOrdinal("idDimanche"));
                Montant = reader.GetDouble(reader.GetOrdinal("montant"));
                DureeRemboursement = reader.GetInt32(reader.GetOrdinal("dureeRemboursement"));
            }
        }
    }
}
