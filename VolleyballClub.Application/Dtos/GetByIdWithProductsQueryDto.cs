namespace VolleyballClub.Application.Dtos
{
    public class GetByIdWithProductsQueryDto
    {
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
