using Xunit;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using static WindesheimAD2021AutoVerzekeringsPremie.Implementation.PremiumCalculation;

namespace WindesheimAD2021AutoVerzekeringsPremieTest
{
    public class InsuranceCoverageTests
    {        
        // Should return base premium 
        [Fact]
        public void WACoveragePerYearResultsInBasePremium()
        {
            //Arrange
            Vehicle vehicle = new Vehicle(260, 8000, 2018);
            PolicyHolder policyHolder = new PolicyHolder(35, "15-05-2019", 1045, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;
            double expected = 111.12;

            //Act
            PremiumCalculation premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA);
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            //Assert
            Assert.Equal(expected, actual);
        }

        // Should return base premium / 12
        [Fact]
        public void  WACoveragePerMonthResultsInBasePremiumDividedByTwelve()
        {
            //Arrange
            Vehicle vehicle = new Vehicle(260, 8000, 2018);
            PolicyHolder policyHolder = new PolicyHolder(35, "15-05-2019", 1045, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;
            double expected = 9.49;


            //Act
            PremiumCalculation premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA);
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            //Assert
            Assert.Equal(expected, actual);
        }

        // Should return base premium + 20% (38.85 * 1.20)
        [Fact]
        public void WAPlusCoveragePerYearResultsInBasePremiumPlusTwentyPercent()
        {
            //Arrange
            Vehicle vehicle = new Vehicle(260, 8000, 2018);
            PolicyHolder policyHolder = new PolicyHolder(35, "15-05-2019", 1045, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;
            double expected = 133.35;

            //Act
            PremiumCalculation premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA_PLUS);
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            //Assert
            Assert.Equal(expected, actual);
        }

        // Should return base premium + 20% (38.85 * 1.20) / 12
        [Fact]
        public void WAPlusCoveragePerMonthResultsInBasePremiumPlusTwentyPercentDividedByTwelve()
        {
            //Arrange
            Vehicle vehicle = new Vehicle(260, 8000, 2018);
            PolicyHolder policyHolder = new PolicyHolder(35, "15-05-2019", 1045, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;
            double expected = 11.39;

            //Act
            PremiumCalculation premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.WA_PLUS);
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            //Assert
            Assert.Equal(expected, actual);
        }

        // Should return base premium * 2
        [Fact]
        public void AllRiskCoveragePerYearResultsInBasePremiumTimesTwo()
        {
            //Arrange
            Vehicle vehicle = new Vehicle(260, 8000, 2018);
            PolicyHolder policyHolder = new PolicyHolder(35, "15-05-2019", 1045, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;
            double expected = 222.25;

            //Act
            PremiumCalculation premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.ALL_RISK);
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            //Assert
            Assert.Equal(expected, actual);
        }

        // Should return base premium * 2 / 12
        [Fact]
        public void AllRiskCoveragePerMonthResultsInBasePremiumTimesTwoDividedByTwelve()
        {
            //Arrange
            Vehicle vehicle = new Vehicle(260, 8000, 2018);
            PolicyHolder policyHolder = new PolicyHolder(35, "15-05-2019", 1045, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;
            double expected = 18.98;

            //Act
            PremiumCalculation premiumCalculation = new PremiumCalculation(vehicle, policyHolder, InsuranceCoverage.ALL_RISK);
            double actual = premiumCalculation.PremiumPaymentAmount(paymentPeriod);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}