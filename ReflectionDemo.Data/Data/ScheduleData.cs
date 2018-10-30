using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ReflectionDemo.Data.Models;

namespace ReflectionDemo.Data
{
    public class ScheduleData : EntityData<ScheduleData>
    {
        public class ColorChangeInfo
        {
            public int row { get; set; }
            public int column { get; set; }
        }
        List<ColorChangeInfo> colorChangeInfos = new List<ColorChangeInfo>();

        public List<ColorChangeInfo> GetColorChangeInfos()
        {
            return colorChangeInfos;
        }


        public Schedule SelectById(int entityId)
        {
            return CreateContext().Schedules.First(x => x.ScheduleId == entityId);
        }
        
        public List<GridRow> ConvertToGridRows(DateTime dateTime)
        {
            int daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);

            DateTime @from = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime to = new DateTime(dateTime.Year, dateTime.Month, daysInMonth);

            var query = from x in CreateContext().Schedules
                        where x.StartDate >= @from && x.StartDate <= to
                        group x by x.EmployeeId into g
                        select g;
            
            List<GridRow> rows = new List<GridRow>();

            int rowNum = 0;

            EmployeeData employeeData = new EmployeeData();
            Dictionary<int, string> employeeNames = employeeData.GetWithEmployeeName();
            Dictionary<int, string> employeeRanks =
            employeeData.GetWithEmployeeRank();
            
            foreach (var group in query.ToList())
            {
                GridRow row = new GridRow();
                row.Rank = employeeRanks[group.Key];
                row.Name = employeeNames[group.Key];
                row.EmployeeId = group.Key;
                

                List<Schedule> schedules = group.ToList();
                

                for (int i = 0; i < schedules.Count; i++)
                {
                    int period = schedules[i].EndDate.Day - schedules[i].StartDate.Day;
                    for (int j = 1; j <= daysInMonth; j++)
                    {
                        if (schedules[i].StartDate.Day == j)
                        {
                            Type type = row.GetType();
                            PropertyInfo propertyInfo = type.GetProperty($"D{j:D2}");
                            propertyInfo.SetValue(row, true);
                            colorChangeInfos.Add(new ColorChangeInfo(){row = rowNum, column = schedules[i].StartDate.Day});
                            
                            
                            for (int k = 0; k < period; k++)
                            {
                                propertyInfo = type.GetProperty($"D{j+k+1:D2}");
                                propertyInfo.SetValue(row, true);
                                colorChangeInfos.Add(new ColorChangeInfo() { row = rowNum, column = schedules[i].StartDate.Day +k +1 });
                            }
                        }
                        
                    }
                }
                /*
                for (int i = 0; i < schedules.Count; i++)
                {
                    int days = schedules[i].EndDate.Day - schedules[i].StartDate.Day;
                    //                    for (int day = 1; day <= daysInMonth; day++)
                    //                    {
                    if (schedules[i].StartDate.Day == 1)
                    {
                        row.D01 = true;
                        continue;
                    }
                    if (schedules[i].StartDate.Day == 2)
                        row.D02 = true;
                    if (schedules[i].StartDate.Day == 3)
                        row.D03 = true;
                    if (schedules[i].StartDate.Day == 4)
                        row.D04 = true;
                    if (schedules[i].StartDate.Day == 5)
                        row.D05 = true;
                    if (schedules[i].StartDate.Day == 6)
                        row.D06 = true;
                    if (schedules[i].StartDate.Day == 7)
                        row.D07 = true;
                    if (schedules[i].StartDate.Day == 8)
                        row.D08 = true;
                    if (schedules[i].StartDate.Day == 9)
                        row.D09 = true;
                    if (schedules[i].StartDate.Day == 10)
                        row.D10 = true;
                    if (schedules[i].StartDate.Day == 11)
                        row.D11 = true;
                    if (schedules[i].StartDate.Day == 12)
                        row.D12 = true;
                    if (schedules[i].StartDate.Day == 13)
                        row.D13 = true;
                    if (schedules[i].StartDate.Day == 14)
                        row.D14 = true;
                    if (schedules[i].StartDate.Day == 15)
                        row.D15 = true;
                    if (schedules[i].StartDate.Day == 16)
                        row.D16 = true;
                    if (schedules[i].StartDate.Day == 17)
                        row.D17 = true;
                    if (schedules[i].StartDate.Day == 18)
                        row.D18 = true;
                    if (schedules[i].StartDate.Day == 19)
                    {
                        row.D19 = true;
                        continue;
                    }
                    if (schedules[i].StartDate.Day == 20)
                        row.D20 = true;
                    if (schedules[i].StartDate.Day == 21)
                        row.D21 = true;
                    if (schedules[i].StartDate.Day == 22)
                        row.D22 = true;
                    if (schedules[i].StartDate.Day == 23)
                        row.D23 = true;
                    if (schedules[i].StartDate.Day == 24)
                        row.D24 = true;
                    if (schedules[i].StartDate.Day == 25)
                        row.D25 = true;
                    if (schedules[i].StartDate.Day == 26)
                        row.D26 = true;
                    if (schedules[i].StartDate.Day == 27)
                        row.D27 = true;
                    if (schedules[i].StartDate.Day == 28)
                        row.D28 = true;
                    if (schedules[i].StartDate.Day == 29)
                        row.D29 = true;
                    if (schedules[i].StartDate.Day == 30)
                        row.D30 = true;
                    if (schedules[i].StartDate.Day == 31)
                        row.D31 = true;

                                       }
                }
                */
                rowNum++;
                rows.Add(row);
            }

            return rows;
            //
            //            var query = from x in CreateContext().Schedules
            //                where x.Date >= @from && x.Date <= to
            //                select x;
            //
            //            Dictionary<int, List<Schedule>> groups = new Dictionary<int, List<Schedule>>();
            //
            //            foreach (var schedule in query)
            //            {
            //                if (groups.ContainsKey(schedule.EmployeeId) == false)
            //                    groups.Add(schedule.EmployeeId, new List<Schedule>());
            //
            //                groups[schedule.EmployeeId].Add(schedule);
            //            }

        }
    }
}