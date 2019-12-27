using Refit;
using System.Threading.Tasks;
using ViVo.Models;

namespace ViVo.Service
{
    public interface IRestApi
    {
        [Get("/{cep}/json")]
        Task<Cep> Cep(string cep);
    }
}
