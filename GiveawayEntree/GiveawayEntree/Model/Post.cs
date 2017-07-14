using System;
using GiveawayEntree.Enum;

namespace GiveawayEntree.Model
{
    public abstract class Post : _BaseModel
    {
        public string Content { get; set; }
        public TypeEnum Type { get; set; }
        public DateTime Created { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
