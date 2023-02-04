namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public class DBManager{
        public static string conString=@"server=localhost;port=3306;user=root;password=root123;database=Student";
        public static List<Student> GetAllStudents(){
            List<Student> allStudents = new List<Student>();
             MySqlConnection con = new MySqlConnection();
             con.ConnectionString=conString;
             try{
                DataSet ds = new DataSet();
                MySqlCommand cmd= new MySqlCommand();
                cmd.Connection=con;
                string query ="SELECT * FROM stud";
                cmd.CommandText=query;
                MySqlDataAdapter da=new MySqlDataAdapter();
                da.SelectCommand=cmd;
                da.Fill(ds);
                DataTable dt =ds.Tables[0];
                DataRowCollection rows=dt.Rows;
                foreach(DataRow row in rows){
                    int id=int.Parse(row["id"].ToString());
                    string name=row["name"].ToString();
                    string email=row["email"].ToString();
                    string password=row["password"].ToString();
                    Student stud=new Student{
                                                Id=id,
                                                Name=name,
                                                Email=email,
                                                Password=password
                    };
                    allStudents.Add(stud);


                }
             }
             catch(Exception ee){
                Console.WriteLine(ee.Message);
             }
            return allStudents;
        }
        public static Student GetStudent(int id){
            Student stud=null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="SELECT * FROM stud WHERE id=" + id;
                con.Open();
                MySqlCommand command=new MySqlCommand(query,con);
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read()){
                    id=int.Parse(reader["id"].ToString());
                    string name=reader["name"].ToString();
                    string email=reader["email"].ToString();
                    string password=reader["password"].ToString();
                    stud = new Student{
                        Id=id,
                        Name=name,
                        Email=email,
                        Password=password
                    };
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                con.Close();
            }

            return stud;
        }
        public static bool Insert(Student stud){
            bool status=false;
            string query="INSERT INTO stud (id,name,email,password)"+"VALUES("+stud.Id+",'"+stud.Name+"','"+stud.Email+"','"+stud.Password+"')";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                con.Open();
                  MySqlCommand command=new MySqlCommand(query,con);
                command.ExecuteNonQuery();
                status=true;

            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                con.Close();
            }
            return status;
        }
        public static bool Update(Student stud){
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="UPDATE stud SET id="+stud.Id+",name='"+stud.Name+"',email='"+stud.Email+"',password='"+stud.Password+"' WHERE id= " +  stud.Id;
                    MySqlCommand command= new MySqlCommand(query,con);
                con.Open();
                command.ExecuteNonQuery();
                status=true;

            }
            catch(Exception e){
                Console.WriteLine(e.Message);

            }
            finally{
                con.Close();
            }
            return status;
        }
        public static bool Delete(int id){
            bool status=false;
            MySqlConnection con=new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="DELETE FROM stud WHERE Id=" +id;
                MySqlCommand command= new MySqlCommand(query,con);
                con.Open();
                command.ExecuteNonQuery();
                status=true;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                con.Close();
            }

            return status;
        }
}