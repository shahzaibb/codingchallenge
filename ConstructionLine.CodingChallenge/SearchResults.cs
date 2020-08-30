using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResults
    {
        public List<Shirt> Shirts { get; set; }


        public List<SizeCount> SizeCounts { get; set; }


        public List<ColorCount> ColorCounts { get; set; }

        public SearchResults()
        {
            Shirts = new List<Shirt>();
            SizeCounts = Size.All.Select(x => new SizeCount { Size = x, Count = 0 }).ToList();
            ColorCounts = Color.All.Select(x => new ColorCount { Color = x, Count = 0 }).ToList();
        }
    }


    public class SizeCount
    {
        public Size Size { get; set; }

        public int Count { get; set; }
    }


    public class ColorCount
    {
        public Color Color { get; set; }

        public int Count { get; set; }
    }
}