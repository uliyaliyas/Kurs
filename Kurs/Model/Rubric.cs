using System;
using System.Collections.Generic;

namespace Kurs.Model;

public partial class Rubric
{
    public int RubricsId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
