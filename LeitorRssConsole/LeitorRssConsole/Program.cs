using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
/*
 Fonte: https://ivaldojunior.wordpress.com/2012/05/31/c-exemplo-de-um-leitor-de-feed-rss-rss-feed-reader/
     */
namespace LeitorRssConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRss("http://www.sefaz.se.gov.br/_layouts/15/listfeed.aspx?List=%7B47165FFB%2D27C2%2D4C86%2DB8E5%2DDE40B54B162E%7D&Source=http%3A%2F%2Fwww%2Esefaz%2Ese%2Egov%2Ebr%2FLists%2FNoticias%2FAllItems%2Easpx");
            Console.Read();
        }

        public static void GetRss(string url)
        {
            // Esse Objeto é muito útil para o processamento do xml
            XDocument xdoc = XDocument.Load(url);

            // esse método carregrá através do xDocument todos os nós item
            var itens = xdoc.Document.Descendants("item");

            foreach (var i in itens)
            {
                var titulo = i.Element("title").Value;
                var link = i.Element("link").Value;
                var author = i.Element("author").Value;
                var pubDate = i.Element("pubDate").Value;
                var description = i.Element("description").Value;
                var guid = i.Element("guid").Value;

                //Console.WriteLine("Titulo: {0}, link: {1}, Descrição: {2}, data: {3} ", titulo, link, description, pubDate  );
                Console.WriteLine(titulo);
            }

        }
    }
}
