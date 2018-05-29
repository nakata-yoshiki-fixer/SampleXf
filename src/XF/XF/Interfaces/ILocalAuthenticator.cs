using System;
using System.Threading.Tasks;

namespace XF.Interfaces
{
    public interface ILocalAuthenticator
    {
		bool CheckDevice();
		Task<bool> AuthAsync();
    }
}
