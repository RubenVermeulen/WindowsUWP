using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.Model
{
    public class DummyDataSource
    {
        public static List<Campus> Campuses { get; set; } = new List<Campus>()
        {
           new Campus() { Name = "Schoonmeersen", Address = "Some address"},
           new Campus() { Name = "Bijloke", Address = "Some address 2"}
        };
    }
}
