using System.Linq;
using System.Threading.Tasks;
using PsawSharp.Entries;
using PsawSharp.Requests.Options;
using Xunit;

namespace PsawSharp.Tests
{
    public class PsawClientTests
    {

        [Fact]
        public async Task GetMeta()
        {
            var client = new PsawClient();
            var meta = await client.GetMeta();
            Assert.True(meta.ClientAcceptsJson);
        }

        [Fact]
        public async Task GetSubmission()
        {
            var client = new PsawClient();
            var submmissions = await client.Search<Submission>(new SearchOptions
            {
                Subreddit = "game",
                Size = 1
            });

            Assert.Single(submmissions);
        }

        [Fact]
        public async Task GetSubmissions()
        {
            var client = new PsawClient();
            var submmissions = await client.Search<Submission>(new SearchOptions
            {
                Subreddit = "game",
                Size = 1000
            });

            Assert.Equal(1000, submmissions.Length);
            Assert.DoesNotContain(submmissions.GroupBy(s => s.Id), g => g.Count() > 1);
        }

        [Fact]
        public async Task GetSubmissionCommentIds()
        {
            var client = new PsawClient();
            string[] ids = await client.GetSubmissionCommentIds("a2df38");

            Assert.True(ids.Length > 2000);
        }

        [Fact]
        public async Task GetComments()
        {
            var client = new PsawClient();
            var comments = await client.Search<Comment>(new SearchOptions
            {
                Subreddit = "game",
                Size = 500
            });

            Assert.Equal(500, comments.Length);
            Assert.True(comments.All(c => c.Subreddit == "game"));
        }

        [Fact]
        public async Task GetSubmissionComments()
        {
            const string submissionId = "a2df38";

            var client = new PsawClient();
            var commentIds = (await client.GetSubmissionCommentIds(submissionId)).Take(500).ToArray();

            // Only taking 500 because more would result in a [Request Line is too large (8039 > 4094)] error
            var comments = await client.Search<Comment>(new SearchOptions
            {
                Ids = commentIds
            });

            Assert.Equal(500, comments.Length);
        }

    }
}
