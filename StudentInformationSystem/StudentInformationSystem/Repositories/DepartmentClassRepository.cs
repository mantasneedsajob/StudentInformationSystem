using StudentInformationSystem.Interfaces;
using System.Data;
using StudentInformationSystem.Models;
using Dapper;
using System.Runtime.Intrinsics.Arm;

namespace StudentInformationSystem.Repositories
{
    public class DepartmentClassRepository : IDepartmentClassRepository
    {
        private readonly IDbConnection _connection;
        public DepartmentClassRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public (int, int)? CreatePair(DBDepartment d, DBClass c)
        {
            string sql = $"INSERT INTO \"Departments_Classes\" (dc_department_id, dc_class_id) VALUES (@depId, @clId) RETURNING dc_department_id as dep, dc_class_id as cl";
            var queryArguments = new
            {
                depId = d.Id,
                clId = c.Id
            };

            try
            {
                (int, int)? pair = _connection.QuerySingle<(int, int)>(sql, queryArguments);
                return pair;
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log bad query
                return null;
            }
        }

        public (int, int)? FindPair(DBDepartment d, DBClass c)
        {
            string sql = $"select dc_department_id, dc_class_id from \"Departments_Classes\" WHERE dc_department_id = @id1 AND dc_class_id = @id2";
            var queryArguments = new
            {
                id1 = d.Id,
                id2 = c.Id
            };

            try
            {
                (int, int)? pair = _connection.QuerySingle<(int, int)>(sql, queryArguments);
                return pair;
            }
            catch (InvalidOperationException ex)
            {
                // TODO: log bad query
                return null;
            }
        }

        public bool RemovePair(DBDepartment d, DBClass c)
        {
            string sql = $"DELETE FROM \"Departments_Classes\" WHERE dc_department_id = @id1 AND dc_class_id = @id2";
            var queryArguments = new
            {
                id1 = d.Id,
                id2 = c.Id
            };

            int deleted = _connection.Execute(sql, queryArguments);
            return deleted == 1; // TODO: check for more affected rows
        }
    }
}
