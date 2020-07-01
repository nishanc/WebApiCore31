using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCore31.Models;

namespace WebApiCore31.Data
{
    public class ValueRepository : IValueRepository
    {
        private readonly DataContext _context;
        public ValueRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Value> AddValueAsync(Value value)
        {
            await _context.Values.AddAsync(value);
            _context.SaveChanges();
            return value;
        }

        public async Task<Value> DeleteValueAsync(int id)
        {
            Value value = await _context.Values.FindAsync(id);
            _context.Values.Remove(value);
            _context.SaveChanges();
            return value;
        }

        public async Task<List<Value>> GetValueAsync()
        {
            var values  = await _context.Values.ToListAsync();
            return values;
        }

        public async Task<Value> GetValueAsync(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return value;
        }

        public async Task<Value> UpdateValueAsync(int id, Value value)
        {
            var valueToUpdate = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            valueToUpdate.Name = value.Name;
            valueToUpdate.City = value.City;
            _context.Entry(valueToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return value;
        }
    }
}