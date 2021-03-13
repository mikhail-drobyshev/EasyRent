using System.Collections.Generic;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.AppDataInit
{
    public static class DataInit
    {

        public static void DropDatabase(AppDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
        }

        public static void MigrateDatabase(AppDbContext ctx)
        {
            ctx.Database.Migrate();
        }
        
        // public static void SeedAppData(AppDbContext ctx)
        // {
        //     var ptypeFlat = new PropertyType()
        //     {
        //         PropertyTypeValue = "Flat"
        //     };
        //     var ptypeHouse = new PropertyType()
        //     {
        //         PropertyTypeValue = "House"
        //     };
        //     var ptypeShare = new PropertyType()
        //     {
        //         PropertyTypeValue = "PropertyShare"
        //     };
        //     
        //     
        //     ctx.SaveChanges();
        // }
        
    }
}