
using SurveyBasket.Api.Entities;

namespace SurveyBasket.Api.Services
{
    public class PollService(ApplicationDbContext context) : IPollService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            //no need to trackchanges as we wont change the list
           return await _context.polls.AsNoTracking().ToListAsync();
        }
        public async Task<Poll?> GetAsync(int id , CancellationToken cancellationToken = default)
        {
            return await _context.polls.FindAsync(id);
        }
        public async Task<Poll> AddAsync(Poll poll , CancellationToken cancellationToken = default)
        {
           await _context.polls.AddAsync(poll , cancellationToken);
           await _context.SaveChangesAsync(cancellationToken);
           return poll;
        }
        public async Task<bool> UpdateAsync(int id , Poll poll , CancellationToken cancellationToken = default)
        {
            var updatedPoll = await GetAsync(id , cancellationToken);
            if(updatedPoll is null) return false;
            updatedPoll.Title = poll.Title;
            updatedPoll.Summary = poll.Summary;
            updatedPoll.StartsAt = poll.StartsAt;
            updatedPoll.EndsAt = poll.EndsAt;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> DeleteAsync(int id , CancellationToken cancellationToken = default)
        {
            var DeletedPoll = await GetAsync(id , cancellationToken);
            if (DeletedPoll is null) return false;
             _context.Remove(DeletedPoll);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> TogglePublishStatusAsnyc(int id, CancellationToken cancellationToken = default)
        {
            var poll = await GetAsync(id, cancellationToken);
            if (poll is null) return false;
            poll.IsPublished = !poll.IsPublished;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
