using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayoralElection.Models
{
    public class BallotBox
    {
        public Candidate Winner { get; set; }
        public int WinnerVotes { get; set; }
        public List<Candidate> Candidates { get; set; }
        public bool ElectionState { get; set; }

        public BallotBox(Candidate winner, int winnerVotes, List<Candidate> candidates, bool electionState)
        {
            Winner = winner;
            WinnerVotes = winnerVotes;
            Candidates = candidates;
            ElectionState = electionState;
        }

        public Candidate ElectionResult()
        {
            return Winner;
        }

        public void RegisterCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public void StartOrFinishElection()
        {
            if (ElectionState) ElectionState = false;
            else ElectionState = true;
        }

        public bool Vote(Candidate candidate)
        {
            foreach(Candidate c in Candidates)
            {
                if(c.Name == candidate.Name)
                {
                    c.AddVote();
                    return true;
                }
            }         
            return false;
        }

        public bool ValidateElectionResult()
        {
            var maxVotes = 0;
            foreach(Candidate candidate in Candidates)
            {
                if(candidate.Votes >= maxVotes)
                {
                    maxVotes = candidate.Votes;
                }
            }
            if (WinnerVotes == maxVotes) return true;

            else return false;
        }
    }
}

