using System.Threading.Tasks;

namespace WebSite.HTTP
{
    public interface IClientList<Toutput>
    {
        public Task<Toutput> GetAsync(string name);

        public Task<Toutput> GetHighestAsync(int count);
    }
}