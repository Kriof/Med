using AutoMapper;

namespace RestServices.App_Start.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<TagProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
