using System;
using Xunit;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using static WindesheimAD2021AutoVerzekeringsPremie.Implementation.PremiumCalculation;

namespace WindesheimAD2021AutoVerzekeringsPremieTest
{
    public class VehicleTests
    {
        // Checks if vehicle age is calculated properly
        [Theory]
        [InlineData(160, 45000, 2015, 6)]
        [InlineData(270, 90000, 2018, 3)]
        [InlineData(270, 90000, 2022, 0)]
        public void VehicleAgeIsCalculatedCorrectly(int PowerInKw, int ValueInEuros, int constructionYear, int expected)
        {
            // Arrange
            Vehicle vehicle = new(PowerInKw, ValueInEuros, constructionYear);

            // Act
            int actual = vehicle.Age;

            // Assert
            Assert.Equal(expected, actual);
        }

        // Checks if vehicle value is calculated properly
        [Theory]
        [InlineData(160, 45000, 2015, 454.67)]
        [InlineData(270, 90000, 2018, 915)]
        public void VehicleValueIsCalculatedProperly(int PowerInKw, int ValueInEuros, int ConstructionYear, double expected)
        {
            //Arrange
            Vehicle vehicle = new Vehicle(PowerInKw, ValueInEuros, ConstructionYear);

            //Act
            double actual = CalculateBasePremium(vehicle);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
