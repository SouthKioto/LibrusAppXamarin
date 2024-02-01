using LibrusAppXamarin.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibrusAppXamarin.Data
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection _database;

        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Grade>().Wait();
            _database.CreateTableAsync<Subject>().Wait();
        }

        public Task<List<User>> FilterUsers(string login, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Login = ? AND Password = ?", login, password);
        }
        public Task<int> InsertUser(User user)
        {
            return _database.InsertAsync(user);
        }
        public Task<List<User>> GetUsers()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }
        public Task<List<Subject>> GetSubjects()
        {
            return _database.QueryAsync<Subject>("SELECT * FROM Subject");
        }
        public Task<List<Grade>> GetGrades()
        {
            return _database.QueryAsync<Grade>("SELECT * FROM Grade");
        }
        public Task<int> InsertSubject(Subject subject)
        {
            return _database.InsertAsync(subject);
        }
        public Task<int> InsertGrade(Grade grade)
        {
            return _database.InsertAsync(grade);
        }
        public Task<List<Grade>> GetGrades(int userId, int subjectId, string period)
        {
            return _database.QueryAsync<Grade>("SELECT * FROM Grade WHERE UserId=? AND SubjectId=? AND Period=?", userId, subjectId, period);
        }
    }
}
