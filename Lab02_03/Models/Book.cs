using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab02_03.Models
{
    public class Book
    {
        private int id;
        [Required(ErrorMessage = "Mã sách không được trống")]
        [Display(Name = "Mã sách")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string title;

        [Required(ErrorMessage = "Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề không vượt quá 250 ký tự")]
        [Display(Name = "Tiêu đề")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string author;


        [Required(ErrorMessage = "Tác giả không được trống")]
        [StringLength(250, ErrorMessage = "Tên tác giả không vượt quá 250 ký tự")]
        [Display(Name = "Tác giả")]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string img_cover;
        [Required(ErrorMessage = "Link bìa sách không được trống")]
        [Display(Name = "Bìa Sách")]
        public string Imgcover
        {
            get { return img_cover; }
            set { img_cover = value; }
        }

        public Book(int id, string title, string author, string img_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.img_cover = img_cover;
        }

        public Book()
        {
        }
    }
}