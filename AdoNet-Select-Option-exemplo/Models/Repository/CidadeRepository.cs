using AdoNet_Select_Option_exemplo.Models.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdoNet_Select_Option_exemplo.Models.Repository
{
    public class CidadeRepository
    {

        public static List<Cidade> Get()
        {
            StringBuilder sql = new StringBuilder();
            List<Cidade> cidades = new List<Cidade>();

            sql.Append("Select * from Cidades ");

            MySqlDataReader dr = ConnectionCup.MySql.MySql.getLista(sql.ToString());

            while (dr.Read())
            {
                cidades.Add(new Cidade
                {
                    id = dr.GetInt16(dr.GetOrdinal("idCidade")),
                    nome = dr.GetString(dr.GetOrdinal("nomeCidade"))
                });
            }
            dr.Dispose();
            return cidades;
        }


    }
}