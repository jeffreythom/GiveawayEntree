using System;
using System.Collections.Generic;
using System.Windows.Documents;
using GiveawayEntree.Model;

namespace GiveawayEntree.Request
{
    public interface IRequestFactory<T>
    {
        IEnumerable<T> GetPosts();
        bool LikePost(string postId);
        bool ReplyToPost(string postId, string content);
        bool SharePost(string postId);
    }
}
