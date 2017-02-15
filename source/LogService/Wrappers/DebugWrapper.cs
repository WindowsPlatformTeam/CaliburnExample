using System.Diagnostics;
using LoggerService.Contracts;

namespace LoggerService.Wrappers
{
    public class DebugWrapper : IDebugWrapper
    {
        public void WriteLine(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
