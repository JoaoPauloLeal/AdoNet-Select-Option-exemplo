using AdoNet_Select_Option_exemplo.Models.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdoNet_Select_Option_exemplo.Models.Repository
{
    public class AutorRepository
    {
        public List<Autor> Get()
        {
            StringBuilder sql = new StringBuilder();
            List<Autor> autores = new List<Autor>();

            sql.Append("select a.idAutor, a.nome, a.endereco, c.idCidade, c.nomeCidade ");
            sql.Append("From autores a ");
            sql.Append("       inner join cidades c ");
            sql.Append("          on a.idCidade = c.idCidade ");

            MySqlDataReader dr = ConnectionCup.MySql.MySql.getLista(sql.ToString());

            while (dr.Read())
            {
                autores.Add(new Autor
                {
                    id = dr.GetInt16(dr.GetOrdinal("idAutor")),
                    nome = dr.GetString(dr.GetOrdinal("Nome")),
                    endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : dr.GetString(dr.GetOrdinal("Endereco")),
                    cidade = new Cidade
                    {
                        id = dr.GetInt16(dr.GetOrdinal("idCidade")),
                        nome = dr.GetString(dr.GetOrdinal("nomeCidade"))
                    }
                });
            }
            dr.Dispose();
            return autores;
        }

        public void Create(Autor pAutor)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into Autores (nome,endereco, idCidade) ");
            sql.Append("Values (@nome, @endereco, @idCidade)");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nome", pAutor.nome);
            cmm.Parameters.AddWithValue("@endereco", pAutor.endereco);
            cmm.Parameters.AddWithValue("@idCidade", pAutor.cidade.id);

            cmm.CommandText = sql.ToString();

            ConnectionCup.MySql.MySql.ExecutarCommando(cmm);


        }

    }
}