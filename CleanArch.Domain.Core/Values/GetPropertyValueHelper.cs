using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Values
{
    public static class GetPropertyValueHelper
    {



        public static string Get(object item, string member)
        {
            string name = null;


            try
            {
                System.Reflection.PropertyInfo pi = item.GetType().GetProperty(member);
                if (pi != null)
                {
                    name = (String)(pi.GetValue(item, null));
                }

            }
            catch (Exception)
            {

                name = null;
            }

            return name;
        }
    }
}
