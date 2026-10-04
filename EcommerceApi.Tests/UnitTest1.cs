namespace EcommerceApi.Tests
{
    public class Tests
    {
       

        [Test]
        public void Test1()
        {
            //Arrange
            int a = 5, b = 3;

            //Act
            int result = a + b;


            //Assert
            Assert.That(result, Is.EqualTo(10));

        }
    }
}
