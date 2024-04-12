using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "Bip";
        string lastName = "Bop";
        string email = "doe";
        DateTime birthDate = new DateTime(year: 1980, month: 5, day: 5);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_First_Name_Empty()
    {
        
        //Arrange
        string firstName = null;
        string lastName = "Bop";
        string email = "doe@gmail.com";
        DateTime birthDate = new DateTime(year: 1980, month: 5, day: 5);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Last_Name_Empty()
    {
        
        //Arrange
        string firstName = "John";
        string lastName = null;
        string email = "doe.@gmail.com";
        DateTime birthDate = new DateTime(year: 1980, month: 5, day: 5);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.Equal(false, result);
    }
    

    [Fact]
    public void AddUser_Should_Be_False_When_Age_Is_Below_21()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "doe.@gmail.com";
        DateTime birthDate = new DateTime(year: 2005, month: 5, day: 5);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void Should_Return_True_When_Very_Important_Client()
    {
        
        //Arrange
        int clientId = 2;
        ClientRepository clientRepository = new ClientRepository();
        Client client = clientRepository.GetById(clientId);
        
        //Act
        string result = clientRepository.checkImportance(client);
        
        //Assert
        Assert.Equal("VeryImportantClient", result);
    }
    
    [Fact]
    public void Should_Return_True_When_Important_Client()
    {
        
        //Arrange
        int clientId = 3;
        ClientRepository clientRepository = new ClientRepository();
        Client client = clientRepository.GetById(clientId);
        
        //Act
        string result = clientRepository.checkImportance(client);
        
        //Assert
        Assert.Equal("ImportantClient", result);
    }
    
    [Fact]
    public void Should_Return_True_When_Normal_Client()
    {
        
        //Arrange
        int clientId = 1;
        ClientRepository clientRepository = new ClientRepository();
        Client client = clientRepository.GetById(clientId);
        
        //Act
        string result = clientRepository.checkImportance(client);
        
        //Assert
        Assert.Equal("NormalClient", result);
    }
    
    
    
}