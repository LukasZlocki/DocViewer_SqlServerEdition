using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocViewer_SqlServerEdition.Model
{
    class Document
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public string LoadingDocumentName { get; set; }
        public string UnloadingDocumentName { get; set; }
    }
}
