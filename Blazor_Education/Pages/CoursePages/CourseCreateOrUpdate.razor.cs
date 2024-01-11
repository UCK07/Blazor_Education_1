using Blazor_Education.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Shared.Dto;

namespace Blazor_Education.Pages.CoursePages
{
    public partial class CourseCreateOrUpdate
    {
        private CourseDto courseMode { get; set; } = new CourseDto();
        [Inject] private ICourseBlazor _courseRepository { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }
   
        private async Task CourseCreateOrUpdateM()
        {
            var created = await _courseRepository.CreateAsync(courseMode);
            if (created.IsSuccess)
            {
                _navigationManager.NavigateTo("courselist");
            }
            //else
            //{
            //    *********Buraya hata mesajı verebilirsin Modal olabilir sana kalmış
            //}
        }
    }

}
