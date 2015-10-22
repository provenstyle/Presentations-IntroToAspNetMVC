using System.Text;
using MediatR;

namespace Domain.People.Get
{
    public class GetPerson : IAsyncRequest<Person>
    {
        public int Id { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(GetPerson)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(Id), Id).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
    }
}
