using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;
using static WindesheimAD2021AutoVerzekeringsPremie.Implementation.PremiumCalculation;

namespace WindesheimAD2021AutoVerzekeringsPremieTest
{
    public class PremiumCalculationTests
    {

        // Checks if base premium is calculated properly
        [Fact]
        public void BasePremiumIsCalculatedProperly()
        {
            // Arrange
            Vehicle vehicle = new(210, 4500, 1999);
            double expected = 37;

            // Act
            double actual = PremiumCalculation.CalculateBasePremium(vehicle);

            // Assert
            Assert.Equal(expected, actual);
        }

        // Checks if monthly base premium is calculated properly
        [Fact]
        public void BasePremiumPerMonthIsCalculatedProperly()
        {
            // Arrange
            Vehicle vehicle = new(210, 4500, 1999);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;
            PolicyHolder policyHolder = new(35, "06-11-2014", 1045, 0);
            PremiumCalculation premiumCalculation = new(vehicle, policyHolder, InsuranceCoverage.WA);
            double expected = 3.24;


            // Act
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            // Assert
            Assert.Equal(expected, actual);

        }

        // Checks if Yearly base premium is calculated properly
        [Fact]
        public void BasePremiumPerYearIsCalculatedProperly()
        {
            // Arrange
            Vehicle vehicle = new(210, 4500, 1999);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;
            PolicyHolder policyHolder = new(35, "06-11-2014", 1045, 0);
            PremiumCalculation premiumCalculation = new(vehicle, policyHolder, InsuranceCoverage.WA);
            double expected = 37.90;


            // Act
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            // Assert
            Assert.Equal(expected, actual);

        }


        // Checks if premium has additional 15% based on driver age and license age
        [Theory]
        [InlineData(20, "24-03-2020", 1350, 0, 44.68)] // younger than 23, license less than 5 years old
        [InlineData(20, "24-03-2014", 1350, 0, 44.68)] // younger than 23, license more than 5 years old
        [InlineData(31, "09-10-2020", 1040, 2, 44.68)] // older than 23, license less that 5 years old
        [InlineData(31, "09-10-2014", 1040, 2, 38.85)] // older than 23, license more that 5 years old
        public void PremiumAppliesFifteenPercenWhenLicenseIsFiveYearsOldOrDriverAgeLessThanTwentyThreeYearsOld(int age, string DriversLicenseStartDate, int PostalCode, int NoClaimYears, double expected)
        {
            // Arrange
            Vehicle vehicle = new Vehicle(210, 4500, 1999);
            PolicyHolder policyHolder = new PolicyHolder(age, DriversLicenseStartDate, PostalCode, NoClaimYears);
            PremiumCalculation premiumCalculation = new(vehicle, policyHolder, InsuranceCoverage.WA);

            // Act
            double actual = premiumCalculation.PremiumAmountPerYear;

            // Assert
            Assert.Equal(expected, actual);
        }


        // Checks if risk surcharge is calculated based on zipcode
        [Theory]
        [InlineData(31, "09-10-2014", 1040, 2, 38.85)] // in zipcode range 10xx - 35xx 
        [InlineData(31, "09-10-2014", 3500, 2, 38.85)] // in zipcode 3500
        [InlineData(31, "09-10-2014", 3600, 2, 37.74)] // in zipcode 3600
        [InlineData(31, "09-10-2014", 3650, 2, 37.74)] // in zipcode range 36xx - 44xx 
        public void PremiumAppliesRiskSurchargeBasedOnZipcode(int age, string DriversLicenseStartDate, int PostalCode, int NoClaimYears, double expected)
        {
            // Arrange
            Vehicle vehicle = new Vehicle(210, 4500, 1999);
            PolicyHolder policyHolder = new PolicyHolder(age, DriversLicenseStartDate, PostalCode, NoClaimYears);
            PremiumCalculation premiumCalculation = new(vehicle, policyHolder, InsuranceCoverage.WA);

            // Act
            double actual = premiumCalculation.PremiumAmountPerYear;

            // Assert
            Assert.Equal(expected, actual);
        }


        // Checks if discount based on damage free years is calculated correctly
        [Theory]
        [InlineData(5, 38.85)] // base
        [InlineData(6, 36.91)] // 5% bracket
        [InlineData(8, 33.02)] // 15% bracket
        [InlineData(18, 13.60)] // 65% bracket (max)
        [InlineData(19, 13.60)] // 65% (doesnt go over max)
        public void PremiumDiscountOnDamageFreeYearsCalculatedCorrectly(int NoClaimYears, double expected)
        {
            // Arrange
            Vehicle vehicle = new Vehicle(210, 4500, 1999);
            PolicyHolder policyHolder = new PolicyHolder(31, "09-10-2014", 1040, NoClaimYears);
            PremiumCalculation premiumCalculation = new(vehicle, policyHolder, InsuranceCoverage.WA);

            // Act
            double actual = premiumCalculation.PremiumAmountPerYear;

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
