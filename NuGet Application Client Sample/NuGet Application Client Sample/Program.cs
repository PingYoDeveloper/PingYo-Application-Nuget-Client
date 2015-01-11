using System;
using Witti.PingTree.AffiliateAdaptor;
using Witti.PingTree.AffiliateAdaptor.Models;

namespace NuGet_Application_Client_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var isTestApplication = true;
            var submissionUrl = new Uri("https://leads.pingyo.com");

            var client = new PingTreeClient(submissionUrl, isTestApplication);
            client.OnStatusChanged += client_OnStatusChanged;

            var affiliateId = "TEST";
            var request = CreateRequest();
            var timeout = 12000;

            var response = client.SubmitApplication(affiliateId, request, timeout);

            Console.WriteLine("CorrelationID: " + response.CorrelationId);
            Console.WriteLine("Final Status: " + response.Status);
            Console.WriteLine("Estimated Commission: " + response.EstimatedCommission);
            Console.WriteLine("Redirect URL: " + response.RedirectionUrl);

            Console.ReadLine();
        }

        static void client_OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            Console.WriteLine("Percentage Complete: " + e.Status.PercentageComplete);
        }

        private static PingTreeApplicationRequest CreateRequest()
        {
            var request = new PingTreeApplicationRequest
            {
                Application = CreateApplication(),
                Campaign = "My Marketing Campaign",
                SourceDetails = CreateSourceDetails(),
                SubAffiliate = "My SUB ID"
            };

            return request;
        }

        private static ProxyApplication CreateApplication()
        {
            var application = new ProxyApplication
            {
                AddressCity = "Test",
                AddressCounty = "Test",
                AddressMoveIn = new DateTime(2014, 1, 1),
                AddressPostcode = "LA123A",
                AddressState = null,
                AddressStreet1 = "Test",
                BankAccountNumber = "12345678",
                BankCardType = BankAccountCardType.VisaDebit,
                BankInstitutionId = "123",
                BankName = "Test",
                BankRoutingNumber = "12-34-56",
                CombinedMonthlyHouseholdIncome = 2000,
                ConsentToCreditSearch = true,
                ConsentToMarketingEmails = true,
                DateOfBirth = new DateTime(1980, 1, 1),
                DriversLicenseNumber = "123-45-6789",
                DriversLicenseState = "OK",
                Email = "test@test-application.com",
                EmployerIndustry = EmployerIndustry.AdministrationSecretarial,
                EmployerName = "Test",
                EmploymentStarted = new DateTime(2014, 1, 1),
                ExpensesConfirmed = true,
                FirstName = "Test",
                FollowingPayDate = DateTime.UtcNow.AddDays(35),
                Food = 100,
                HomePhoneNumber = "1234567890",
                HouseName = "Test",
                HouseNumber = "103-B",
                IncomePaymentType = IncomePaymentType.RegionalDirectDeposit,
                IncomeSource = IncomeSource.EmployedFullTime,
                JobTitle = "Test",
                LastName = "Test",
                LoanAmount = 400,
                LoanProceedUse = LoanProceedUse.DebtConsolidation,
                MaritalStatus = MaritalStatus.Single,
                MilitaryService = MilitaryService.ActiveDuty,
                MobilePhoneNumber = "07123456789",
                MonthlyCreditCommitments = 200,
                MonthlyMortgageRent = 500,
                NationalIdentityNumber = "123-46-7890",
                NationalIdentityNumberType = NationalIdentityType.NationalInsurance,
                NextPayDate = DateTime.UtcNow.AddDays(5),
                NumberOfDependents = 0,
                OtherExpenses = 0,
                PayAmount = 2000,
                PayFrequency = PayFrequency.Fortnightly,
                ResidentialStatus = ResidentialStatus.HomeOwner,
                Term = 1,
                Title = ApplicantTitle.Mr,
                Transport = 100,
                Utilities = 100,
                WorkPhoneNumber = "01123456789"
            };

            return application;
        }

        private static SourceDetails CreateSourceDetails()
        {
            var details = new SourceDetails
            {
                Address = "123.456.789.345",
                ClientUserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)",
                CreationUrl = "http://MySiteUrl.org",
                ReferringUrl = "http://MySiteUrl.org"
            };

            return details;
        }
    }
}
