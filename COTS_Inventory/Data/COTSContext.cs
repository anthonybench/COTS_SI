using Microsoft.EntityFrameworkCore;
using COTS_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COTS_Inventory.Data
{
    public class COTSContext : DbContext
    {
        public COTSContext (DbContextOptions<COTSContext> options)
            : base(options)
        {

        }

        // EF-Tracked Entity Sets for DB Migrations
        /*
            The first command will generate data-migration scripts that
            can be interpreted through Entity Framework. Note that only
            one un-commited migration file can exists at a time. The
            second command will generate or alter the related DB Instance.
            Enter these in the NuGeT console in Visual Studio.

            PM> Add-Migration <migration name>
            PM> Update-Database
        */
        public DbSet<ClientMachine> ClientMachines { get; set; }
        public DbSet<Install> Installs { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
