using Shared.Dto;

namespace Blazor_Education.Services.Interfaces
{
    public interface ICourseBlazor
    {
        public Task<Result<CourseDto>> CreateAsync(CourseDto courseDto);
        public Task<Result<CourseDto>> UpdateCourse(int courseId,CourseDto courseDto);
        public Task<Result<CourseDto>> GetCourse(int courseId);
        public Task<Result<CourseDto>> DeleteCourse(int courseId);

        public Task<Result<IEnumerable<CourseDto>>> GetCourseAll();

    }
}
