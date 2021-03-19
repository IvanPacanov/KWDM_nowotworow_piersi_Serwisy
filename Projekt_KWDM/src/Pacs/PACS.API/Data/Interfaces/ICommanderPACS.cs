using PACS.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PACS.API.Data.Interfaces
{
    public interface ICommanderPACS
    {
        List<string> Find();
        List<string> FindStudy(string id);
        List<string> FindSeries(string id, string studyInstanceUID);
        List<string> FindInstances(string id, string studyInstanceUID, string seriesInstanceUID);
        byte[] Move(string id, string studyInstanceUID, string seriesInstanceUID, string SOPInstanceUID);

    }
}
