using StudentInformationSystem.Models;

namespace StudentInformationSystem.Interfaces
{
    public interface IDatabaseService
    {
        // Create new objects
        public DBStudent? CreateNewStudentIfNonExistent(Student s);
        public DBClass? CreateNewClassIfNonExistent(Class c, Department d);
        public DBDepartment? CreateNewDepartmentIfNonExistent(Department d);

        // Remove objects
        public bool RemoveStudent(Student s); // returns true if deleted, false if not found

        // Get individual objects
        public DBDepartment? GetDepartment(int id);
        public DBClass? GetClass(int id);
        public DBStudent? GetStudent(int id);

        // Get lists of objects
        public IEnumerable<DBClass> GetAllClasses(Department d); // per department
        public IEnumerable<DBClass> GetAllClasses(Student s); // per student
        public IEnumerable<DBStudent> GetAllStudents(Department d); // per department
        public IEnumerable<DBDepartment> GetAllStudents(Class c); // per student
    }
}
