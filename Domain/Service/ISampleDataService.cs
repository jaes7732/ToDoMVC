using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Controllers;

namespace Domain.Service
{
    public interface ISampleDataService
    {
        List<SampleData> AllSample();
    }
}
