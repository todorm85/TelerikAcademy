namespace SocialNetwork.ConsoleClient.XmlImporter.XmlModels
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Posts
    {

        private PostsPost[] postField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Post")]
        public PostsPost[] Post
        {
            get
            {
                return this.postField;
            }
            set
            {
                this.postField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PostsPost
    {

        private string contentField;

        private System.DateTime postedOnField;

        private string usersField;

        /// <remarks/>
        public string Content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }

        /// <remarks/>
        public System.DateTime PostedOn
        {
            get
            {
                return this.postedOnField;
            }
            set
            {
                this.postedOnField = value;
            }
        }

        /// <remarks/>
        public string Users
        {
            get
            {
                return this.usersField;
            }
            set
            {
                this.usersField = value;
            }
        }
    }

}