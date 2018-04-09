using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Controllers;

namespace Service.Implements
{
    public class SampleDataService : ISampleDataService
    {
        public List<SampleData> AllSample()
        {
            return new List<SampleData>(){
              new SampleData { rank= 1, rating= 9.2, year= 1994, title=  "The Shawshank Redemption" },
              new SampleData { rank= 2, rating= 9.2, year= 1972, title=  "The Godfather" },
              new SampleData { rank= 3, rating= 9, year= 1974, title=    "The Godfather: Part II" },
              new SampleData { rank= 4, rating= 8.9, year= 1966, title=  "Il buono, il brutto, il cattivo." },
              new SampleData { rank= 5, rating= 8.9, year= 1994, title=  "Pulp Fiction" },
              new SampleData { rank= 6, rating= 8.9, year= 1957, title=  "12 Angry Men" },
              new SampleData { rank= 7, rating= 8.9, year= 1993, title=  "Schindler's List" },
              new SampleData { rank= 8, rating= 8.8, year= 1975, title=  "One Flew Over the Cuckoo's Nest" },
              new SampleData { rank= 9, rating= 8.8, year= 2010, title=  "Inception" },
              new SampleData { rank= 10, rating= 8.8, year= 2008, title= "The Dark Knight" }
            };
        }
    }
}
