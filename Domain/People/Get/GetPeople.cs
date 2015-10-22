using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain.People.Get
{
    public class GetPeople : IAsyncRequest<IEnumerable<Person>>
    {
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(GetPeople)).AppendLine("{")
                .AppendLine("}");
            return builder.ToString();
        }
    }
}
