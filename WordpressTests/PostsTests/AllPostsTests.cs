using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordpressTest
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to posts, get posts count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            // Go back to Dashboard
            DashboardPage.GoTo();

            // Add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePostWithTitle("Added posts show up, title")
                .WithBody("Added posts show up, body")
                .Publish();

            // Go to posts, get new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount+1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            // Check for the added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Added posts show up, title"));

            // Trash post (clean up)
            ListPostsPage.TrashPost("Added posts show up, title");
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");

        }
    }
}
