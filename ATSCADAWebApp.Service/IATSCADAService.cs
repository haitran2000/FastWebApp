using System.ServiceModel;
using System.Collections.Generic;

namespace ATSCADAWebApp.Service
{
    [ServiceContract]
    public interface IATSCADAService
    {
        [OperationContract]
        ResultPackage[] Read(string[] names);

        [OperationContract]
        ResultPackage[] Write(WriteParam[] writeParams);
    }
}
