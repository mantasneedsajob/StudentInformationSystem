using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;
using System.Data;
using Dapper;
using System.Xml.Linq;

namespace StudentInformationSystem.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IDbConnection _connection;
    public StudentRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public DBStudent? CreateStudent(DBStudent s)
    {
        string sql = $"INSERT INTO \"Students\" (st_first_name, st_last_name, st_department_id) VALUES (@first, @last, @dept)";
        var queryArguments = new
        {
            first = s.FirstName,
            last = s.LastName,
            dept = s.DepartmentId
        };

        if (_connection.Execute(sql, queryArguments) > 0)
        {
            // TODO: assign numeric id to s from newly created DB entry
            return s;
        }
        return null;
    }

    public bool RemoveStudent(Student s)
    {
        string sql = $"DELETE FROM \"Students\" WHERE st_first_name = @firstName AND st_last_name = @lastName";
        var queryArguments = new
        {
            firstName = s.FirstName,
            lastName = s.LastName
        };

        int deleted = _connection.Execute(sql, queryArguments);
        return deleted == 1; // TODO: check for more affected rows
    }

    public DBStudent? FindStudent(Student s)
    {
        string sql = $"select st_id as Id, st_first_name as FirstName, st_last_name as LastName from \"Students\" where st_first_name = @firstName AND st_last_name = @lastName";
        var queryArguments = new
        {
            firstName = s.FirstName,
            lastName = s.LastName,
        };

        try
        {
            DBStudent st = _connection.QuerySingle<DBStudent>(sql, queryArguments);
            return st;
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }

    public DBStudent? FindStudent(int id)
    {
        string sql = $"select st_id as Id, st_first_name as FirstName, st_last_name as LastName from \"Students\" where st_id = @id";
        var queryArguments = new
        {
            id = id
        };

        try
        {
            DBStudent st = _connection.QuerySingle<DBStudent>(sql, queryArguments);
            return st;
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }
}
