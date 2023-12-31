﻿using System.Runtime.InteropServices;
using System.Text;

namespace BuilderDesignPatternDemo
{

    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentsize = 2;

        public HtmlElement() { }
        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indent* indentsize);
            sb.AppendLine($"{i} <{Name}>");

            if(!string.IsNullOrEmpty(Text))
            {
                sb.Append(new string(' ', indent * indentsize+1));
                sb.AppendLine($"{Text}");
            }

            foreach(var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent+1));
            }

            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {

        public string rootname;

        HtmlElement root = new HtmlElement();


        public HtmlBuilder(string rootname)
        {
            this.rootname = rootname;
            root.Name = rootname;
        }

        public HtmlBuilder AddChild(string childname, string childtext)
        {
            var e = new HtmlElement(childname,childtext);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString(); 
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootname };
        }
    }
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

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");


            Console.WriteLine(builder.ToString());
        }
    }
}