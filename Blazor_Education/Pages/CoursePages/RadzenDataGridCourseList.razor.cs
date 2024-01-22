using Blazor_Education.Services.Interfaces;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Dto;

namespace Blazor_Education.Pages.CoursePages
{
    public partial class RadzenDataGridCourseList
    {
        public string ErrorMessage { get; private set; }

        //RadzenDataGrid<CourseDto> _radzendata;

        //List<CourseDto> _courses = new List<CourseDto>();
        private IEnumerable<CourseDto> CourseModelList { get; set; } = new List<CourseDto>();
        [Inject] private ICourseBlazor _courseRepository { get; set; }
        [Inject] IToastService _oastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var data = await _courseRepository.GetCourseAll();
            if (!data.IsSuccess)
            {
                _oastService.ShowError(data.Message);
            }
            else
            {
                CourseModelList = data.Data;
            }
        }



    }
}
