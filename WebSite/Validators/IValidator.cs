﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Validators
{
    public interface IValidator<T>
    {
        bool Validate(T input);
    }
}
