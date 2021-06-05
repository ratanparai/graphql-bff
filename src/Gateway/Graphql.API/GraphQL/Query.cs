using System.Threading.Tasks;
using Gateway.StudentInfo;
using HotChocolate;

namespace Graphql.API.GraphQL
{
    public class Query
    {
        public Task<StudentDto> GetStudentByIdAsync(
            string id,
            [Service] IStudentServiceClient studentServiceClient)
        {
            return studentServiceClient.GetStudentAsync(id);
        }
    }
}
