using System.Threading.Tasks;
using static ECA.SOAP.Demo.Entities.NumberToWordsResponseEntity;

namespace ECA.SOAP.Demo.Repository.Interface
{
    public interface IDataAccessRepository
    {
        Task<NumberToWordsResponseXmlEntity> GetFulNameByNumber(int number);
    }
}