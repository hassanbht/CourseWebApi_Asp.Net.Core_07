using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Model.Tags.Dtos;

public class TagQuery
{
    public TagQuery(int id, string tagName)
    {
        Id = id;
        TagName = tagName;
    }

    public int Id { get; set; }
    public string TagName { get; set; }
}