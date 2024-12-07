using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_And_Company_Management.Helpers
{
    public class DateConverter
    {
        public static DateOnly? ConvertToDateOnly(DateTime? dateTime)
        {
            return dateTime.HasValue ? DateOnly.FromDateTime(dateTime.Value) : null;
        }
    }
}
