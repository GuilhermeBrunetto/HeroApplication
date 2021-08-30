using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public interface IPowerService
    {
        void AddPowerAsync(int id, string name);
    }
}