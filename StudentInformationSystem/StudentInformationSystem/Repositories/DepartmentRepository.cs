using Dapper;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;
using System.Data;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace StudentInformationSystem.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;
    public DepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public DBDepartment? CreateDepartment(Department d)
    {
        string sql = $"INSERT INTO \"Departments\" (dep_name) VALUES (@name) RETURNING dep_id as Id";
        var queryArguments = new
        {
            name = d.Name
        };

        try
        {
            int id = _connection.QuerySingle<int>(sql, queryArguments);
            return new DBDepartment { Name = d.Name, Id = id };
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }

    public bool RemoveDepartment(Department d)
    {
        string sql = $"DELETE FROM \"Departments\" WHERE dep_name = @name";
        var queryArguments = new
        {
            name = d.Name
        };

        int deleted = _connection.Execute(sql, queryArguments);
        return deleted == 1; // TODO: check for more affected rows
    }

    public DBDepartment? FindDepartment(string name)
    {
        string sql = $"select dep_id as Id, dep_name as Name from \"Departments\" where dep_name = @name";
        var queryArguments = new
        {
            name = name
        };

        try
        {
            DBDepartment d = _connection.QuerySingle<DBDepartment>(sql, queryArguments);
            return d;
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }

    public DBDepartment? FindDepartment(Department d)
    {
        return FindDepartment(d.Name);
    }

    public DBDepartment? FindDepartment(int id)
    {
        string sql = $"select dep_id as Id, dep_name as Name from \"Departments\" where dep_id = @id";
        var queryArguments = new
        {
            id = id
        };

        try
        {
            DBDepartment d = _connection.QuerySingle<DBDepartment>(sql, queryArguments);
            return d;
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }
}
