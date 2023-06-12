using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class RoleDataConection
    {
        public RoleDataConection() { }

        public static bool Registrar(ROLE RoleModel) {

            using (SqlConnection oconection = new SqlConnection(Conection.rutaconection)) 
            {
                SqlCommand cmd = new SqlCommand("USP_INSERT_ROLE", oconection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", RoleModel.Name);
                cmd.Parameters.AddWithValue("@Active", RoleModel.ActiveId);

                try
                {
                    oconection.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            } 
        }

        public static List<ROLE> Listar(RoleRquest RoleModel)
        { 
            List<ROLE> list = new List<ROLE>();
            using (SqlConnection oconection = new SqlConnection(Conection.rutaconection))
            {
                SqlCommand cmd = new SqlCommand("Usp_Sel_Role", oconection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", RoleModel.Id);
                cmd.Parameters.AddWithValue("@Name", RoleModel.Name);
                cmd.Parameters.AddWithValue("@Active", RoleModel.ActiveId);
                cmd.Parameters.AddWithValue("@PageNumber", 1);
                cmd.Parameters.AddWithValue("@PageSize", 1111);
                //cmd.Parameters.AddWithValue("@Sort", null);
                //cmd.Parameters.AddWithValue("@Order", null);
                //cmd.Parameters.AddWithValue("@MaxPage", null);
                //cmd.Parameters.AddWithValue("@TotalRows", null);

                try
                {
                    oconection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {

                    while (dr.Read())
                        {
                            list.Add( new ROLE() { 
                            Id = Convert.ToInt32( dr[0] ) ,
                            Name = dr[1].ToString() ,
                            ActiveId= Convert.ToInt32(dr[2] ),
                            Active = dr[3].ToString()
                            } );

                        }
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    return list;
                }

            }
        }
    }
}