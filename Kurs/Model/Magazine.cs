using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kurs.Model;

public partial class Magazine:BaseClass
{
    [Key]
    public int MagazinesId { get; set; }
    private int number;
    public int Number
    {
        get { return number!; }
        set
        {
            number = value;
            OnPropertyChanged("Number");
        }

    }
    private string releaseDate;
    public string ReleaseDate
    {
        get { return releaseDate!; }
        set
        {
            releaseDate = value;
            OnPropertyChanged("ReleaseDate");
        }

    }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
