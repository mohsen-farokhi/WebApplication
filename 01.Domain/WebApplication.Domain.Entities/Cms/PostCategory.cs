using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities.Cms
{
    public class PostCategory : BaseExtendedEntity
    {
        public PostCategory()
        {
        }
        public string Title { get; set; }

        /// <summary>
        /// ImageUrl Backing Field
        /// </summary>
        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
