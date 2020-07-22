using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioOutput_Manager
{
    public class AudioControllerViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }
    }
}
