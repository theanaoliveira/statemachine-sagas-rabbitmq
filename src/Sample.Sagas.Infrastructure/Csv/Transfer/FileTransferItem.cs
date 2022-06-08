namespace Sample.Sagas.Infrastructure.Csv.Transfer
{
    public class FileTransferItem
    {
        public Guid Id { get => Guid.NewGuid(); }
        public string StoreName { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string StateRegistration { get; set; }
        public string CreditLimit { get; set; }
        public string Segment { get; set; }
        public string Subsegment { get; set; }
        public string Cnae { get; set; }
        public string EconomicActivit { get; set; }
        public string CnaeDivision { get; set; }
        public string LegalNature { get; set; }
        public string CompanyType { get; set; }
        public string CsaCode { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalStreet { get; set; }
        public string PostalNumber { get; set; }
        public string PostalComplement { get; set; }
        public string PostalNeighborhood { get; set; }
        public string PostalPhoneNumber { get; set; }
        public string PostalCountry { get; set; }
        public string PostalState { get; set; }
        public string PostalCity { get; set; }
        public string PostalZipCode { get; set; }
        public string BillingStreet { get; set; }
        public string BillingNumber { get; set; }
        public string BillingComplement { get; set; }
        public string BillingNeighborhood { get; set; }
        public string BillingPhoneNumber { get; set; }
        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string MicrosoftSubdomain { get; set; }
        public string MicrosoftCustomerId { get; set; }
        public string MicrosoftOfferName { get; set; }
        public string MicrosoftOfferId { get; set; }
        public string MicrosoftSubscriptionId { get; set; }
        public string LicenseQuantity { get; set; }
        public string LicensePrice { get; set; }
        public string PaymentDetails { get; set; }
        public string PriceType { get; set; }
        public string TotalRetailPrice { get; set; }
        public string Timezone { get; set; }
    }
}
