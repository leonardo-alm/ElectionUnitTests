using MayoralElection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayoralElectionTests
{
    public class BallotBoxTests
    {
        Candidate candidate1 = new Candidate("John", 10);
        Candidate candidate2 = new Candidate("Peter", 20);
        Candidate candidate3 = new Candidate("Paul", 30);
        Candidate candidate0 = new Candidate("Brett", 40);
        Candidate winner = new Candidate("Donald", 100);
        int winnerVotes = 100;

        [Fact]
        public void TestBallotBoxConstructor()
        {
            //Arrange
            var winner = new Candidate("", 10);
            var winnerVotes = 10;
            var candidates = new List<Candidate>() { new Candidate("", 0) };
            var electionState = false;

            //Act
            BallotBox ballotBox = new BallotBox(winner, winnerVotes, candidates, electionState);

            //Assert
            Assert.Equal(ballotBox.Winner, winner);
            Assert.Equal(ballotBox.WinnerVotes, winnerVotes);
            Assert.Equal(ballotBox.Candidates, candidates);
            Assert.Equal(ballotBox.ElectionState, electionState);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void TestElectionStartAndFinish(bool initialState, bool expectedFinalState)
        {
            //Arrange
            var candidates = new List<Candidate>() { new Candidate("", 0) };
            var electionState = initialState;

            BallotBox ballotBox = new BallotBox(winner, winnerVotes, candidates, electionState);

            //Act
            ballotBox.StartOrFinishElection();

            //Assert
            Assert.Equal(expectedFinalState, ballotBox.ElectionState);
        }

        [Fact]
        public void TestRegisterCandidate()
        {
            //Arrange           
            var candidates = new List<Candidate>() {candidate0, candidate3, candidate2};
            var electionState = false;

            BallotBox ballotBox = new BallotBox(winner, winnerVotes, candidates, electionState);

            //Act
            ballotBox.RegisterCandidate(candidate1);

            var expectedResult = candidate1;
            var actualResult = ballotBox.Candidates.Last();

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestNonRegisteredCandidateVote()
        {
            //Arrange
            var candidates = new List<Candidate>() { candidate0, candidate1, candidate2, candidate3, winner };
            var electionState = false;

            BallotBox ballotBox = new BallotBox(winner, winnerVotes, candidates, electionState);

            //Act
            var actualResult = ballotBox.Vote(new Candidate("Will", 1));
            
            //Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void TestRegisteredCandidateVote()
        {
            //Arrange
            var candidates = new List<Candidate>() { candidate0, candidate1, candidate2, candidate3, winner };
            var electionState = false;

            BallotBox ballotBox = new BallotBox(winner, winnerVotes, candidates, electionState);

            //Act
            var actualResult = ballotBox.Vote(candidate0);

            //Assert
            Assert.True(actualResult);
        }

        [Theory]
        [InlineData(100, true)]
        [InlineData(10, false)]
        [InlineData(50, true)]
        [InlineData(0, false)]
        public void TestElectionResults(int maxVotes, bool expectedResult)
        {
            //Arrange
            var winner = new Candidate("Donald", maxVotes);
            var winnerVotes = maxVotes;
            var candidates = new List<Candidate>() { candidate0, candidate1, candidate2, candidate3, winner };
            var electionState = false;

            BallotBox ballotBox = new BallotBox(winner, winnerVotes, candidates, electionState);

            //Act
            var actualResult = ballotBox.ValidateElectionResult();

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
