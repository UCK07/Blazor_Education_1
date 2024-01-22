using Blazor_Education.Services.Interfaces;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Dto;

namespace Blazor_Education.Pages.CoursePages
{
    public partial class CourseCreateOrUpdate
    {
        private CourseDto courseMode { get; set; } = new CourseDto();
        [Inject] private ICourseBlazor _courseRepository { get; set; }
        [Inject] private NavigationManager _navigationManager { get; set; }
        [Inject] private IToastService _toast1 { get; set; }
        [Parameter] public int? Id { get; set; }  // Edit Id:int
        private string Title { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
            {
                Title = "Update";
                var data = await _courseRepository.GetCourse((int)Id);
                courseMode = data.Data;
            }
            else
            {

            }
        }

        private async Task CourseCreateOrUpdateM()
        {
            try
            {
                if (Id != null)
                {
                    var updateData = await _courseRepository.UpdateCourse((int)Id, courseMode);
                    if (updateData.IsSuccess)
                    {
                        _toast1.ShowSuccess("Update Successful");
                        _navigationManager.NavigateTo("courselist");
                    }
                    else
                    {
                        _toast1.ShowError("Update Failed");
                    }

                }
                else
                {
                    var created = await _courseRepository.CreateAsync(courseMode);
                    if (created.IsSuccess)
                    {
                        _toast1.ShowSuccess("Created Successful Babyyyy");
                        _navigationManager.NavigateTo("courselist");
                    }
                    else
                    {
                        _toast1.ShowError("Created Failed Babyy");
                    }
                }

            }
            catch (Exception ex)
            {

                _toast1.ShowError(ex.Message.ToString());
            }

        }
        private async Task ImageUpload(InputFileChangeEventArgs e)
        {
            try
            {
                var files = e.GetMultipleFiles(1);
                courseMode.ImageUrl = e.File.Name;
                var buf = new byte[e.File.Size];
                await using (var stream = e.File.OpenReadStream(10000000))
                {
                    var readAsync = await stream.ReadAsync(buf);
                    courseMode.ImageBase64 = Convert.ToBase64String(buf);
                }
                StateHasChanged();
                _toast1.ShowInfo("Image Added");
            }
            catch (Exception ex)
            {

                _toast1.ShowError(ex.Message);
            }
        }
        
    }

}
