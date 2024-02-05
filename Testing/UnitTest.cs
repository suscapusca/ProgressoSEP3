using App.DAOInterface;
using DataAccess.DAO;
using DataAccessClient;

namespace Testing;

public class UnitTest
{
    private IProjectDAO _projectDao;
    [SetUp]
    public void Setup()
    {
        _projectDao = new ProjectDAO(); // Initialize your implementation of IProjectDao here
    }

    
    //UserTesting
    [Test]
    public void UserTest1()
    {
        
        UserCreationDto user = new UserCreationDto
        {
           
            Password = "password",
            Username = "Vatsal1"
        };
        string actual = user.Username;
        string expected = "Vatsal1";
        Assert.AreEqual(expected, actual);
    }
    
   
    
    //ProjectTesting
    [Test]
    public void ProjectTest1()
    {
        ProjectCreationDto project = new ProjectCreationDto
        {
         Title = "Project1",
         OwnerUsername = "Vatsal1"
    
        };
        String actual = project.OwnerUsername;
        String expected = "Vatsal1";
        Assert.AreEqual(expected, actual);
    }
    
   
    
    
    
}