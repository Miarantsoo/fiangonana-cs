using System;
using System.Data;
using System.Data.Odbc;
using fiangonana_cs.database;

namespace fiangonana_cs.Models
{
    public class Dimanche
    {
        private int idDimanche;
        private int numeroDimanche;
        private int annee;
        private string typeDimanche;

        public int IdDimanche
        {
            get { return idDimanche; }
            set { idDimanche = value; }
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

        public string TypeDimanche
        {
            get { return typeDimanche; }
            set { typeDimanche = value; }
        }

        public Dimanche()
        {
            
        }

        public Dimanche(int idDimanche, int numeroDimanche, int annee, string typeDimanche)
        {
            IdDimanche = idDimanche;
            NumeroDimanche = numeroDimanche;
            Annee = annee;
            TypeDimanche = typeDimanche;
        }

        public void GetById(int id)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "SELECT * FROM dimanche WHERE idDimanche = ?";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new OdbcParameter("@p1", id));
            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdDimanche = reader.GetInt32(reader.GetOrdinal("idDimanche"));
                NumeroDimanche = reader.GetInt32(reader.GetOrdinal("numeroDimanche"));
                Annee = reader.GetInt32(reader.GetOrdinal("annee"));
                TypeDimanche = reader.GetString(reader.GetOrdinal("typeDimanche"));
            }
        }

        public void GetLastDimanche()
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "SELECT * FROM dimanche WHERE idDimanche = (SELECT current_value FROM sys.sequences WHERE name = 'seq_dimanche')";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdDimanche = reader.GetInt32(reader.GetOrdinal("idDimanche"));
                NumeroDimanche = reader.GetInt32(reader.GetOrdinal("numeroDimanche"));
                Annee = reader.GetInt32(reader.GetOrdinal("annee"));
                TypeDimanche = reader.GetString(reader.GetOrdinal("typeDimanche"));
            }
        }

        public void GetDimancheDemande(int id)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "SELECT dimanche.idDimanche as id, numeroDimanche, annee, typeDimanche from dimanche join demandePret on dimanche.idDimanche = demandePret.idDimanche where idDemande = ?";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new OdbcParameter("@p1", id));
            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdDimanche = reader.GetInt32(reader.GetOrdinal("id"));
                NumeroDimanche = reader.GetInt32(reader.GetOrdinal("numeroDimanche"));
                Annee = reader.GetInt32(reader.GetOrdinal("annee"));
                TypeDimanche = reader.GetString(reader.GetOrdinal("typeDimanche"));
            }
        }
    }
}
