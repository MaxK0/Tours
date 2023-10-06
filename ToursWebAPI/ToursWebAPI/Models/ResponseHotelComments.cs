using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToursWebAPI.Entities;

namespace ToursWebAPI.Models
{
    public class ResponseHotelComments
    {
        public ResponseHotelComments(HotelComment hotel)
        {
            Id = hotel.Id;
            Text = hotel.Text;
            HotelId = hotel.HotelId;
            Author = hotel.Author;
            CreationDate = hotel.CreationDate;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int HotelId { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
    }
}