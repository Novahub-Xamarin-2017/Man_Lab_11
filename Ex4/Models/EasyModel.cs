using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ex4.Models
{
    public class EasyModel
    {
        private readonly List<PropertyInfo> propertyInfos;

        public EasyModel()
        {
            propertyInfos = GetType().GetProperties().ToList();
        }

        public override string ToString()
        {
            return string.Join("\n", propertyInfos
                .Where(x => x.CanRead)
                .Select(x => $"\t\t\t{x.Name}: {x.GetValue(this)}"));
        }
    }
}