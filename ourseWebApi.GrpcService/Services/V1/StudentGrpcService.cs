using AutoMapper;
using CourseWebApi.GrpcService.Protos.V1;
using CourseWebApi.Model.Services;
using CourseWebApi.Model.Student.Dtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static CourseWebApi.GrpcService.Protos.V1.StudentService;

namespace CourseWebApi.GrpcService.Services.V1
{
    public class StudentGrpcService : StudentServiceBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentGrpcService(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public override async Task CreateStudent(IAsyncStreamReader<StudentCreateRequest> requestStream, IServerStreamWriter<StudentCreateReply> responseStream, ServerCallContext context)
        {
            await foreach (var item in requestStream.ReadAllAsync())
            {
                var serviceResult = await _studentService.CreateAsync(new StudentModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    StudentNumber = item.StudentNumber,
                    Description = item.Description,
                    PhoneNumbers = item.PhoneNumbers.Select(p => new PhoneNumberModel
                    {
                        Number = p
                    }).ToList(),
                });
                await responseStream.WriteAsync(new StudentCreateReply
                {
                    Id = serviceResult
                });

            }
            await Task.CompletedTask;

        }
        public override async Task<StudentDeleteReply> DeleteStudent(StudentByIdRequest request, ServerCallContext context)
        {
            var serviceResult = await _studentService.DeleteAsync(request.ID);
            return new StudentDeleteReply
            {
                Success = serviceResult
            };
        }
        public override async Task<StudentUpdateReply> UpdatePerson(StudentUpdateRequest request, ServerCallContext context)
        {
            var serviceResult = await _studentService.UpdateAsync(new StudentModel
            {
                StudentId = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Description = request.Description
            });
            return new StudentUpdateReply
            {
                Success = serviceResult
            };
        }
        public override async Task<StudentReply> GetById(StudentByIdRequest request, ServerCallContext context)
        {
            var student = await _studentService.GetByIdAsync(request.ID);
            if (student is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Student with id {request.ID} not found"));
            }
            var reply = new StudentReply
            {
                Id = student.StudentId,
                Description = student.Description,
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentNumber = student.StudentNumber,

            };
            reply.PhoneNumbers.AddRange(student.PhoneNumbers.Select(p => p.Number));
            return reply;
        }
        public override async Task GetAll(Empty request, IServerStreamWriter<StudentReply> responseStream, ServerCallContext context)
        {
            var students = await _studentService.GetAllAsync();
            foreach (var student in students)
            {
                var reply = new StudentReply
                {
                    Id = student.StudentId,
                    Description = student.Description,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    StudentNumber = student.StudentNumber,

                };
                reply.PhoneNumbers.AddRange(student.PhoneNumbers.Select(p => p.Number));
                await responseStream.WriteAsync(reply);
            }
            await Task.CompletedTask;
        }

    }
}
