using System.Text;

namespace BuilderDesignPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.AppendLine("<p>");
            sb.AppendLine(hello);
            sb.AppendLine("</p>");


            var words = new [] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach(var word in words)
            {
                sb.AppendFormat("<li>{0}</li>",word);
            }
            sb.Append("</ul>");

            Console.WriteLine(sb);
        }
    }
}