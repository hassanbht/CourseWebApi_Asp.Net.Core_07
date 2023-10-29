using Ent = CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.Test.Tag.MockData
{
    public class MockDataHelper
    {
        public static List<Model.Tags.Entities.Tag> GetFakeTagList()
        {
            return new List<Model.Tags.Entities.Tag>()
            {
                new Ent.Tag
                {
                    Id = 1,
                    TagName = "c#",
                },
                new Ent.Tag
                {
                     Id =2,
                    TagName = "asp.net core",
                },
                 new Ent.Tag
                {
                     Id =3,
                    TagName = "entity framework",
                }
            };
        }
    }
}
