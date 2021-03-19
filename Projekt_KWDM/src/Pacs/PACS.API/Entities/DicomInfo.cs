using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PACS.API.Entities
{
    public class DicomInfo
    {

        public string id { get; set; }
        public string studyInstanceUID { get; set; }
        public string seriesInstanceUID { get; set; }
        public string SOPInstanceUID { get; set; }
    }
}
