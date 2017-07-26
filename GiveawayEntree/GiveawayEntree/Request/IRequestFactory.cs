using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using GiveawayEntree.Model;
using GiveawayEntree.Model.Twitter;

namespace GiveawayEntree.Request
{
    public interface IRequestFactory<T>
    {
        Task<IEnumerable<Tweet>> GetPosts();
        bool LikePost(string postId);
        bool ReplyToPost(string postId, string content);
        bool SharePost(string postId);
    }
}
