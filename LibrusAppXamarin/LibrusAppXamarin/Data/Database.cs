using LibrusAppXamarin.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibrusAppXamarin.Data
{
    public class Database
    {
        public readonly SQLiteAsyncConnection _connection;
        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPersonAsync(Person person)
        {
            return _connection.Table<Person>().ToListAsync();
        }
    }
}
