using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class Crud_Context: DbContext
    {
        public Crud_Context(DbContextOptions options): base(options)
        {

        }


    }
}
