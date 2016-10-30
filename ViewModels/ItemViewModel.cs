namespace AspCoreAngular2_MoviesLibrary.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptOut)]
    public class ItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemViewModel"/> class.
        /// </summary>
        public ItemViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DefaultValue(0)]
        public int Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The flags.
        /// </value>
        [DefaultValue(0)]
        public int Flags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the view count.
        /// </summary>
        /// <value>
        /// The view count.
        /// </value>
        [JsonIgnore]
        public int ViewCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last modified date.
        /// </summary>
        /// <value>
        /// The last modified date.
        /// </value>
        public DateTime LastModifiedDate
        {
            get;
            set;
        }
    }
}
