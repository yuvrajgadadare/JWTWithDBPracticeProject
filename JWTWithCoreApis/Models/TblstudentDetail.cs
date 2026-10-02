using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models;

public partial class TblstudentDetail
{
    [Key]
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? MobileNumber { get; set; }

    public string? City { get; set; }

    public string? EmailAddress { get; set; }
}
