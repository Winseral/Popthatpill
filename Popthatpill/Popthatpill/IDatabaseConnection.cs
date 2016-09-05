using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;
using Popthatpill.ViewModels;

namespace Popthatpill
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
