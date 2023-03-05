using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioLibrary.InputModels;

public class AuthorInputModel
{
    public string Name { get; set; }
    public int Year { get; set; }

    public AuthorInputModel() 
    {
        Name= string.Empty;
        Year= 0;
    }
}
