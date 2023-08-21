using FingerprintCFF.entities.repositories.abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FingerprintCFF.entities.models;
using System.Data.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Windows.Forms;

namespace FingerprintCFF.entities.repositories
{
    internal class FingerPrintRepository: IFingerPrintRepository
    {
        string _cadenaConexion;
        public DbSet<UserFingerprint> UserFingerprints { get; set; }
        public string CadenaConexion
        {
            get
            {
                if (_cadenaConexion == null)
                {
                    _cadenaConexion = ConfigurationManager.ConnectionStrings["Conex"].ConnectionString;
                }
                return _cadenaConexion;
            }
            set { _cadenaConexion = value; }
        }

        public int CreateHuella(UserFingerprint userFingerprint)
        {
            try
            {
               
                string query = "Update auth.users " +
                                "set fingerprint = @fingerprint, created_fingerprint = @created_fingerprint where code_student = @code_student;";
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@code_student", userFingerprint.CodeStudent);
                    cmd.Parameters.AddWithValue("@fingerprint", userFingerprint.Fingerprint);
                    cmd.Parameters.AddWithValue("@created_fingerprint", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        public List<UserFingerprint> GetFingerPrints()
        {
            try
            {
                string query = "SELECT dni, code_student, fingerprint from auth.users";
                List<UserFingerprint> list = new List<UserFingerprint>();
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();

                    while (reader != null && reader.HasRows && reader.Read())
                    {
                        UserFingerprint data = new UserFingerprint
                        {
                            Dni = (string)reader["Dni"],
                            CodeStudent = (string)reader["code_student"]
                        };
                        list.Add(data);
                    }

                    con.Close();
                }

                return list;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<UserFingerprint> GetFingerPrintByVerify(byte[] fingerByte)
        {
            try
            {
                string query = "SELECT dni, code_student from auth.users where code_student = @code_student";
                List<UserFingerprint> list = new List<UserFingerprint>();
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@code_student", fingerByte);
                    var reader = cmd.ExecuteReader();

                    while (reader != null && reader.HasRows && reader.Read())
                    {
                        UserFingerprint data = new UserFingerprint
                        {
                            Dni = (string)reader["Dni"],
                            CodeStudent = (string)reader["code_student"]
                        };
                        list.Add(data);
                    }

                    con.Close();
                }

                return list;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<UserFingerprint> GetFingerPrintAll()
        {
            try
            {
                string query = "SELECT id, dni, code_student, fingerprint from auth.users";
                List<UserFingerprint> list = new List<UserFingerprint>();
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    byte[] FingerprintValue =  new byte[0];
                    while (reader != null && reader.HasRows && reader.Read())
                    {

                        if (reader["fingerprint"] != DBNull.Value)
                        {
                            FingerprintValue = (byte[])reader["fingerprint"];
                        } 
                        UserFingerprint data = new UserFingerprint
                        {
                            Id = reader["id"].ToString(),
                            Dni = (string)reader["dni"],
                            CodeStudent = (string)reader["code_student"],
                            Fingerprint = FingerprintValue

                        };
                        list.Add(data);
                    }

                    con.Close();
                }

                return list;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<EventModel> GetEventsAll()
        {
            try
            {
                string query = "SELECT id, name, description, created_at from cfg.events";
                List<EventModel> list = new List<EventModel>();
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    while (reader != null && reader.HasRows && reader.Read())
                    {

                      
                        EventModel data = new EventModel
                        {
                            Id = reader["id"].ToString(),
                            Name = reader["name"].ToString(),
                            Description = reader["description"].ToString(),
                            CreatedAt = (DateTime)reader["created_at"],
                        };
                        list.Add(data);
                    }

                    con.Close();
                }

                return list;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int CreateAttendanceEventUser(AttendandeModel attendandeModel)
        {
            try
            {

                string query = "Insert into entity.attendance_event_users(id_user, id_event, user_id) " +
                                "values(@id_user, @id_event, @user_id);";
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_user", attendandeModel.IdUser);
                    cmd.Parameters.AddWithValue("@id_event", attendandeModel.IdEvent);
                    cmd.Parameters.AddWithValue("@user_id", attendandeModel.UserId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
