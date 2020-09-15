using MusicApplication.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Models
{
    public class User : IDataObject
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
