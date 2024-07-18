using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Location
{
    public class LocationInsideDto
    {

        public float Lat { get; set; }
        public float Lng { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}