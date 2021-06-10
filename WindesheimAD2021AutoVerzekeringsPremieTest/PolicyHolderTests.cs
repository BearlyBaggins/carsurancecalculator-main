using System;
using Xunit;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;

namespace WindesheimAD2021AutoVerzekeringsPremieTest
{
    public class PolicyHolderTests
    {
        // Checks if polyholder license age is calculated correctly
        [Theory]
        [InlineData(23, "19-05-2018", 1325, 2, 3)]
        [InlineData(23, "09-06-2021", 1325, 2, 0)]
        [InlineData(34, "05-01-2025", 1045, 6, -4)]
        public void PolicyHolderLicenseAgeIsCalculatedCorrectly(int Age, string DriverlicenseStartDate, int PostalCode, int NoClaimYears, int expected)
        {
            // Arrange
            PolicyHolder policyHolder = new(Age, DriverlicenseStartDate, PostalCode, NoClaimYears);

            // Act
            int actual = policyHolder.LicenseAge;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
