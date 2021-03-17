using PACS.API.Data.Interfaces;
using PACS.API.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PACS.API.Data
{
    public class PacsCommander : ICommanderPACS
    {

        private readonly object _locker = new object();

        public byte[] TakeImage(ImageInfo seriesModel)
        {
            lock (_locker)
            {
                FileInfo fileInfo = new FileInfo($".\\odebrane\\{seriesModel.NameFolder}\\{seriesModel.Id.Remove(seriesModel.Id.Length - 4)}.dcm_warstwa0.jpg");
                gdcm.ERootType typ = gdcm.ERootType.ePatientRootType;
                byte[] data = new byte[fileInfo.Length];
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(data, 0, data.Length);
                }
              //  fileInfo.Delete();
                return data;
            }
        }
    }
}
