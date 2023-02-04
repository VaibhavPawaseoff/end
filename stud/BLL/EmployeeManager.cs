namespace BLL;
using BOL;
using DAL;
public class StudentManager
{
    public  List<Student>GetAllStudents(){
        List<Student> allstudents=new List<Student>();
        allstudents=DBManager.GetAllStudents();
        return allstudents;
    }
    public  Student GetStudent(int id){
        // List<Student> allstudents=new List<Student>();
        // Student foundEmp=allstudents.Find((stud)=>stud.Id==id);
        // return foundEmp;
        Student foundEmp=DBManager.GetStudent(id);
        return foundEmp;
    }
    public bool Insert(Student stud){
        return DBManager.Insert(stud);

    }
    public bool Update(Student stud){
        return DBManager.Update(stud);
    }
    public bool Delete(int id){
        return DBManager.Delete(id);
    }

}
