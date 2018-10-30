using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionDemo.Data.Data;
using ReflectionDemo.Data.Models;

namespace ReflectionDemo.Data
{
    public class EmployeeData : EntityData<Employee>
    {
        public Employee SelectById(int entityId)
        {
            return CreateContext().Employees.First(x => x.EmployeeId == entityId);
        }

        public Dictionary<int, string> GetWithEmployeeName()
        {
            Dictionary<int, string> dicnames = DataRepository.Employee.Get().ToDictionary(
                x => x.EmployeeId,
                x => x.Name
            );
            //            List<GridRow> names = Get();
            //
            //            foreach (var name in names)
            //            {
            //                if (name.EmployeeId == null)
            //                    name.Name = "no name";
            //                else
            //                    name.Name = dicnames[name.EmployeeId.Value];
            //            }
            //
            //            return names;
            return dicnames;
        }

        public Dictionary<int, string> GetWithEmployeeRank()
        {
            Dictionary<int, string> dicranks = DataRepository.Employee.Get().ToDictionary(
                x => x.EmployeeId,
                x => x.Rank
            );

            //            List<GridRow> ranks = Get();
            //
            //            foreach (var rank in ranks)
            //            {
            //                if (rank.EmployeeId == null)
            //                    rank.Rank = "no rank";
            //                else
            //                    rank.Rank = dicranks[rank.EmployeeId.Value];
            //            }

            return dicranks;
        }
    }
}