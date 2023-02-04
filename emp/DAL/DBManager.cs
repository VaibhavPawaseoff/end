namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public class DBManager{
        public static string conString=@"server=localhost;port=3306;user=root;password=root123;database=Employee";
        public static List<Employee> GetAllEmployees(){
            List<Employee> allEmployees = new List<Employee>();
             MySqlConnection con = new MySqlConnection();
             con.ConnectionString=conString;
             try{
                DataSet ds = new DataSet();
                MySqlCommand cmd= new MySqlCommand();
                cmd.Connection=con;
                string query ="SELECT * FROM emp";
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
                    Employee emp=new Employee{
                                                Id=id,
                                                Name=name,
                                                Email=email,
                                                Password=password
                    };
                    allEmployees.Add(emp);


                }
             }
             catch(Exception ee){
                Console.WriteLine(ee.Message);
             }
            return allEmployees;
        }
        public static Employee GetEmployee(int id){
            Employee emp=null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="SELECT * FROM emp WHERE id=" + id;
                con.Open();
                MySqlCommand command=new MySqlCommand(query,con);
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read()){
                    id=int.Parse(reader["id"].ToString());
                    string name=reader["name"].ToString();
                    string email=reader["email"].ToString();
                    string password=reader["password"].ToString();
                    emp = new Employee{
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

            return emp;
        }
        public static bool Insert(Employee emp){
            bool status=false;
            string query="INSERT INTO emp (id,name,email,password)"+"VALUES("+emp.Id+",'"+emp.Name+"','"+emp.Email+"','"+emp.Password+"')";
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
        public static bool Update(Employee emp){
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="UPDATE emp SET id="+emp.Id+",name='"+emp.Name+"',email='"+emp.Email+"',password='"+emp.Password+"' WHERE id= " +  emp.Id;
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
                string query="DELETE FROM emp WHERE Id=" +id;
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