using FluentAssertions;
using MayoralElection.Models;

namespace MayoralElectionTests
{
    public class CandidateTests
    {
        [Theory]
        [InlineData(10, 10, 20)]
        [InlineData(0, 10, 10)]
        [InlineData(10, 0, 10)]
        [InlineData(0, 0, 0)]
        public void TestAmountOfVotes(int initialVotes, int addedVotes, int expectedResult)
        {
            // Arrange
            Candidate candidate = new Candidate(String.Empty, initialVotes);
            candidate.Votes = initialVotes;

            //Act
            candidate.AddVote(addedVotes);
            var actualResult = candidate.ReturnVotes();

            //Arrange
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestAddingNegativeVotes()
        {
            // Arrange
            Candidate candidate = new Candidate();

            //Act
            Action result = () => candidate.AddVote(-1);

            //Arrange
            result.Should().Throw<Exception>();
        }

        [Fact]
        public void ValidateCandidateName()
        {
            // Arrange
            var name = "Leonardo Oliveira de Almeida";
            Candidate candidate = new Candidate(name);
            //Act
            var result = candidate.Name;

            //Arrange
            result.Should().Be(name);
        }
    }
}

