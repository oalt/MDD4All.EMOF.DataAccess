using MDD4All.EMOF.DataModels;
using MDD4All.EMOF.DataModels.Base;
using System.Collections.Generic;

namespace MDD4All.EMOF.DataAccess.Extensions
{
    public static class ElementExtensions
    {
        public static void AddOrSetTag(this Element element, EmofRepository repository, Tag tag)
        {
            if(!repository.Tags.ContainsKey(element))
            {
                Dictionary<string, Tag> elementTags = new Dictionary<string, Tag>();
                elementTags.Add(tag.Name, tag);
                repository.Tags.Add(element, elementTags);
            }
            else
            {
                Dictionary<string, Tag> existingTags = repository.Tags[element];
                if(existingTags.ContainsKey(tag.Name))
                {
                    existingTags[tag.Name] = tag;
                }
                else
                {
                    existingTags.Add(tag.Name, tag);
                }

            }
        }

        public static Tag? GetTag(this Element element, EmofRepository repository, string name)
        {
            Tag? result = null;

            if(repository.Tags.ContainsKey(element))
            {
                Dictionary<string, Tag> elementTags = repository.Tags[element];
                if(elementTags.ContainsKey(name))
                {
                    result = elementTags[name];
                }
            }

            return result;
        }

        public static Dictionary<string, Tag> GetTags(this Element element, EmofRepository repository)
        {
            Dictionary<string, Tag> result = new Dictionary<string, Tag>();

            if (repository.Tags.ContainsKey(element))
            {
                Dictionary<string, Tag> elementTags = repository.Tags[element];

                result = elementTags;
            }
            
            return result;
        }
    }
}
