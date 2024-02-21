using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Author : EntityBase
    {
        public int Id  { get; set; }
    
        
        public int Age { get; set; }
        
    
        
        public bool Available { get; set; }
        
    
        
        public string Bio { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public int Popularity { get; set; }
        
    
        
        public int Ratings { get; set; }
        
    
    }
}
