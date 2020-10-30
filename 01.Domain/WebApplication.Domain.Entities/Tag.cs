using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Cms;

namespace WebApplication.Domain.Entities
{
    public class Tag : BaseExtendedEntity
    {
        public string Name { get; set; }

        // backing field
        private string _url;
        public string Url
        {
            // besunes logic
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        public ICollection<TagsOfPosts> PostTags { get; set; }
    }
}
