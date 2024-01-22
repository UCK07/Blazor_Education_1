namespace Blazor_Education.Helper
{
    public class AppStateManager
    {
        public Task<string> PrepareUniqueImageName(string fileName)
        {
            var randomName = Path.GetRandomFileName();
            var extension = Path.GetExtension(fileName);
            var newFileName = Path.ChangeExtension(randomName, extension);
            return Task.FromResult(newFileName);
        }


    }
}
