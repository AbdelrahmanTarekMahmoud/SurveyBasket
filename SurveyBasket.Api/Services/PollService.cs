namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
        new Poll{Id = 1 , Title = "Poll 1" , Description = "Des of first poll" } ]; //collection expression
        public IEnumerable<Poll> GetAll()
        {
            return _polls;
        }
        public Poll? Get(int id)
        {
            return _polls.SingleOrDefault(pol => pol.Id == id);
        }
        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
            _polls.Add(poll);
            return poll;
        }
        public bool Update(int id , Poll poll)
        {
            var updatedPoll = Get(id);
            if(updatedPoll is null) return false;
            updatedPoll.Title = poll.Title;
            updatedPoll.Description = poll.Description; 
            return true;
        }
        public bool Delete(int id)
        {
            var DeletedPoll = Get(id);
            if (DeletedPoll is null) return false;
            _polls.Remove(DeletedPoll);
            return true;
        }
    }
}
