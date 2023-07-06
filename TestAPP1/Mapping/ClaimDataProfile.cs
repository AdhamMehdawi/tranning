using Mapster;

namespace TestAPP1.Mapping
{
    public class StudentDataProfile
    {
        public static void Register()
        {
            TypeAdapterConfig<Student.StudentDto, Domain.Entities.Student>
                .NewConfig()
                .Map(dest => dest.Email, src => src.Email) 
                .TwoWays();
        }
    }
}
