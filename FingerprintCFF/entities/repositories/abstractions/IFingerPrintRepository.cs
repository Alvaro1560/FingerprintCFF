using FingerprintCFF.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerprintCFF.entities.repositories.abstractions
{
    internal interface IFingerPrintRepository
    {
        int CreateHuella(UserFingerprint userFingerprint);
        List<UserFingerprint> GetFingerPrints();
        List<UserFingerprint> GetFingerPrintAll();
    }
}
