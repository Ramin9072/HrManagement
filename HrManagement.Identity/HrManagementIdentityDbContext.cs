using HrManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrManagement.Identity
{
    public class HrManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {

    }
}
