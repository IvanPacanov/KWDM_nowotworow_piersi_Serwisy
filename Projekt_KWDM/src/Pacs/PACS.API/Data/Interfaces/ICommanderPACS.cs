using PACS.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PACS.API.Data.Interfaces
{
    public interface ICommanderPACS
    {
        byte[] TakeImage(ImageInfo seriesModel);
    }
}
