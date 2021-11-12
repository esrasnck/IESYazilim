﻿using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISerialNumberService
    {
        IResult Add(SerialNumber serialNumber);
    }
}
