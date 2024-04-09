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
    public void 
    
}