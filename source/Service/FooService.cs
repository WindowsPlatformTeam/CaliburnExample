using Common.ServiceContracts;

namespace FooService
{
    public class FooService : IFooService
    {
        private readonly ILogService _logService;

        public FooService(ILogService logService)
        {
            _logService = logService;
        }

        public void DoSomething()
        {
            _logService.Log("This service is doing something");    
        }
    }
}
