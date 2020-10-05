using System;
using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities.Cms
{
    public class Post : BaseExtendedEntity
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
        }
        public int PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool HasAttachment { get; set; }
        public string Body { get; set; }
        public bool IsDraft { get; set; }
        public bool IsCommentingEnabled { get; set; }
        public DateTime? StartPublishingDateTime { get; set; }
        public DateTime? FinishPublishingDateTime { get; set; }
        public int CreatorUserId { get; set; }

        /// <summery>
        /// Url Backing Field
        /// </summery>
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

        /// <summary>
        /// Reference Backing Field
        /// </summary>
        private List<PostComment> _postComments = new List<PostComment>();
        public IEnumerable<PostComment> PostComments { get; set; }
        public void AddComment(PostComment comment)
        {
            // Logic
            _postComments.Add(comment);
        }
        
        public ICollection<TagsOfPosts> PostTags { get; set; }
    }
}

