using System.Text;
using MediatR;

namespace Domain.People.Create
{
    public class CreatePerson : IAsyncRequest<CreatePersonResponse>
    {
        public string First { get; set; }
        public string Last  { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(CreatePerson)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(First), First).AppendLine()
                .AppendFormat("    {0}: {1}", nameof(Last), Last).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
    }
}
