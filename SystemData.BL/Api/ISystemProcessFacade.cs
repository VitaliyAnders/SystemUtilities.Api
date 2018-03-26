using System.Collections.Generic;
using SystemData.BL.Model.Dto;

namespace SystemData.BL.Api
{
    public interface ISystemProcessFacade
    {
        IEnumerable<SystemProcessDto> GetAllRunningProcessNames();

        bool StopProcess(int id);
    }
}
