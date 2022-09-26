﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebApplication
{
    public partial class Movie
    {
        public Movie()
        {
            ArtistsJobsInMovies = new HashSet<ArtistsJobsInMovie>();
            MoviesGenres = new HashSet<MoviesGenre>();
            MoviesInPlaylists = new HashSet<MoviesInPlaylist>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        [Display(Name = "Назва фільму")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Тривалість фільму (у хв)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Посилання на постер")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Посилання на саундтреки")]
        public string Soundtracks { get; set; }

        [Display(Name = "Код кінокомпанії")]
        public int ProductionId { get; set; }

        [Display(Name = "Кінокомпанія")]
        public virtual Production? Production { get; set; }


        [Display(Name = "Над фільмом працювали:")]
        public virtual ICollection<ArtistsJobsInMovie>? ArtistsJobsInMovies { get; set; } 

        [Display(Name = "Жанри")]
        public virtual ICollection<MoviesGenre>? MoviesGenres { get; set; }
        public virtual ICollection<MoviesInPlaylist>? MoviesInPlaylists { get; set; }
    }
}
