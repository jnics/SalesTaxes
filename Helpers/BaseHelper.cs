// using System;
// using System.Linq;
// using System.Collections.Generic;

// namespace SalesTaxes.Helpers
// {
//     public class BaseHelper
//     {
//         public static string GetDisplayName( Enum enumValue)
//         {

//             IEnumerable<Object> displayName;
//             displayName = enumValue.GetType().GetCustomAttributes(true).FirstOrDefault();
//             if (String.IsNullOrEmpty(displayName))
//             {
//                 return enumValue.ToString();
//             }
//             return displayName.ToString();
//         }
//     }
// }