using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;
        //private string author;

        public Comment(string content)
        {
            this.Content = content;
        }
        public string Content
        {
            get { return this.content; }
            private set
            {
                if (value == null || value.Length < 3 || value.Length > 200)
                {
                    throw new ArgumentException("Content must be between 3 and 200 characters long!");
                }
                this.content = value;
            }
        }
        public string Author { get; set; }

        public override string ToString()
        {
            return "    ----------" + Environment.NewLine + $"    {this.Content}" + Environment.NewLine +
                   $"      User: {this.Author}" + Environment.NewLine + "    ----------";
        }
    }
}
