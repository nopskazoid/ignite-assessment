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

        public virtual async Task AddAsync(MedicationRequest request)
        {
            await context.AddAsync(request);
        }

        public virtual async Task UpdateAsync(int requestId, DateTime? dateEnded, float? frequency, MedicationRequest.RequestStatus? status)
        {
            var dbRequest = await context.MedicationRequests.SingleOrDefaultAsync(x => x.Id == requestId);

            if (dbRequest is null)
            {
                throw new ArgumentException("requestId");
            }

            if (dateEnded is not null) dbRequest.DateEnded = dateEnded.Value;
            if (frequency is not null) dbRequest.Frequency = frequency.Value;
            if (status is not null) dbRequest.Status = status.Value;

            context.Update(dbRequest);
        }

        public virtual async Task<IEnumerable<MedicationRequest>> GetAsync(MedicationRequest.RequestStatus? status, DateTime? startDate, DateTime? endDate)
        {
            var query = context.MedicationRequests
                .Include(x=> x.Clinician)
                .Include(x => x.Patient)
                .Include(x => x.Medication)
                .AsQueryable();

            if (status is not null)
            {
                query = query.Where(x => x.Status == status);
            }

            if (startDate is not null && endDate is not null && startDate < endDate)
            {
                query = query.Where(x => x.DatePrescribed >= startDate && x.DatePrescribed <= endDate);
            }

            return await query.ToListAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            context.SaveChangesAsync();
        }
    }
}
