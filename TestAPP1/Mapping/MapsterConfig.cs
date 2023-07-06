namespace TestAPP1.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            StudentDataProfile.Register(); 
        }
    }
}
