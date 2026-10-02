using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTWithCoreApis.Models;

public partial class Tblemployee
{
    [Key]
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string? Designation { get; set; }

    public string? Password { get; set; }
}
