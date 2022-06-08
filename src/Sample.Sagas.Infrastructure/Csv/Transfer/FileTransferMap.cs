using CsvHelper.Configuration;

namespace Sample.Sagas.Infrastructure.Csv.Transfer
{
    public class FileTransferMap : ClassMap<FileTransferItem>
    {
        public FileTransferMap()
        {
            Map(m => m.StoreName).Name("Nome da Loja", "Name of the store");
            Map(m => m.Cnpj).Name("CNPJ", "Cnpj");
            Map(m => m.CompanyName).Name("Razão Social", "Company Name");
            Map(m => m.StateRegistration).Name("Inscrição Estadual", "State Registration");
            Map(m => m.CreditLimit).Name("Limite de Crédito", "Credit Limit");
            Map(m => m.Segment).Name("Segmento", "Segment");
            Map(m => m.Subsegment).Name("Subsegmento", "Subsegment");
            Map(m => m.Cnae).Name("CNAE");
            Map(m => m.EconomicActivit).Name("Atividade Economica", "Economic Activity");
            Map(m => m.CnaeDivision).Name("Divisão CNAE", "CNAE Division");
            Map(m => m.LegalNature).Name("Natureza Juridica", "Legal Nature");
            Map(m => m.CompanyType).Name("Tipo de Sociedade", "Company Type");
            Map(m => m.CsaCode).Name("Código CSA", "CSA Code");
            Map(m => m.Cpf).Name("CPF");
            Map(m => m.Name).Name("Nome", "Name");
            Map(m => m.LastName).Name("Sobrenome", "Last Name");
            Map(m => m.Email).Name("Endereço de e-mail", "Email");
            Map(m => m.PhoneNumber).Name("Telefone", "Phone Number");
            Map(m => m.PostalStreet).Name("Rua", "Postal Street");
            Map(m => m.PostalNumber).Name("Número", "Postal Number");
            Map(m => m.PostalComplement).Name("Complemento", "Postal Complement");
            Map(m => m.PostalNeighborhood).Name("Bairro", "Postal Neighborhood");
            Map(m => m.PostalPhoneNumber).Name("Telefone", "Postal Phone Number");
            Map(m => m.PostalCountry).Name("País", "Postal Country");
            Map(m => m.PostalState).Name("Estado", "Postal State");
            Map(m => m.PostalCity).Name("Cidade", "Postal City");
            Map(m => m.PostalZipCode).Name("CEP", "Postal ZIP CODE");
            Map(m => m.BillingStreet).Name("Rua Billing", "Billing Street");
            Map(m => m.BillingNumber).Name("Número Billing", "Billing Number");
            Map(m => m.BillingComplement).Name("Complemento Billing", "Billing Complement");
            Map(m => m.BillingNeighborhood).Name("Bairro Billing", "Billing Neighborhood");
            Map(m => m.BillingPhoneNumber).Name("Telefone Billing", "Billing Phone Number");
            Map(m => m.BillingCountry).Name("País Billing", "Billing Country");
            Map(m => m.BillingState).Name("Estado Billing", "Billing State");
            Map(m => m.BillingCity).Name("Cidade Billing", "Billing City");
            Map(m => m.BillingZipCode).Name("CEP Billing", "Billing ZIP CODE");
            Map(m => m.MicrosoftSubdomain).Name("Subdomínio Microsoft", "Microsoft Subdomain");
            Map(m => m.MicrosoftCustomerId).Name("ID do Cliente", "Microsoft Customer ID");
            Map(m => m.MicrosoftOfferName).Name("Nome da Oferta", "Microsoft Offer Name");
            Map(m => m.MicrosoftOfferId).Name("ID da Oferta (SKU)", "Microsoft Offer ID (SKU)");
            Map(m => m.MicrosoftSubscriptionId).Name("ID da Subscrição", "Microsoft Subscription ID");
            Map(m => m.LicenseQuantity).Name("Quantidade de licenças", "License Quantity");
            Map(m => m.LicensePrice).Name("Valor Unitáro da Licença", "License Price");
            Map(m => m.PaymentDetails).Name("Método de Pagamento", "Payment details");
            Map(m => m.PriceType).Name("Tipo de Preço", "Price Type");
            Map(m => m.Timezone).Name("Fuso horário", "Time Zone");
            Map(m => m.TotalRetailPrice).Name("Total Retail Price").Optional();
        }
    }
}
