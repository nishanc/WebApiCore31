using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore31.Models;

namespace WebApiCore31.Data
{
    public interface IValueRepository
    {
        Task<List<Value>> GetValueAsync();
        Task<Value> GetValueAsync(int id);
        Task<Value> AddValueAsync(Value value);
        Task<Value> UpdateValueAsync(int id, Value value);
        Task<Value> DeleteValueAsync(int id);
    }
}