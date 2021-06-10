using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindesheimAD2021AutoVerzekeringsPremie.Implementation
{
    class PolicyHolder
    {
        public int Age { get; private set; }
        public int LicenseAge { get; private set; }
        public int PostalCode { get; private set; }
        public int NoClaimYears { get; private set; }

        internal PolicyHolder(int Age, string DriverlicenseStartDate, int PostalCode, int NoClaimYears )
        {
            this.Age = Age;
            this.PostalCode = PostalCode;
            this.NoClaimYears = NoClaimYears;
            LicenseAge = AgeByDate(ParseDate(DriverlicenseStartDate));
        }

        private static DateTime ParseDate(string dateStr)
        {
            var cultureInfo = new CultureInfo("nl-NL");
            return DateTime.Parse(dateStr, cultureInfo, DateTimeStyles.NoCurrentDateDefault);
        }

        private static int AgeByDate(DateTime date)
        {
            var today = DateTime.Today;
            var age = today.Year - date.Year;
            if (date.Date > today.AddYears(-age)) age--;

            return age;
        }

    }
}
