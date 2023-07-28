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

            Console.WriteLine(sb);
        }
    }
}