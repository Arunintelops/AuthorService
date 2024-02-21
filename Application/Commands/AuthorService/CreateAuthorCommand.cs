using MediatR;

namespace Application.Commands.AuthorService
{
    public class CreateAuthorCommand : IRequest<int>
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
