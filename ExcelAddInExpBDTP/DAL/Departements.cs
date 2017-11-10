using ExcelAddInExpBDTP.BIZ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAddInExpBDTP.DAL {
    public class Departements {

        SqlConnection _connexion;

        public Departements(SqlConnection connexion) {
            _connexion = connexion;
        }

        public IList<Departement> GetDepartements(bool avecNom) {
            List<Departement> lstDep = new List<Departement>(); //SqlConnection connexion = null;
            try {

                SqlCommand commande = _connexion.CreateCommand();
                commande.CommandText = "SELECT * FROM departement";
                SqlDataReader reader = commande.ExecuteReader();

                if (avecNom) { // AVEC NOM
                    while (reader.Read()) {
                        lstDep.Add(new Departement {
                            id = (int)reader["id"],
                            nom = (string)reader["nom"]
                        });
                    }
                } else { // AVEC VILLE
                    while (reader.Read()) {
                        lstDep.Add(new Departement {
                            id = (int)reader["id"],
                            ville = (string)reader["ville"]
                        });
                    }
                }
                reader.Close();

            } catch (Exception e) {
                string Msg = e.Message;
            }

            return lstDep; // retourne une liste vide en cas d'erreur (ou si elle est vide)
        }

        public int Add(Departement dep) {
            int nbRecords = 0; //SqlConnection connexion = null;
            try {
                string sql = "INSERT INTO dbo.departement(id,nom,ville) VALUES(@id, @nom, @ville)";
                SqlCommand cmd = new SqlCommand(sql, _connexion);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = dep.id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 15).Value = dep.nom;
                cmd.Parameters.Add("@ville", SqlDbType.VarChar, 20).Value = dep.ville;
                cmd.CommandType = CommandType.Text;

                // exécution de la commande SQL
                nbRecords = cmd.ExecuteNonQuery();

            } catch (Exception e) {
                string Msg = e.Message;
            }

            return nbRecords;
        }


    }
}
