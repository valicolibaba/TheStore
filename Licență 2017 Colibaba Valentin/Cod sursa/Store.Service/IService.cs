using System.ServiceModel;

namespace Store.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetMessage();
    }
}
