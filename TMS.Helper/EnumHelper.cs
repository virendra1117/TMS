using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Helper
{
   public class EnumHelper
    {
       public static List<EnumModel> GetEnumList<T>()
       {
           List<EnumModel> lst = new List<EnumModel>();
           foreach (var name in Enum.GetNames(typeof(T)))
           {
               lst.Add(new EnumModel() { Value = (int)Enum.Parse(typeof(T), name), Name = name });
           }
           return lst;
       }
       public class EnumModel
       {
           public int Value { get; set; }
           public string Name { get; set; }
       }

       public enum UserRoles
       {
           Admin = 1,
           Employee = 2,
           Customer=3,
       }
    }
}
