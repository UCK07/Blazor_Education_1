using AutoMapper;
using Blazor_Education.Services.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;

namespace Blazor_Education.Services.Concreates
{
    public class CourseBlazor : ICourseBlazor
    {
        private readonly BlazorCourseContext _context;
        private readonly IMapper _mapper;

        public CourseBlazor(BlazorCourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CourseDto>> CreateAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<CourseDto, Course>(courseDto);
            course.CreatedBy = "umutttx"; /*istersen değiştirebilirsin unutma..*/
            var addCourse = await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            var returnData = _mapper.Map<Course, CourseDto>(addCourse.Entity);
            return new Result<CourseDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
        }

        public async Task<Result<int>> DeleteCourse(int courseId)                //id lerde int unutma
        {
            var courseDetails = await _context.Courses.FindAsync(courseId);
            if (courseDetails != null)
            {
                _context.Courses.Remove(courseDetails);
                var result = await _context.SaveChangesAsync();
                return new Result<int>(true, ResultConstant.RecordRemoveSuccessfully, result);

            }
            return new Result<int>(false, ResultConstant.RecordRemoveNotSuccessfully);

        }

        public async Task<Result<CourseDto>> GetCourse(int courseId)
        {
            try
            {
                var data = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
                var returnData = _mapper.Map<Course, CourseDto>(data);
                return new Result<CourseDto>(true, ResultConstant.RecordFound, returnData);
                

            }
            catch (Exception ex)
            {

                return new Result<CourseDto> (false, ResultConstant.RecordNotFound);
            }
        }

        public async Task<Result<IEnumerable<CourseDto>>> GetCourseAll()
        {
            try
            {
                var courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_context.Courses);
                return new Result<IEnumerable<CourseDto>>(true, ResultConstant.RecordFound, courseDtos, courseDtos.ToList().Count);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<CourseDto>>(false, ResultConstant.RecordNotFound);

            }
        }

        public async Task<Result<CourseDto>> UpdateCourse(int courseId, CourseDto courseDto)
        {
            try
            {
                if (courseId == courseDto.Id)
                {
                    var courseDetails = await _context.Courses.FindAsync(courseId);
                    var course = _mapper.Map<CourseDto,Course>(courseDto,courseDetails);
                    course.UpdatedBy = "umutttx";
                    course.UpdatedDate = DateTime.Now.ToString();         
                    var updateCourse = _context.Courses.Update(course);
                    await _context.SaveChangesAsync();
                    var returndata = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                    return new Result<CourseDto>(true,ResultConstant.RecordUpdateSuccessfully, returndata);
                }
                else
                {
                     return new Result<CourseDto>(false, ResultConstant.RecordNotFound); 
                }
            }
            catch (Exception ex)
            {

                return new Result<CourseDto>(false, ResultConstant.RecordNotFound);
            }
        }

        Task<Result<CourseDto>> ICourseBlazor.DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
