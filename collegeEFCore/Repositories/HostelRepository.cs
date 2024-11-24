using collegeEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeEFCore.Repositories
{
    public class HostelRepository
    {
        private readonly ApplicationDbContext _context;

        public HostelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hostel> GetAllHostels()
        {
            return _context.Hostels.Include(h => h.Students).ToList();
        }

        public Hostel GetHostelById(int id)
        {
            return _context.Hostels
                .Include(h => h.Students)
                .FirstOrDefault(h => h.Id == id);
        }

        public void AddHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            _context.SaveChanges();
        }

        public void UpdateHostel(Hostel hostel)
        {
            _context.Hostels.Update(hostel);
            _context.SaveChanges();
        }

        public void DeleteHostel(int id)
        {
            var hostel = _context.Hostels.Find(id);
            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Hostel> GetHostelsByCity(string city)
        {
            return _context.Hostels
                .Where(h => h.City == city)
                .ToList();
        }

        public int CountHostelsWithAvailableSeats()
        {
            return _context.Hostels
                .Where(h => h.AvailableSeats > 0)
                .Count();
        }
    }

}
