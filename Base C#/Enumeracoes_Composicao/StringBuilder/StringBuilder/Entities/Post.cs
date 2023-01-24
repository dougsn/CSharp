using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Builder.Entities {
    internal class Post {

        public DateTime Moment{ get; set; }
        public string Title { get; set; }
        public string Content{ get; set; }
        public int Like { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Post() { }

        public Post(DateTime moment, string title, string content, int like) {
            Moment = moment;
            Title = title;
            Content = content;
            Like = like;
        }

        public void addComment(Comment comment) {
            Comments.Add(comment);
        }

        public void removeComment(Comment comment) {
            Comments.Remove(comment);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Title);
            sb.Append(Like);
            sb.Append(" Likes - ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(Content);
            sb.AppendLine("Comments:");
            foreach (Comment c in Comments) { // Percorrendo todos os comentários para exibir no console.
                sb.AppendLine(c.Text);
            }
            return sb.ToString();
        }

    }
}
