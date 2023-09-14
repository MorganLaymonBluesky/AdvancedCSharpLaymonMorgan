using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2MorganLaymon
{
    public class VideoGame : IComparable<VideoGame>
    {
        public string name { get; set; }
        public string platform { get; set; }
        public int year { get; set; }
        public string genre { get; set; }
        public string publisher { get; set; }
        public double naSales { get; set; }
        public double euSales { get; set; }
        public double jpSales { get; set; }
        public double otherSales { get; set; }
        public double globalSales { get; set; }

        public VideoGame()
        {
            this.name = "NamePlaceholder";
            this.platform = "PlatformPlaceholder";
            this.year = 0;
            this.genre = "GenrePlaceholder";
            this.publisher = "PublisherPlaceholder";
            this.naSales = 0.0;
            this.euSales = 0.0;
            this.jpSales = 0.0;
            this.otherSales = 0.0;
            this.globalSales = 0.0;
        }

        public VideoGame(string name, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            this.name = name;
            this.platform = platform;
            this.year = year;
            this.genre = genre;
            this.publisher = publisher;
            this.naSales = naSales;
            this.euSales = euSales;
            this.jpSales = jpSales;
            this.otherSales = otherSales;
            this.globalSales = globalSales;
        }

        public VideoGame(VideoGame vg)
        {
            this.name = vg.name;
            this.platform = vg.platform;
            this.year = vg.year;
            this.genre = vg.genre;
            this.publisher = vg.publisher;
            this.naSales = vg.naSales;
            this.euSales = vg.euSales;
            this.jpSales = vg.jpSales;
            this.otherSales = vg.otherSales;
            this.globalSales = vg.globalSales;
        }

        public override string ToString()
        {
            string listing = "";
            listing += "Title: " + this.name + "\n";
            listing += "Publisher: " + this.publisher + "\n";
            listing += "Genre: " + this.genre + "\n";
            listing += "Platform: " + this.platform + "\n";
            listing += "Release Year: " + this.year + "\n";
            return listing;
        }

        public int CompareTo(VideoGame vg)
        {
            if (vg == null)
            {
                return 1;
            }
            return Comparer<string>.Default.Compare(this.name, vg.name);
        }
    }
}