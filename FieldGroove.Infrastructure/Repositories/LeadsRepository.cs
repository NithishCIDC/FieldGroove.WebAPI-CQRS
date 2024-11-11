using FieldGroove.Infrastructure.Data;
using FieldGroove.Domain.Models;
using Microsoft.EntityFrameworkCore;
using FieldGroove.Domain.Interfaces;
using FieldGroove.Application.GenerateLeadPDF;
using FieldGroove.Application.EmailService;

namespace FieldGroove.Infrastructure.Repositories
{
    public class LeadsRepository(ApplicationDbContext dbContext) : ILeadsRepository
    {
        public async Task<bool> Create(LeadsModel leads)
        {
            try
            {
                GenerateLeadPDF.LeadPDF(leads);
                await dbContext.Leads.AddAsync(leads);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(LeadsModel lead)
        {
            try
            {
                dbContext.Leads.Remove(lead);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
            
        }

        public async Task<List<LeadsModel>> GetAll()
        {
            return await dbContext.Leads.ToListAsync();
        }

        public async Task<LeadsModel> GetById(int id)
        {
            var response = await dbContext.Leads.FindAsync(id);
            return response!;
        }

        public async Task<bool> IsAny(int id)
        {
            return await dbContext.Leads.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Update(LeadsModel leads)
        {
            try
            {
                dbContext.Leads.Update(leads);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
