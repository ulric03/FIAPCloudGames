using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Infrastructure.Context;

public partial class FCGContext: DbContext
{
    public FCGContext(DbContextOptions<FCGContext> options) : base(options)
    {

    }
}
