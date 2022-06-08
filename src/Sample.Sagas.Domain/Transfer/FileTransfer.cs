namespace Sample.Sagas.Domain.Transfer
{
    public class FileTransfer
    {
        public Guid Id { get; private set; }
        public Guid FileId { get; private set; }
        public string StoreName { get; private set; }
        public string Cnpj { get; private set; }
        public string CompanyName { get; private set; }
        public string StateRegistration { get; private set; }
        public string CreditLimit { get; private set; }
        public string Segment { get; private set; }
        public string Subsegment { get; private set; }
        public string Cnae { get; private set; }
        public string EconomicActivit { get; private set; }
        public string CnaeDivision { get; private set; }
        public string LegalNature { get; private set; }
        public string CompanyType { get; private set; }
        public string CsaCode { get; private set; }
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PostalStreet { get; private set; }
        public string PostalNumber { get; private set; }
        public string PostalComplement { get; private set; }
        public string PostalNeighborhood { get; private set; }
        public string PostalPhoneNumber { get; private set; }
        public string PostalCountry { get; private set; }
        public string PostalState { get; private set; }
        public string PostalCity { get; private set; }
        public string PostalZipCode { get; private set; }
        public string PostalUf { get; private set; }
        public string BillingStreet { get; private set; }
        public string BillingNumber { get; private set; }
        public string BillingComplement { get; private set; }
        public string BillingNeighborhood { get; private set; }
        public string BillingPhoneNumber { get; private set; }
        public string BillingCountry { get; private set; }
        public string BillingState { get; private set; }
        public string BillingUf { get; private set; }
        public string BillingCity { get; private set; }
        public string BillingZipCode { get; private set; }
        public string MicrosoftSubdomain { get; private set; }
        public string MicrosoftCustomerId { get; private set; }
        public string MicrosoftOfferName { get; private set; }
        public string MicrosoftOfferId { get; private set; }
        public string MicrosoftSubscriptionId { get; private set; }
        public string LicenseQuantity { get; private set; }
        public string LicensePrice { get; private set; }
        public string PaymentDetails { get; private set; }
        public string PriceType { get; private set; }
        public string TotalRetailPrice { get; private set; }
        public string Timezone { get; private set; }

        public FileTransfer(Guid id, string storeName, string cnpj, string companyName, string stateRegistration, string creditLimit, string segment, string subsegment, string cnae, string economicActivit, string cnaeDivision, string legalNature, string companyType,
           string csaCode, string cpf, string name, string lastName, string email, string phoneNumber, string postalStreet, string postalNumber, string postalComplement, string postalNeighborhood, string postalPhoneNumber, string postalCountry, string postalState,
           string postalCity, string postalZipCode, string postalUf, string billingStreet, string billingNumber, string billingComplement, string billingNeighborhood, string billingPhoneNumber, string billingCountry, string billingState, string billingUf,
           string billingCity, string billingZipCode, string microsoftSubdomain, string microsoftCustomerId, string microsoftOfferName, string microsoftOfferId, string microsoftSubscriptionId, string licenseQuantity, string licensePrice, string paymentDetails,
           string priceType, string totalRetailPrice, string timezone)
        {
            Id = id;
            StoreName = storeName;
            Cnpj = cnpj;
            CompanyName = companyName;
            StateRegistration = stateRegistration;
            CreditLimit = creditLimit;
            Segment = segment;
            Subsegment = subsegment;
            Cnae = cnae;
            EconomicActivit = economicActivit;
            CnaeDivision = cnaeDivision;
            LegalNature = legalNature;
            CompanyType = companyType;
            CsaCode = csaCode;
            Cpf = cpf;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PostalStreet = postalStreet;
            PostalNumber = postalNumber;
            PostalComplement = postalComplement;
            PostalNeighborhood = postalNeighborhood;
            PostalPhoneNumber = postalPhoneNumber;
            PostalCountry = postalCountry;
            PostalState = postalState;
            PostalCity = postalCity;
            PostalZipCode = postalZipCode;
            PostalUf = postalUf;
            BillingStreet = billingStreet;
            BillingNumber = billingNumber;
            BillingComplement = billingComplement;
            BillingNeighborhood = billingNeighborhood;
            BillingPhoneNumber = billingPhoneNumber;
            BillingCountry = billingCountry;
            BillingState = billingState;
            BillingUf = billingUf;
            BillingCity = billingCity;
            BillingZipCode = billingZipCode;
            MicrosoftSubdomain = microsoftSubdomain;
            MicrosoftCustomerId = microsoftCustomerId;
            MicrosoftOfferName = microsoftOfferName;
            MicrosoftOfferId = microsoftOfferId;
            MicrosoftSubscriptionId = microsoftSubscriptionId;
            LicenseQuantity = licenseQuantity;
            LicensePrice = licensePrice;
            PaymentDetails = paymentDetails;
            PriceType = priceType;
            TotalRetailPrice = totalRetailPrice;
            Timezone = timezone;
        }

        public FileTransfer()
        {

        }

        public void SetFileId(Guid fileId) => FileId = fileId;
    }
}
