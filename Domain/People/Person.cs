using System.Text;

namespace Domain.People
{
    public class Person
    {
        public int    Id    { get; set; }
        public string First { get; set; }
        public string Last  { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine().Append(nameof(Person)).AppendLine("{")
                .AppendFormat("    {0}: {1}", nameof(First), First).AppendLine()
                .AppendFormat("    {0}: {1}", nameof(Last), Last).AppendLine()
                .AppendLine("}");
            return builder.ToString();
        }
    }
}