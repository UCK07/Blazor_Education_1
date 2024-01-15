using Blazor_Education.Services.Interfaces;
using Blazor_Education.Services.Concreates;
using Microsoft.AspNetCore.Components;
using Shared.Dto;

namespace Blazor_Education.Pages.CoursePages
{
    public partial class CourseList
    {
        private IEnumerable<CourseDto> CourseModelList { get; set; } = new List<CourseDto>();
        [Inject] private ICourseBlazor _courseRepository { get; set; }
        public string ErrorMessage { get; set; }

        //Videodaki örnek
        //protected override async Task OnInitializedAsync()
        //{
        //    var data = await _courseRepository.GetCourseAll();
        //    if (!data.IsSuccess)
        //    {
        //        ErrorMessage = data.Message;                              
        //    }
        //    else
        //    {
        //        CourseModelList = data.Data;
        //    }
        //}

        protected async override Task OnInitializedAsync()
        {
            await GetCourseAll();
        }

        private async Task GetCourseAll()
        {
            var response = await _courseRepository.GetCourseAll();
            if (response != null)
            {
                CourseModelList = response.Data;
            }
        }

    }
}
