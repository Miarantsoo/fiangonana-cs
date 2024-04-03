using fiangonana_cs.database;
using System.Data;

namespace fiangonana_cs.Models
{
    public class Categorie
    {
        private int idCategorie;
        private string nom;
        private string type;
        private int frequence;

        public int IdCategorie { get {  return idCategorie; } set { idCategorie = value; } }
        public string Nom{ get {  return nom; } set { nom = value; } }
        public string Type { get {  return type; } set { type = value; } }
        public int Frequence { get {  return frequence; } set { frequence = value; } }

        public Categorie()
        {
            
        }

        public Categorie(int idCategorie, string nom, string type, int frequence)
        {
            IdCategorie = idCategorie;
            Nom = nom;
            Type = type;
            Frequence = frequence;
        }

        public void GetCategorieById(int id)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            using IDbCommand cmd = conn.CreateCommand();
            string query = $"SELECT * FROM categorie WHERE idCategorie = {id}";
            cmd.CommandText = query;
            using IDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                IdCategorie = dataReader.GetInt32(dataReader.GetOrdinal("idCategorie"));
                Nom = dataReader.GetString(dataReader.GetOrdinal("nom"));
                Type = dataReader.GetString(dataReader.GetOrdinal("type"));
                Frequence = dataReader.GetInt32(dataReader.GetOrdinal("frequence"));
            }
        }

        public static List<Categorie> GetCategorieByType(string type)
        {
            List<Categorie> result = new();
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            using IDbCommand cmd = conn.CreateCommand();
            string query = $"SELECT * FROM categorie WHERE type = '{type}'";
            cmd.CommandText = query;
            using IDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                int idCategorie = dataReader.GetInt32(dataReader.GetOrdinal("idCategorie"));
                string nom = dataReader.GetString(dataReader.GetOrdinal("nom"));
                string typee = dataReader.GetString(dataReader.GetOrdinal("type"));
                int frequence = dataReader.GetInt32(dataReader.GetOrdinal("frequence"));
                result.Add(new Categorie(idCategorie, nom, typee, frequence));
            }
            return result;
        }
    }
}
