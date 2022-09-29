namespace MayoralElection.Models
{
    public class Candidate
    {
        public string Name { get; set; }
        public int Votes { get; set; }

        public Candidate(string name = "", int votes = 0)
        {
            Name = name;
            Votes = votes;
        }

        public void AddVote(int votes = 1)
        {
            if (votes < 0) throw new Exception("You can't add negative votes");
            
            Votes += votes;
        }
        public int ReturnVotes()
        {
            return Votes;
        }
    }
}
