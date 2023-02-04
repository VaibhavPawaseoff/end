using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOL;
using BLL;

namespace StudApp.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        StudentManager em= new StudentManager();
        List<Student>students=em.GetAllStudents();
        this.ViewData["students"]=students;

        return View();
    }

    public IActionResult Details(int id)
    {
        StudentManager em=new StudentManager();
        Student stud =em.GetStudent(id);
        this.ViewData["student"]=stud;
        return View();
    }
      public IActionResult Insert()
    {
        Student stud = new Student();
        return View(stud);
    }
    [HttpPost]
    public IActionResult Insert(Student stud)
    {
        StudentManager em=new StudentManager();
        // Student student =em.Update(stud);
        // this.ViewData["student"]=student;
        // return View();
        if(em.Insert(stud)){
            return RedirectToAction("Index");
        }
        return View();
         
        
    }
     public IActionResult Login()
    {
        
        return View();
    }
    [HttpPost]
     public IActionResult Login(string Email,string Password)
    {
        StudentManager em= new StudentManager();
        List<Student>students=em.GetAllStudents();
       foreach (Student stud in students)
       {
          if(stud.Email.Equals(Email)&&stud.Password.Equals(Password)){
            return RedirectToAction("Index");
          }
       }
       return View();
    }
    public IActionResult Delete()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        StudentManager em= new StudentManager();
       if(em.Delete(id)){
            return RedirectToAction("Index");
       }
        
        return View();
    }
      public IActionResult Update()   {
        Student stud = new Student();
        return View(stud);
    }
    [HttpPost]
      public IActionResult Update(Student stud)
    {
        StudentManager em= new StudentManager();
        if(em.Update(stud)){
            return RedirectToAction("Index");
        }
        return View();
       
    }

}
