using MyStaffWpf2.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace MyStaffWpf2.Model
{
    public static class DataWorker
    {

        // найти
        public static Department findDepartmentById(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.departments.FirstOrDefault(d => d.Id == id);
            }
        }

        public static Position findPositionById(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.positions.FirstOrDefault(p => p.Id == id);
            }
        }

        public static Staff findStaffById(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.staffs.FirstOrDefault(s => s.Id == id);
            }
        }

        public static List<Department> findAllDepartments()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.departments.ToList();
            }
        }

        public static List<Position> findAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.positions.ToList();
            }
        }

        public static List<Staff> findAllStaffs()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.staffs.ToList();
            }
        }

        public static List<Staff> filter(string lastName, string firstName, string middleName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = from s in db.staffs
                           where (s.LastName.ToLower().Contains(lastName.ToLower()))
                           where (s.FirstName.ToLower().Contains(firstName.ToLower()))
                           where (s.MiddleName.ToLower().Contains(middleName.ToLower()))
                           select s;
                return result.ToList();
            }
        }

        // добавление
        public static string CreateDepartment(string name)
        {
            string result = "Отдел уже существует!";
            using(ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.departments.Any(el => el.Name == name);
                if(!checkIsExist)
                {
                    Department department = new Department { Name = name};
                    db.Add(department);
                    db.SaveChanges();
                    result = "Отдел добавлен!";
                }
                return result;
            }
        }

        public static string CreatePosition(string name, Department department)
        {
            string result = "Должность уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.positions.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Position position = new Position { Name = name, DepartmentId = department.Id };
                    db.Add(position);
                    db.SaveChanges();
                    result = "Должность добавлена!";
                }
                return result;
            }
        }

        public static string CreateStaff(string lastName, string firstName, string middleName, Position position, string dateOfBrith, string phone, string email)
        {
            string result = "Сотрудник уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.staffs.Any(el => 
                el.LastName == lastName && 
                el.FirstName == firstName && 
                el.MiddleName == middleName && 
                el.Position == position
                );
                if (!checkIsExist)
                {
                    Staff staff = new Staff { 
                        LastName = lastName,
                        FirstName = firstName,
                        MiddleName = middleName,
                        PositionId = position.Id,
                        DateOfBrith = dateOfBrith,
                        Phone = phone,
                        Email = email
                    };
                    db.Add(staff);
                    db.SaveChanges();
                    result = "Сотрудник добавлен!";
                }
                return result;
            }
        }

        // удаление
        public static string DeleteDepartment(Department department)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Remove(department);
                db.SaveChanges();
                return "Отдел " + department.Name + " удален!";
            }
        }

        public static string DeletePosition(Position position)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Remove(position);
                db.SaveChanges();
                return "Должность " + position.Name + " удалена!";
            }
        }

        public static string DeleteStuff(Staff staff)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Remove(staff);
                db.SaveChanges();
                return "Сотрудник " + staff.LastName + " " + staff.FirstName + " " + staff.MiddleName + " удален!";
            }
        }

        // редактирование

        public static string EditDepartment(Department oldDepartment, string newName)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Department department = db.departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                db.SaveChanges();
                return "Отдел изменен!";
            }
        }

        public static string EditPosition(Position oldPosition, string newName, Department newDepartament)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                position.Name = newName;
                position.DepartmentId = newDepartament.Id;
                db.SaveChanges();
                return "Должность " + position.Name + " изменена!";
            }
        }

        public static string EditStaff(Staff oldStaff, string newLastName, string newFirstName, string newMiddleName, Position newPosition, string newDateOfBrith, string newPhone, string newEmail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Staff staff = db.staffs.FirstOrDefault(s => s.Id == oldStaff.Id);
                staff.LastName = newLastName;
                staff.FirstName = newFirstName;
                staff.MiddleName = newMiddleName;
                staff.PositionId = newPosition.Id;
                staff.DateOfBrith = newDateOfBrith;
                staff.Phone = newPhone;
                staff.Email = newEmail;
                db.SaveChanges();
                return "Сотрудник " + staff.LastName + " " + staff.FirstName + " " + staff.MiddleName + " изменен!";
            }
        }
    }
}
