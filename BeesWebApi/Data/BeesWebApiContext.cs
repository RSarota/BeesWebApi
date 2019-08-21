using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeesWebApi.Models
{
    public class BeesWebApiContext : DbContext
    {
        public BeesWebApiContext (DbContextOptions<BeesWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceLocation> DeviceLocations { get; set; }
    }
}
