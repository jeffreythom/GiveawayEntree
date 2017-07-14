using GiveawayEntree.Enum;

namespace GiveawayEntree.Model
{
    public class Owner : _BaseModel
    {
        public TypeEnum Type { get; set; }
        public bool IsFollowed { get; set; }
    }
}
