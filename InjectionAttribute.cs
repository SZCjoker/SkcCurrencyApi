using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class InjectionAttribute : Attribute
    {
        public InjectionAttribute() { }

        public InjectionAttribute(int index)
        {
            Index = index;
        }

        [Description("Sortting Index")]
        [DefaultValue(0)]
        public int Index { get; set; }
    }
}
