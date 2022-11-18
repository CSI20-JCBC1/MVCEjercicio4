﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Area
{
    public long Id { get; set; }

    public string Area1 { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
