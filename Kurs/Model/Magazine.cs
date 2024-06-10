using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Magazine
{
    public int MagazinesId { get; set; }

    public int Number { get; set; }

    public string ReleaseDate { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
