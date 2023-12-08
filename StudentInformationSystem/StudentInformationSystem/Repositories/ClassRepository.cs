using Dapper;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Models;
using System.Data;
using System.Xml.Linq;

namespace StudentInformationSystem.Repositories;

public class ClassRepository : IClassRepository
{
    private readonly IDbConnection _connection;
    public ClassRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public DBClass? CreateClass(Class c)
    {
        string sql = $"INSERT INTO \"Classes\" (cl_name) VALUES (@name)";
        var queryArguments = new
        {
            name = c.Name
        };

        if (_connection.Execute(sql, queryArguments) > 0)
        {
            // TODO: assign numeric id to s from newly created DB entry
            return new DBClass { Name = c.Name };
        }
        return null;
    }

    public bool RemoveClass(Class c)
    {
        string sql = $"DELETE FROM \"Classes\" WHERE cl_name = @name";
        var queryArguments = new
        {
            name = c.Name
        };

        int deleted = _connection.Execute(sql, queryArguments);
        return deleted == 1; // TODO: check for more affected rows
    }

    public DBClass? FindClass(string name)
    {
        string sql = $"select cl_id as Id, cl_name as Name from \"Classes\" where cl_name = @name";
        var queryArguments = new
        {
            name = name
        };

        try
        {
            DBClass c = _connection.QuerySingle<DBClass>(sql, queryArguments);
            return c;
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }

    public DBClass? FindClass(Class c)
    {
        return FindClass(c.Name);
    }

    public DBClass? FindClass(int id)
    {
        string sql = $"select cl_id as Id, cl_name as Name from \"Classes\" where cl_id = @id";
        var queryArguments = new
        {
            id = id
        };

        try
        {
            DBClass c = _connection.QuerySingle<DBClass>(sql, queryArguments);
            return c;
        }
        catch (InvalidOperationException ex)
        {
            // TODO: log bad query
            return null;
        }
    }
}
