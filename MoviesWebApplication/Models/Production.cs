﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApplication
{
    public partial class Production
    {
        public Production()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Display(Name = "Назва")]
        public string Name { get; set; } = null!;

        [Display(Name = "Країна")]
        public string Country { get; set; } = null!;

        [Display(Name = "Довгота")]
        [DisplayFormat(DataFormatString = @"{0:F2}", HtmlEncode = false, ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public double Long { get; set; }

        [Display(Name = "Широта")]
        [DisplayFormat(DataFormatString = @"{0:F2}", HtmlEncode = false, ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public double Let { get; set; }

        [Display(Name = "Фільми")]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
