using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Enumerations;

public enum UserOption
{
    [Description("Normal")]
    Normal = 1,
    [Description("Administrator")]
    Administrator = 2
}
