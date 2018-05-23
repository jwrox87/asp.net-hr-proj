using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class Employee
    {
        //ID values
        public int id;
        public int job_id;
        public int department_id;

        //Other details
        private string name, ic, phone, job_pos, job_salary, department_name;

        public Employee() { }

        public Employee(Employee e)
        {
            name = e.name;
            phone = e.phone;
            ic = e.ic;
            job_pos = e.job_pos;
            job_salary = e.job_salary;
            department_name = e.department_name;
        }

        public Employee(string n, string p, string _ic,
            string jp, string js, string dn)
        {
            name = n;
            phone = p;
            ic = _ic;
            job_pos = jp;
            job_salary = js;
            department_name = dn;
        }

        public string Name{ get { return name; } }
        public string Phone { get { return phone; } }
        public string IC { get { return ic; } }
        public string JobPos { get { return job_pos; } }
        public string JobSalary { get { return job_salary; } }
        public string DepartmentName { get { return department_name; } }
    }
}