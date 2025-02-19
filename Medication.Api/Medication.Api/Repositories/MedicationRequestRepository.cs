using Medication.Api.Data;
using Medication.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medication.Api.Repositories
{
    public class MedicationRequestRepository
    {
        private ApplicationDbContext context;

        public MedicationRequestRepository()
        {
            
        }

        public MedicationRequestRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<int> AddAsync(MedicationRequest request)
        {
            await context.AddAsync(request);
            return request.Id;
        }

        public virtual async Task SaveChangesAsync()
        {
            context.SaveChangesAsync();
        }
    }
}
