using System.Threading.Tasks;
using Refit;

namespace Exercise_6.Interfaces
{
    public interface IVietcombank
    {
        [Get("/exchangerates/ExrateXML.aspx")]
        Task<string> GetCurrencies();
    }
}