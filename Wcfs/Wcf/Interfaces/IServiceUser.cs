using System.ServiceModel;

namespace Wcfs.Wcf.Interfaces
{
    [ServiceContract]
    public interface IServiceUser
    {
        [OperationContract]
        long CountUsers();
    }
}