using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFilterBubble.Sdk.Repository
{
  public static class FileFormatRepository
  {
    private static AbstractFileFormat[] _formats = new[]
    {
      new FileFormatPdf()
    };

    public static AbstractFileFormat GetMatchingProvider(string path)
    {
      return _formats.FirstOrDefault(x => x.MatchesFileExtension(path));
    }
  }
}
