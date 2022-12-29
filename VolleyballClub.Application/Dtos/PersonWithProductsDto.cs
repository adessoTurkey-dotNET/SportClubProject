namespace VolleyballClub.Application.Dtos
{
    public class PersonWithProductsDto : PersonDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
