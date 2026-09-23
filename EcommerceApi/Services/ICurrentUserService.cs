namespace EcommerceApi.Services
{
    public interface ICurrentUserService
    {
        int? userId { get; }
        string? Role { get; }
    }
}
