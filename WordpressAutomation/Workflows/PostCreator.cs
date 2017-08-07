using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    public class PostCreator
    {
        public static void CreatePost()
        {
            PreviousTitle = CreatePostTitle();
            PreviousBody = CreatePostBody();

            NewPostPage.GoTo();
            NewPostPage.CreatePostWithTitle(PreviousTitle)
                .WithBody(PreviousBody)
                .Publish();

        }

        public static string PreviousTitle { get; set; }

        public static string PreviousBody { get; set; }

        private static string CreatePostTitle()
        {
            return CreateRandomString() + ", title";
        }

        private static string CreatePostBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateRandomString()
        {
            var str = new StringBuilder();
            var random = new Random();
            var cycles = random.Next(1, 6);
            for (int i = 0; i < cycles; i++)
            {
                str.Append(Words[random.Next(Words.Length)]);
                str.Append(" ");
                str.Append(Articles[random.Next(Articles.Length)]);
                str.Append(" ");
                str.Append(Words[random.Next(Words.Length)]);
                str.Append(" ");
            }
            return str.ToString();
        }

        private static string[] Words = {"boy", "cat", "tiger", "panda", "throw", "bite", "drop"};

        private static string[] Articles = {"a", "the", "an", "of", "to", "is"};

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void Cleanup()
        {
            if(PostExist)
                TrashPost();
        }

        public static void TrashPost()
        {
            ListPostsPage.TrashPost(PreviousTitle);
            Initialize();
        }

        public static bool PostExist
        {
            get { return !String.IsNullOrEmpty(PreviousTitle); }
        }
    }
}
