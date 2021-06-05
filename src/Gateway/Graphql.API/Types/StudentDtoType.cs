using Gateway.AddressInfo;
using Gateway.StudentInfo;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Graphql.API.Types
{
    public class StudentDtoType
        : ObjectType<StudentDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentDto> descriptor)
        {
            descriptor.Name("Student");

            descriptor
                .Field("Address")
                .Resolve(async (ctx, token) =>
                {
                    var addressService = ctx.Services
                        .GetRequiredService<IAddressServiceClient>();
                    var address = await addressService
                        .GetAddressAsync(ctx.Parent<StudentDto>().Id, token);
                    return address;
                });
        }
    }
}
