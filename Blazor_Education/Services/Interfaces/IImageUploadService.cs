namespace Blazor_Education.Services.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> Upload(int Id, string ImageUrl);
    }
}
