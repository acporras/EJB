using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML;
//using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalXML
{
    [Serializable]
    public class UBLExtensions
    {
        public UBLExtension Extension1 { get; set; }
        public UBLExtension Extension2 { get; set; }

        public UBLExtensions()
        {
            Extension1 = new UBLExtension();
            Extension2 = new UBLExtension();
        }
    }

    public class UBLExtension
    {
        public ExtensionContent ExtensionContent { get; set; }

        public UBLExtension()
        {
            ExtensionContent = new ExtensionContent();
        }
    }
    public class ExtensionContent
    {
        public AdditionalInformation AdditionalInformation { get; set; }

        public ExtensionContent()
        {
            AdditionalInformation = new AdditionalInformation();
        }
    }
  

    public class SunatTransaction
    {
        public string Id { get; set; }
    }
    //Considerar informacion de SUNAT - NO necesario por el momento
    public class SunatEmbededDespatchAdvice
    {
       public PostalAddress DeliveryAddress { get; set; }
        public PostalAddress OriginAddress { get; set; }
        public AccountingSupplierParty SunatCarrierParty { get; set; }
        public AgentParty DriverParty { get; set; }
        public SunatRoadTransport SunatRoadTransport { get; set; }
        public string TransportModeCode { get; set; }
        public InvoicedQuantity GrossWeightMeasure { get; set; }

        public SunatEmbededDespatchAdvice()
        {
           DeliveryAddress = new PostalAddress();
            OriginAddress = new PostalAddress();
            SunatCarrierParty = new AccountingSupplierParty();
            DriverParty = new AgentParty();
            SunatRoadTransport = new SunatRoadTransport();
            GrossWeightMeasure = new InvoicedQuantity();
        }
        //DATOS USADOS PARA LA FIRMA DEL DOCUMENTO
        
    }
    public class InvoicedQuantity
    {
        public string unitCode { get; set; }
        public decimal Value { get; set; }
    }
    public class SunatRoadTransport
    {
        public string LicensePlateId { get; set; }
        public string TransportAuthorizationCode { get; set; }
        public string BrandName { get; set; }
    }
    public class AgentParty
    {
        public PartyIdentification PartyIdentification { get; set; }
        public PartyName PartyName { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }

        public AgentParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyName = new PartyName();
            PostalAddress = new PostalAddress();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
    public class AccountingCustomerParty
    {
        public string CustomerAssignedAccountID { get; set; }
        public string AdditionalAccountID { get; set; }

    }

    public class Status
    {
        public string ConditionCode { get; set; }
    }

    public class AccountingSupplierParty
    {
        public string CustomerAssignedAccountID { get; set; }
        public string AdditionalAccountID { get; set; }
        public Party Party { get; set; }

    }

    public class Party
    {
        public PartyName PartyName { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public PartyLegalEntity PartyLegalEntity { get; set; }


        public Party()
        {
            PartyName = new PartyName();
            PostalAddress = new PostalAddress();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
    public class PartyName
    {
        public string Name { get; set; }
    }
    public class PostalAddress
    {
        public string ID { get; set; }
        public string StreetName { get; set; }
        public string CitySubdivisionName { get; set; }
        public string CityName { get; set; }
        public string CountrySubentity { get; set; }
        public string District { get; set; }
        public Country Country { get; set; }

        public PostalAddress()
        {
            Country = new Country();
        }
    }
    public class PartyLegalEntity
    {
        public string RegistrationName { get; set; }
    }
    public class Country
    {
        public string IdentificationCode { get; set; }
    }

    //DATOS DEL CONTRIBUYENTE
    public class Contribuyente
    {
        public int CodigoEmpresa { get; set; }
        public string NroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreLegal { get; set; }
        public string NombreComercial { get; set; }
        public string Ubigeo { get; set; }
        public string Direccion { get; set; }
        public string Urbanizacion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string UsuarioSol { get; set; }
        public string ClaveSol { get; set; }


    }
    public class SignatureCac
    {
        public string ID { get; set; }
        public SignatoryParty SignatoryParty { get; set; }
        public DigitalSignatureAttachment DigitalSignatureAttachment { get; set; }

        public SignatureCac()
        {
            SignatoryParty = new SignatoryParty();
            DigitalSignatureAttachment = new DigitalSignatureAttachment();
        }
    }
    public class SignatoryParty
    {
        public PartyIdentification PartyIdentification { get; set; }
        public PartyName PartyName { get; set; }


        public SignatoryParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyName = new PartyName();
        }
    }
    public class DigitalSignatureAttachment
    {
        public ExternalReference ExternalReference { get; set; }

        public DigitalSignatureAttachment()
        {
            ExternalReference = new ExternalReference();
        }
    }
    public class ExternalReference
    {
        public string URI { get; set; }
    }
    public class PartyIdentification
    {
        public PartyIdentificationID ID { get; set; }

        public PartyIdentification()
        {
            ID = new PartyIdentificationID();
        }
    }
    public class PartyIdentificationID
    {
        public string schemeID { get; set; }
        public string value { get; set; }
    }
    //Referencias expedición de documentos - NI IDEA PARA QUE SIRVE x 3
    public class InvoiceDocumentReference : IEquatable<InvoiceDocumentReference>
    {
        public string ID { get; set; }
        public string DocumentTypeCode { get; set; }

        public InvoiceDocumentReference()
        {
            ID = string.Empty;
        }
        public bool Equals(InvoiceDocumentReference other)
        {
            if (string.IsNullOrEmpty(ID))
                return false;
            return ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(ID))
                return base.GetHashCode();

            return ID.GetHashCode();
        }
    }
    public class LegalMonetaryTotal
    {
        public PayableAmount PayableAmount { get; set; }
        public PayableAmount AllowanceTotalAmount { get; set; }
        public PayableAmount ChargeTotalAmount { get; set; }
        public PayableAmount PrepaidAmount { get; set; }

        public LegalMonetaryTotal()
        {
            PayableAmount = new PayableAmount();
            AllowanceTotalAmount = new PayableAmount();
            ChargeTotalAmount = new PayableAmount();
            PrepaidAmount = new PayableAmount();
        }
    }
    public class TaxTotal
    {
        public PayableAmount TaxableAmount { get; set; }
        public PayableAmount TaxAmount { get; set; }
        public TaxSubtotal TaxSubtotal { get; set; }

        public TaxTotal()
        {
            TaxableAmount = new PayableAmount();
            TaxAmount = new PayableAmount();
            TaxSubtotal = new TaxSubtotal();
        }
    }
    public class TaxSubtotal
    {
        public PayableAmount TaxAmount { get; set; }
        public TaxCategory TaxCategory { get; set; }
        public decimal Percent { get; set; }

        public TaxSubtotal()
        {
            TaxAmount = new PayableAmount();
            TaxCategory = new TaxCategory();
        }
    }
    public class TaxCategory
    {
        public string TaxExemptionReasonCode { get; set; }
        public string TierRange { get; set; }
        public TaxScheme TaxScheme { get; set; }
        public string ID { get; set; }

        public TaxCategory()
        {
            TaxScheme = new TaxScheme();
        }
    }
    public class TaxScheme
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string TaxTypeCode { get; set; }
    }
    //DATOS DE LA GUIA
    public class DatosGuia
    {
        public Contribuyente DireccionDestino { get; set; }
        public Contribuyente DireccionOrigen { get; set; }
        public string RucTransportista { get; set; }
        public string TipoDocTransportista { get; set; }
        public string NombreTransportista { get; set; }
        public string NroLicenciaConducir { get; set; }
        public string PlacaVehiculo { get; set; }
        public string CodigoAutorizacion { get; set; }
        public string MarcaVehiculo { get; set; }
        public string ModoTransporte { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PesoBruto { get; set; }

        public DatosGuia()
        {
            DireccionDestino = new Contribuyente();
            DireccionOrigen = new Contribuyente();
        }

    }
    public class DatoAdicional
    {
        public string Codigo { get; set; }
        public string Contenido { get; set; }
    }
    public class DocumentoRelacionado
    {
        public string NroDocumento { get; set; }
        public string TipoDocumento { get; set; }
    }
    public class DetalleDocumento
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Suma { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal SubTotalVenta { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string TipoPrecio { get; set; }
        public decimal Impuesto { get; set; }
        public string TipoImpuesto { get; set; }
        public decimal ImpuestoSelectivo { get; set; }
        public decimal OtroImpuesto { get; set; }
        public string Descripcion { get; set; }
        public string CodigoItem { get; set; }
        public decimal PrecioReferencial { get; set; }
        public string UnidadCliente { get; set; }
        public DetalleDocumento()
        {
            //Id = 1;
            UnidadMedida = "NIU";//Unidad por defecto - Ver tabla de unidades
            TipoPrecio = "01"; //Tipo de Precio de Venta Unitario - Ver tabla
            TipoImpuesto = "10"; //Ver tabla tipo de impuesto
        }
    }
    public class BillingPayment
    {
        public PartyIdentificationID Id { get; set; }
        public PayableAmount PaidAmount { get; set; }
        public string InstructionId { get; set; }

        public BillingPayment()
        {
            PaidAmount = new PayableAmount();
            Id = new PartyIdentificationID();
        }
    }
    public class Discrepancia
    {
        public string NroReferencia { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
    public class InvoiceLine
    {
        public int ID { get; set; }
        public InvoicedQuantity CreditedQuantity { get; set; }
        public InvoicedQuantity InvoicedQuantity { get; set; }
        public InvoicedQuantity DebitedQuantity { get; set; }
        public PayableAmount LineExtensionAmount { get; set; }
        public PricingReference PricingReference { get; set; }
        public AllowanceCharge AllowanceCharge { get; set; }
        public List<TaxTotal> TaxTotals { get; set; }
        public Item Item { get; set; }
        public Price Price { get; set; }

        public InvoiceLine()
        {
            CreditedQuantity = new InvoicedQuantity();
            InvoicedQuantity = new InvoicedQuantity();
            DebitedQuantity = new InvoicedQuantity();
            LineExtensionAmount = new PayableAmount();
            PricingReference = new PricingReference();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
            Item = new Item();
            Price = new Price();
        }
    }
    public class PricingReference
    {
        public List<AlternativeConditionPrice> AlternativeConditionPrices { get; set; }

        public PricingReference()
        {
            AlternativeConditionPrices = new List<AlternativeConditionPrice>();
        }
    }
    public class AllowanceCharge
    {
        public bool ChargeIndicator { get; set; }
        public PayableAmount Amount { get; set; }

        public AllowanceCharge()
        {
            Amount = new PayableAmount();
        }
    }
    public class Item
    {
        public string Description { get; set; }
        public SellersItemIdentification SellersItemIdentification { get; set; }

        public Item()
        {
            SellersItemIdentification = new SellersItemIdentification();
        }
    }  
    public class SellersItemIdentification
    {
        public string ID { get; set; }
    }
    public class Price
    {
        public PayableAmount PriceAmount { get; set; }

        public Price()
        {
            PriceAmount = new PayableAmount();
        }
    }
    public class AlternativeConditionPrice
    {
        public PayableAmount PriceAmount { get; set; }
        public string PriceTypeCode { get; set; }

        public AlternativeConditionPrice()
        {
            PriceAmount = new PayableAmount();
        }
    }


    /*NOTA DE CREDITO*/
    public class DiscrepancyResponse : IEquatable<DiscrepancyResponse>
    {
        public string ReferenceID { get; set; }
        public string ResponseCode { get; set; }
        public string Description { get; set; }

        public DiscrepancyResponse()
        {
            ReferenceID = string.Empty;
        }
        public bool Equals(DiscrepancyResponse other)
        {
            if (string.IsNullOrEmpty(ReferenceID))
                return false;

            return ReferenceID.Equals(other.ReferenceID);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(ReferenceID))
                return base.GetHashCode();

            return ReferenceID.GetHashCode();
        }
    }

    public class BillingReference : IEquatable<BillingReference>
    {
        public InvoiceDocumentReference InvoiceDocumentReference { get; set; }

        public BillingReference()
        {
            InvoiceDocumentReference = new InvoiceDocumentReference();
        }

        public bool Equals(BillingReference other)
        {
            return InvoiceDocumentReference.Equals(other.InvoiceDocumentReference);
        }

        public override int GetHashCode()
        {
            return InvoiceDocumentReference.GetHashCode();
        }
    }

    /*CARGA DATOS PARA EL FORMULARIO*/
   /* [Table("DireccionesSunat")]
    public class DireccionSunat : TipoValorBase
    {
        [Required]
        [StringLength(50)]
        public new string Codigo { get; set; }
    }*/
    public class TipoValorBase : EntidadBase
    {
        [Required]
        [StringLength(5)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }
    }
    public abstract class EntidadBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    [Table("TipoDocumentos")]
    public class TipoDocumento : TipoValorBase
    {
    }
    public class TipoDocumentoContribuyente : TipoValorBase
    {
    }

    [Table("TipoOperaciones")]
    public class TipoOperacion : TipoValorBase
    {

    }
    [Table("TipoImpuestos")]
    public class TipoImpuesto : TipoValorBase
    {

    }
    public class TipoPrecio : TipoValorBase
    {
    }
    [Table("TipoDocumentoRelacionados")]
    public class TipoDocumentoRelacionado : TipoValorBase
    {
    }
    [Table("TipoDocumentoAnticipos")]
    public class TipoDocumentoAnticipo : TipoValorBase
    {
    }
    public class TipoDiscrepancia : TipoValorBase
    {
        [Required]
        [StringLength(2)]
        public string DocumentoAplicado { get; set; }
    }
    [Table("TipoDatoAdicionales")]
    public class TipoDatoAdicional : TipoValorBase
    {
    }
    public class Moneda : TipoValorBase
    {
    }
    public class ModalidadTransporte : TipoValorBase
    {

    }

    public class ComunicacionBaja : DocumentoResumen
    {
        public List<DocumentoBaja> Bajas { get; set; }
       /*public ComunicacionBaja(){
            Bajas = new List<DocumentoBaja>();
       }*/
    }
    public abstract class DocumentoResumen
    {
        public Contribuyente Emisor { get; set; }
        public string IdDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string FechaReferencia { get; set; }
    }
    public class DocumentoBaja : DocumentoResumenDetalle
    {
        public string Correlativo { get; set; }
        public string MotivoBaja { get; set; }
    }
    public abstract class DocumentoResumenDetalle
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
    }
    public class ResumenDiario : DocumentoResumen
    {
        public List<GrupoResumen> Resumenes { get; set; }
    }
    public class GrupoResumen : DocumentoResumenDetalle
    {
        public string NumeroDocumento { get; set; }
        public int CorrelativoInicio { get; set; }
        public int CorrelativoFin { get; set; }
        public string Moneda { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal TotalIsc { get; set; }
        public decimal TotalOtrosImpuestos { get; set; }
        public decimal Gravadas { get; set; }
        public decimal Exoneradas { get; set; }
        public decimal Inafectas { get; set; }
        public decimal Exportacion { get; set; }
        public decimal Gratuitas { get; set; }
        public string DocumentoCliente { get; set; }
        public string TipoDocumentoCliente { get; set; }
        public string Operacion { get; set; }
    }
    public class ConsultaTicketRequest : EnvioDocumentoComun
    {
        public string NroTicket { get; set; }
    }


    /*DOCUMENTO RETENCION*/
    public class DocumentoRetencion
    {
        public Contribuyente Emisor { get; set; }
        public Contribuyente Receptor { get; set; }     
        public string IdDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }
        public string RegimenRetencion { get; set; }
        public decimal TasaRetencion { get; set; }
        public string Observaciones { get; set; }
        public decimal ImporteTotalRetenido { get; set; }
        public decimal ImporteTotalPagado { get; set; }
       
        public List<ItemRetencion> DocumentosRelacionados { get; set; }


        public DocumentoRetencion() {
            Emisor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.

            };

            Receptor = new Contribuyente
            {
                TipoDocumento = "6" // RUC.   //REG. UNICO DE CONTRIBUYENTES - VER CATALAGO Nº 6 TABLA 2
            };
            DocumentosRelacionados = new List<ItemRetencion>() { };
        }
    }
    public class ItemRetencion : DocumentoRelacionado
    {
        public string FechaEmision { get; set; }
        public decimal ImporteTotal { get; set; }
        public string MonedaDocumentoRelacionado { get; set; }

        public string FechaPago { get; set; }
        public int NumeroPago { get; set; }
        public decimal ImporteSinRetencion { get; set; }

        public decimal ImporteRetenido { get; set; }
        public string FechaRetencion { get; set; }
        public decimal ImporteTotalNeto { get; set; }

        public decimal TipoCambio { get; set; }
        public string FechaTipoCambio { get; set; }
    }
}