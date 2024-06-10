using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kurs.Model;

public partial class Author:BaseClass
{
    [Key]
    public int AuthorId { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    private string fio;
    public string Fio
    {
        get { return fio!; }
        set
        {
            fio = value;
            OnPropertyChanged("Fio");
        }

    }
    private string birthDay;
    public string BirthDay
    {
        get { return birthDay!; }
        set
        {
            birthDay = value;
            OnPropertyChanged("BirthDay");
        }

    }
    private string phone;
    public string Phone
    {
        get { return phone!; }
        set
        {
            phone = value;
            OnPropertyChanged("Phone");
        }

    }
    private string email;
    public string Email
    {
        get { return email!; }
        set
        {
            email = value;
            OnPropertyChanged("Email");
        }

    }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
