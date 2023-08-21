using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintCFF.entities.models
{
    public class UserFingerprint
    {
        public string Id { get; set; }
        public string Dni { get; set; }
        public string CodeStudent { get; set; }
        public byte[] Fingerprint { get; set; }
    }
}
