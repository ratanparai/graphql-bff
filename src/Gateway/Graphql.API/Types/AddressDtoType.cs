using Gateway.AddressInfo;
using HotChocolate.Types;

namespace Graphql.API.Types
{
    public class AddressDtoType
        : ObjectType<AddressDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AddressDto> descriptor)
        {
            descriptor.Ignore(t => t.Id);
        }
    }
}
