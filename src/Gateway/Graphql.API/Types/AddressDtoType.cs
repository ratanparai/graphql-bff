using Gateway.AddressInfo;
using HotChocolate.Types;

namespace Graphql.API.Types
{
    public class AddressDtoType
        : ObjectType<AddressDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AddressDto> descriptor)
        {
            descriptor.Name("Address");

            descriptor.Ignore(t => t.Id);
        }
    }
}
