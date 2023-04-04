using KPService.Enum;
using KPService.Helper;
using System.Text.RegularExpressions;

namespace HelperTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ItemCondition_is_NewCondition()
        {
            // Arrange
            var regex = new Regex(@"(^!?https:\/\/schema.org\/)(.*$)"); //Item Condition
            var condition = "https://schema.org/NewCondition";
            var match = regex.Match(condition).Groups[2].Value;
            
            // Act
            var actualCondition = ConvertEnum<ItemCondition>.ToConvert(match);

            // Assert
            Assert.IsTrue(actualCondition.Equals(ItemCondition.NewCondition));
        }
    }
}