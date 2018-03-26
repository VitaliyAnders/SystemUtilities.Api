using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SystemData.BL.Api;
using SystemData.BL.Model.Dto;

namespace SystemData.BL
{
    public sealed class SystemProcessFacade: ISystemProcessFacade
    {
        public IEnumerable<SystemProcessDto> GetAllRunningProcessNames()
        {
            Process[] processlist = Process.GetProcesses();
            return processlist?.Select(pr => 
                new SystemProcessDto
                {
                    Id = pr.Id,
                    Title = pr.ProcessName
                });
        }

        public bool StopProcess(int id)
        {
            var worker = Process.GetProcessById(id);
            if (worker == null)
                return false;

            worker.Kill();
            worker.WaitForExit();
            worker.Dispose();
            return true;
            
        }
    }
}
