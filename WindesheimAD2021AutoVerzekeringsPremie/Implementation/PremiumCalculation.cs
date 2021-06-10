using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindesheimAD2021AutoVerzekeringsPremie.Implementation
{
    internal class PremiumCalculation
    {
        public double PremiumAmountPerYear { get; private set; }
        private readonly int PRECISION = 2;

        internal enum PaymentPeriod
        {
            YEAR,
            MONTH
        }
                
        internal PremiumCalculation(Vehicle vehicle, PolicyHolder policyHolder, InsuranceCoverage coverage)
        {
            
            double premium = 0d;
            premium += CalculateBasePremium(vehicle);

            if(policyHolder.Age < 23 || policyHolder.LicenseAge < 5) // <= naar < omdat licenseAge ONDER de 5 moet.
            {
                premium *= 1.15;
            }

            premium = UpdatePremiumForPostalCode(premium, policyHolder.PostalCode);

            if(coverage == InsuranceCoverage.WA_PLUS)
            {
                premium *= 1.2;
            } else if (coverage == InsuranceCoverage.ALL_RISK)
            {
                premium *= 2;
            }

            premium = UpdatePremiumForNoClaimYears(premium, policyHolder.NoClaimYears);

            PremiumAmountPerYear = Math.Round(premium, PRECISION); // Zonder Math.Round en PRECISION wordt premie niet goed afgerond naar 2 cijfers achter de komma.

        }

        private static double UpdatePremiumForNoClaimYears(double premium, int years)
        {
            double NoClaimPercentage = (years - 5) * 5;  // int naar double, anders krijg je na 6+ jaar schadevrij invullen een premie van 0
            if (NoClaimPercentage > 65) { NoClaimPercentage = 65; }
            if (NoClaimPercentage < 0) { NoClaimPercentage = 0; }
            return premium * ((100 - NoClaimPercentage) / 100);
        }

        private static double UpdatePremiumForPostalCode(double premium, int postalCode) => postalCode switch
        {
            >= 1000 and < 3600 => premium * 1.05,
            < 4500 => premium * 1.02,
            _ => premium,
        };

        internal double PremiumPaymentAmount(PaymentPeriod period)
        {
            double result = period == PaymentPeriod.YEAR ? PremiumAmountPerYear / 1.025 : PremiumAmountPerYear / 12;
            return Math.Round(result, PRECISION);
        }

        internal static double CalculateBasePremium(Vehicle vehicle)
        {
            double basepremium = vehicle.ValueInEuros / 100 - vehicle.Age + vehicle.PowerInKw / 5 / 3; 
            return Math.Round(basepremium, 2); // d.m.v omzetten naar double en math.round aanroepen wordt de basispremie fatsoenlijk afgerond tot 2 decimalen.
        }
    }
}
