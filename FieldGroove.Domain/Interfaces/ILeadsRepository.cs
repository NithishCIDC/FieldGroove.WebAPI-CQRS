using FieldGroove.Domain.Models;

namespace FieldGroove.Domain.Interfaces
{
    public interface ILeadsRepository
    {
        Task<List<LeadsModel>> GetAll();
        Task<LeadsModel> GetById(int id);
        Task<bool> Create(LeadsModel leads);
        Task<bool> Update(LeadsModel leads);
        Task<bool> Delete(LeadsModel leads);
        Task<bool> IsAny(int id);
    }
}
