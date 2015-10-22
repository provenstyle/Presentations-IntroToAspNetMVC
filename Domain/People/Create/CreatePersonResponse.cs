using System.Text;

namespace Domain.People.Create
{
    public class CreatePersonResponse
    {
        public int Id { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(CreatePersonResponse)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(Id), Id).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
    }
}