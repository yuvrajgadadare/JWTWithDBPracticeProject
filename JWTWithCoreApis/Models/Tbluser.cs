using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models;

public partial class Tbluser
{
    [Key]
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? EmailAddress { get; set; }

    public string? MobileNumber { get; set; }

    public string? City { get; set; }

    public string? ProfilePhoto { get; set; }
}
