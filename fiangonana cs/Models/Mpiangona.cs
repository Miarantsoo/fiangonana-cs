using System.Text;

using System.Data;
using System.Security.Cryptography;
using fiangonana_cs.database;
using System.Data.Odbc;

namespace fiangonana_cs.Models
{
    public class Mpiangona
    {
        private int? idMpiangona;
        private string? nom;
        private string? prenom;
        private DateTime? dateNaissance;
        private string? adresse;
        private string? email;
        private string? password;
        private string? role;

        public int? IdMpiangona
        {
            get { return idMpiangona; }
            set { idMpiangona = value; }
        }

        public string? Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string? Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime? DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        public string? Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string? Email
        {
            get { return email; }
            set { email = value; }
        }

        public string? Password
        {
            get { return password; }
            set { password = value; }
        }

        public string? Role
        {
            get { return role; }
            set { role = value; }
        }

        public Mpiangona()
        {
              
        }

        public Mpiangona(int idMpiangona, string nom, string prenom, DateTime dateNaissance, string adresse, string email, string password, string role)
        {
            IdMpiangona = idMpiangona;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Email = email;
            Password = password;
            Role = role;
        }

        public bool GetByPassword(string email, string password)
        {
            using IDbConnection conn = SqlServerConnectivity.NewConnection();
            conn.Open();
            string query = "SELECT * FROM mpiangona WHERE email = ? AND mdp = ?";
            using IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.Add(new OdbcParameter("@p1", email));
            cmd.Parameters.Add(new OdbcParameter("@p2", HashPassword(password)));

            using IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IdMpiangona = reader.GetInt32(reader.GetOrdinal("idMpiangona"));
                Nom = reader.GetString(reader.GetOrdinal("nom"));
                Prenom = reader.GetString(reader.GetOrdinal("prenom"));
                DateNaissance = reader.GetDateTime(reader.GetOrdinal("dateNaissance"));
                Adresse = reader.GetString(reader.GetOrdinal("adresse"));
                Email = reader.GetString(reader.GetOrdinal("email"));
                Password = reader.GetString(reader.GetOrdinal("mdp"));
                Role = reader.GetString(reader.GetOrdinal("role"));
                return true;
            }
            return false;
        }

        private static string HashPassword(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
