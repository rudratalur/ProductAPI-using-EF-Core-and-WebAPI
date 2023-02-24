using webAPIinterviewPractice.Model.Domain;
using webAPIinterviewPractice.Model.DTO;

namespace webAPIinterviewPractice.Model.Profile
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTOclass>().ReverseMap();
        }
    }
}
