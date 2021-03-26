using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InveonTodoList.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatDateTime { get; set; }
    }
}
