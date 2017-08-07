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
            PostCreator.CreatePost();

            // Go to posts, get new posts count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount+1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            // Check for the added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            // Trash post (clean up)
            PostCreator.TrashPost();
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");

        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            // Create a new post
            PostCreator.CreatePost();

            // Search for post
            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            // Check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            // Cleanup (Trash post)
            // Automatically clean up by WordpressTests class
        }
    }
}
