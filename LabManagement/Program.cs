using LabManagementWPF.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManagementWPF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Functions.DoDbUpdate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
      }
    }

    static class Functions
    { 
        public static void DoDbUpdate()
        {   
        DbMigrator migrator = new DbMigrator(new Configuration());
        foreach (string migration in migrator.GetPendingMigrations())
            Console.WriteLine(migration);
        migrator.Update();
        }
    }
}
