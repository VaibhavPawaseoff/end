namespace BLL;
using BOL;
using DAL;
public class EmployeeManager
{
    public  List<Employee>GetAllEmployees(){
        List<Employee> allemployees=new List<Employee>();
        allemployees=DBManager.GetAllEmployees();
        return allemployees;
    }
    public  Employee GetEmployee(int id){
        // List<Employee> allemployees=new List<Employee>();
        // Employee foundEmp=allemployees.Find((emp)=>emp.Id==id);
        // return foundEmp;
        Employee foundEmp=DBManager.GetEmployee(id);
        return foundEmp;
    }
    public bool Insert(Employee emp){
        return DBManager.Insert(emp);

    }
    public bool Update(Employee emp){
        return DBManager.Update(emp);
    }
    public bool Delete(int id){
        return DBManager.Delete(id);
    }

}
