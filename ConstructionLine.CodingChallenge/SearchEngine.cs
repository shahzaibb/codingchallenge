using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly Dictionary<string, List<Shirt>> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {

            _shirts = new Dictionary<string, List<Shirt>>();

            shirts.ForEach(shirt =>
            {
                var key = shirt.Size.Name + shirt.Color.Name;
                if (_shirts.ContainsKey(key))
                {
                    _shirts.First(x => x.Key == key).Value.Add(shirt);
                }
                else
                {
                    _shirts.Add(key, new List<Shirt> { shirt });

                }
            });           
        }


        public SearchResults Search(SearchOptions options)
        {
            var result = new SearchResults();            

            foreach (var size in Size.All)
            {
                if (!options.Sizes.Any() || options.Sizes.Contains(size))
                {
                    foreach (var color in Color.All)
                    {
                        if (!options.Colors.Any() || options.Colors.Contains(color))
                        {
                            int count = 0;
                            var key = size.Name + color.Name;

                            var list_shirt = _shirts.SingleOrDefault(x => x.Key == key).Value;
                            if (list_shirt != null)
                            {
                                count = list_shirt.Count();
                                result.Shirts.AddRange(list_shirt);
                            }

                            var tempSizeCount = result.SizeCounts.SingleOrDefault(x => x.Size.Name == size.Name);
                            if (tempSizeCount != null)
                            {
                                tempSizeCount.Count += count;
                            }

                            var tempColorCount = result.ColorCounts.SingleOrDefault(x => x.Color.Name == color.Name);
                            if (tempColorCount != null)
                            {
                                tempColorCount.Count += count;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}