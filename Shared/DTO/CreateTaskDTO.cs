namespace Shared.DTO;

public class CreateTaskDTO
{
    public string Name { get; set; }
    public string Assignee { get; set; }
    

    public CreateTaskDTO(string name, string assignee)
    {
        Name = name;
        Assignee = assignee;
    }
}