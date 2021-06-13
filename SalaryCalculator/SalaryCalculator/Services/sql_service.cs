using System.Threading.Tasks;
using System.Collections.Generic;

using SalaryCalculator.Models;

using SQLite;

namespace SalaryCalculator.Services
{
    public class sql_service
    {
        private readonly SQLiteAsyncConnection dbconnection;
        private async Task CreateTables()
        {
            await dbconnection.CreateTableAsync<SalaryInfo>();
        }
        public async Task<bool> DeleteAllItems<T>()
        {
            //int rows shows how much columns were deleted
            int rows= await dbconnection.DeleteAllAsync<SalaryInfo>();
            return (rows != 0);
        }
        public async Task<List<T>> GetItems<T>() where T : new()
        {
            
            return await dbconnection.Table<T>().ToListAsync();
        }

        public async Task<bool> AddItem<T>(T item) where T : new()
        {
            //int rows shows how many rows effected in this case must be only 1
            int rows = await dbconnection.InsertAsync(item);
            return (rows == 1);
        }




        public async Task<bool> DeleteItem<T>(T item) where T : new()
        {
            int rows = await dbconnection.DeleteAsync(item);
            return (rows == 1);
        }


        public sql_service(string path)
        {
            dbconnection = new SQLiteAsyncConnection(path);
            Task.Run(() => CreateTables()).Wait();
        }
    }

}
