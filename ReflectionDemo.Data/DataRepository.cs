using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReflectionDemo.Data.Data
{
    public class DataRepository
    {
        #region Employee
        private static EmployeeData _employee;

        public static EmployeeData Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new EmployeeData();

                return _employee;
            }
        }
        #endregion

        #region Schedule
        private static ScheduleData _schedule;

        public static ScheduleData Schedule
        {
            get
            {
                if (_schedule == null)
                    _schedule = new ScheduleData();

                return _schedule;
            }
        }
        #endregion
    }
}
