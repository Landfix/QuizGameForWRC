using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SO;

namespace Infrastructure
{
    public class LoaderWords
    {
        private ContentConfig _contentConfig;
        private List<string> uniqueWords;

        private char[] _splitSigns;
        public LoaderWords(ContentConfig config)
        {
            _contentConfig = config;
            _splitSigns = new[] {' ', ')', '(', '-', '_', '"', ',', '.', '?', '!', '`', ';', ':', '\n',(char)39};
        }

        public async Task<List<string>> LoadingWords()
        {
            IEnumerable<string> allWords = _contentConfig.Content.Split(_splitSigns);
            uniqueWords = allWords.GroupBy(w => w.ToUpper())
                .Where(g => g.Count() == 1 && g.Key.Length >= _contentConfig.WordLength)
                .Select(g => g.Key).ToList();
        
            return uniqueWords;
        }
    }
}
