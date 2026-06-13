using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Model
{
    internal class Operator : BaseModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public Operator(int empId,string name)
        {
            this.EmpId = empId;
            this.Name = name;
        }
    }
}
