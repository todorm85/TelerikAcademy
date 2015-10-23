namespace SocialNetwork.ConsoleClient.XmlImporter.XmlModels
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Friendships
    {

        private FriendshipsFriendship[] friendshipField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Friendship")]
        public FriendshipsFriendship[] Friendship
        {
            get
            {
                return this.friendshipField;
            }
            set
            {
                this.friendshipField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FriendshipsFriendship
    {

        private string friendsSinceField;

        private FriendshipsFriendshipFirstUser firstUserField;

        private FriendshipsFriendshipSecondUser secondUserField;

        private FriendshipsFriendshipMessage[] messagesField;

        private bool approvedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string FriendsSince
        {
            get
            {
                return this.friendsSinceField;
            }
            set
            {
                this.friendsSinceField = value;
            }
        }

        /// <remarks/>
        public FriendshipsFriendshipFirstUser FirstUser
        {
            get
            {
                return this.firstUserField;
            }
            set
            {
                this.firstUserField = value;
            }
        }

        /// <remarks/>
        public FriendshipsFriendshipSecondUser SecondUser
        {
            get
            {
                return this.secondUserField;
            }
            set
            {
                this.secondUserField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Message", IsNullable = false)]
        public FriendshipsFriendshipMessage[] Messages
        {
            get
            {
                return this.messagesField;
            }
            set
            {
                this.messagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Approved
        {
            get
            {
                return this.approvedField;
            }
            set
            {
                this.approvedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FriendshipsFriendshipFirstUser
    {

        private string usernameField;

        private string firstNameField;

        private string lastNameField;

        private System.DateTime registeredOnField;

        private FriendshipsFriendshipFirstUserImage[] imagesField;

        /// <remarks/>
        public string Username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public System.DateTime RegisteredOn
        {
            get
            {
                return this.registeredOnField;
            }
            set
            {
                this.registeredOnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Image", IsNullable = false)]
        public FriendshipsFriendshipFirstUserImage[] Images
        {
            get
            {
                return this.imagesField;
            }
            set
            {
                this.imagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FriendshipsFriendshipFirstUserImage
    {

        private string imageUrlField;

        private string fileExtensionField;

        /// <remarks/>
        public string ImageUrl
        {
            get
            {
                return this.imageUrlField;
            }
            set
            {
                this.imageUrlField = value;
            }
        }

        /// <remarks/>
        public string FileExtension
        {
            get
            {
                return this.fileExtensionField;
            }
            set
            {
                this.fileExtensionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FriendshipsFriendshipSecondUser
    {

        private string usernameField;

        private string firstNameField;

        private string lastNameField;

        private System.DateTime registeredOnField;

        private FriendshipsFriendshipSecondUserImage[] imagesField;

        /// <remarks/>
        public string Username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public System.DateTime RegisteredOn
        {
            get
            {
                return this.registeredOnField;
            }
            set
            {
                this.registeredOnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Image", IsNullable = false)]
        public FriendshipsFriendshipSecondUserImage[] Images
        {
            get
            {
                return this.imagesField;
            }
            set
            {
                this.imagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FriendshipsFriendshipSecondUserImage
    {

        private string imageUrlField;

        private string fileExtensionField;

        /// <remarks/>
        public string ImageUrl
        {
            get
            {
                return this.imageUrlField;
            }
            set
            {
                this.imageUrlField = value;
            }
        }

        /// <remarks/>
        public string FileExtension
        {
            get
            {
                return this.fileExtensionField;
            }
            set
            {
                this.fileExtensionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FriendshipsFriendshipMessage
    {

        private string authorField;

        private string contentField;

        private System.DateTime sentOnField;

        private string seenOnField;

        /// <remarks/>
        public string Author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

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
        public System.DateTime SentOn
        {
            get
            {
                return this.sentOnField;
            }
            set
            {
                this.sentOnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SeenOn
        {
            get
            {
                return this.seenOnField;
            }
            set
            {
                this.seenOnField = value;
            }
        }
    }

}