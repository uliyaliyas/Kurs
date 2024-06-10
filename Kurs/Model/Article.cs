using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kurs.Model;

public partial class Article:BaseClass
{
    [Key]
    public int ArticlesId { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    private int authorId;
    public int AuthorId
    {
        get { return authorId!; }
        set
        {
            authorId = value;
            OnPropertyChanged("Surname");
        }

    }
    private string rubricsId;
    public int RubricsId { get; set; }
    private string magazineId;
    public int MagazineId { get; set; }
    private string name;
    public string Name { get; set; } = null!;
    private string deliveryDate;
    public string DeliveryDate { get; set; } = null!;
    private string adoptionDate;
    public string AdoptionDate { get; set; } = null!;
    private string publicationDate;
    public string PublicationDate { get; set; } = null!;
    private string fee;
    public double Fee { get; set; }
    
    public virtual Author Author { get; set; } = null!;

    public virtual Magazine Magazine { get; set; } = null!;

    public virtual Rubric Rubrics { get; set; } = null!;
}
