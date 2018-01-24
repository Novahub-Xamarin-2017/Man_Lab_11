using System.Threading.Tasks;
using Refit;

namespace Exercise_5.Interfaces
{
    public interface ISjc
    {
        [Get("/xml/tygiavang.xml")]
        Task<string> Get();
    }
}