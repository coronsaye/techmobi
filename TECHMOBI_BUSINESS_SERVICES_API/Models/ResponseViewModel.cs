using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TECHMOBI_BUSINESS_SERVICES_API.Models
{
	/// <summary>
    /// Response parameter of PAGA RegisterCustomer Business Service API request.
    /// </summary>
	public class PagaRegCustomerResponse
	{
        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
		[Required]
        public string refernceNumber { get; set; }

        /// <summary>
        /// Describes the status of the request. Whether it succeeds or fails
        /// </summary>
        [Required]
        public string message { get; set; }

        /// <summary>
        /// If the request failed then PAGA will send the exception code else the value of the exception code will be 0(zero).
        /// </summary>
        [Required]
        public string responseCode { get; set; }

    }

    /// <summary>
    /// Response parameter of PAGA TransferMoney Business Service API request.
    /// </summary>
    public class PagaMoneyTransferResponse
    {

        /// <summary>
        /// A response code indicating the status(success/fail) of the operation on the Paga platform and if failure, indicating reason for failure
        /// </summary>
        [Required]
        public string responseCode { get; set; }

        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
		[Required]
        public string refernceNumber { get; set; }

        /// <summary>
        /// If funds are sent on behalf of the organization itself, and the sendWithdrawalCode request parameter is false, 
        /// this will include the withdrawal code for funds sent to a non Paga customer. For funds sent to Paga customers, 
        /// the funds are deposited directly into the customer's account so no withdrawal code is necessary.
        /// </summary>
        public string withdrawalCode { get; set; }

        /// <summary>
        /// If successful, the short transaction id which is provided to all parties involved in the transaction to easily identify the transaction
        /// </summary>
        public string transactionId { get; set; }


        /// <summary>
        /// If successful, the fee/tariff charged to the sender for the money transfer to this recipient
        /// </summary>
        public double Fee { set; get; }

        /// <summary>
        /// If successful, the registration status of the receiver of the funds. This will be either REGISTERED (for funds sent to 
        /// a registered Paga customer), or UNREGISTERED (for funds sent to a non-Paga customer.
        /// </summary>
        public string receiverRegistrationStatus { set; get; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the local (system base) currency to which value 
        /// is converted for processing
        /// </summary>
        public double currency { set; get; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the exchange rate which is used in converting 
        /// the funds to the local (system base) currency
        /// </summary>
        public double exchangeRate { set; get; }

        /// <summary>
        /// A human-readable message describing the transaction result (success or fail)
        /// </summary>
        public string Message { set; get; }
    }

	public class PagaAirtimePurchaseResponse
    {

        /// <summary>
        /// A response code indicating the status(success/fail) of the operation on the Paga platform and if failure, indicating reason for failure
        /// </summary>
        [Required]
        public string responseCode { get; set; }

        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
        [Required]
        public string refernceNumber { get; set; }

        /// <summary>
        /// If successful, the short transaction id which is provided to all parties involved in the transaction to easily identify the transaction
        /// </summary>
        public string transactionId { get; set; }


        /// <summary>
        /// If successful, the fee/tariff charged to the sender for the money transfer to this recipient
        /// </summary>
        public double Fee { set; get; }
        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the local (system base) currency to which value 
        /// is converted for processing
        /// </summary>
        public double Currency { set; get; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the exchange rate which is used in converting 
        /// the funds to the local (system base) currency
        /// </summary>
        public double exchangeRate { set; get; }

        /// <summary>
        /// A human-readable message describing the transaction result (success or fail)
        /// </summary>
        public string Message { set; get; }
    }



    public class PagaMerchantPaymentResponse
    {

        /// <summary>
        /// A response code indicating the status(success/fail) of the operation on the Paga platform and if failure, 
        /// indicating reason for failure
        /// </summary>
        [Required]
        public string responseCode { get; set; }

        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
        [Required]
        public string refernceNumber { get; set; }

        /// <summary>
        /// A code returned by the merchant in response to the transaction, typically intended for the payer 
        /// (eg. A confirmation code, token, voucher number, receipt/invoice number etc.)
        /// </summary>
        public string merchantTransactionReference { get; set; }

        /// <summary>
        /// If successful, the short transaction id which is provided to all parties involved in the transaction to easily identify the transaction
        /// </summary>
        public string transactionId { get; set; }

        /// <summary>
        /// If successful, the fee/tariff charged to the sender for the money transfer to this recipient
        /// </summary>
        public double Fee { set; get; }
        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the local (system base) currency to which value 
        /// is converted for processing
        /// </summary>
        public double Currency { set; get; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the exchange rate which is used in converting 
        /// the funds to the local (system base) currency
        /// </summary>
        public double exchangeRate { set; get; }

        /// <summary>
        /// A human-readable message describing the transaction result (success or fail)
        /// </summary>
        public string Message { set; get; }
    }

	public class PagaDepositResponse
    {
        /// <summary>
        /// A response code indicating the status(success/fail) of the operation on the Paga platform and if failure, 
        /// indicating reason for failure
        /// </summary>
        [Required]
        public string responseCode { get; set; }

        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
        [Required]
        public string refernceNumber { get; set; }


        /// <summary>
        /// If successful, the fee/tariff that would be charged from your Paga account for the deposit to bank to this recipient
        /// </summary>
        public double Fee { get; set; }

        /// <summary>
        /// If successful, this will return the name of the account holder for the destination bank and bank account provided 
        /// as it is reported by the destination bank.
        /// </summary>
        public string destinationAccountHolderNameAtBank { get; set; }

       
    }

    public class PagaBankDepositResponse
    {
        /// <summary>
        /// A response code indicating the status(success/fail) of the operation on the Paga platform and if failure, 
        /// indicating reason for failure
        /// </summary>
        [Required]
        public string responseCode { get; set; }

        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
        [Required]
        public string refernceNumber { get; set; }

        /// <summary>
        /// A human-readable message describing the transaction result(success or fail)
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// If successful, the short transaction id which is provided to all parties involved in the transaction to easily 
        /// identify the transaction
        /// </summary>
        public string transactionid { get; set; }

        /// <summary>
        /// If successful, the fee/tariff that would be charged from your Paga account for the deposit to bank to this recipient
        /// </summary>
        public double Fee { get; set; }

        /// <summary>
        /// If successful, this will return the name of the account holder for the destination bank and bank account provided 
        /// as it is reported by the destination bank.
        /// </summary>
        public string destinationAccountHolderNameAtBank { get; set; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the local (system base) currency to 
        /// which value is converted for processing
        /// </summary>
        public double Currency { get; set; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the exchange rate which is used in 
        /// converting the funds to the local (system base) currency
        /// </summary>
        public double exchangeRate { get; set; }
    }

    public class PagaWithdrawalResponse
    {
        /// <summary>
        /// A response code indicating the status(success/fail) of the operation on the Paga platform and if failure, 
        /// indicating reason for failure
        /// </summary>
        [Required]
        public string responseCode { get; set; }

        /// <summary>
        /// A unique reference number provided to the business
        /// </summary>
        [Required]
        public string refernceNumber { get; set; }

        /// <summary>
        /// If the withdrawal was made to cash(i.e.a destination account is not provided) and was for the business 
        /// itself(i.e.accountPrincipal is null), a withdrawal code will be returned in this parameter which the organization 
        /// can use to withdraw the funds
        /// </summary>
		public int withdrawalCode { get; set; }

        /// <summary>
        /// If the withdrawal process is successful, this will return the short transaction id which is provided to all parties 
        /// involved in the transaction to easily identify the transaction
        /// </summary>
        public string transactionid { get; set; }

        /// <summary>
        /// If the transaction request was specified in a foreign currency, this is the local (system base) currency to which 
        /// value is converted for processing
        /// </summary>
        public double currency { set; get; }

        /// <summary>
        /// .If the transaction request was specified in a foreign currency, this is the exchange rate which is used 
        /// in converting the funds to the local (system base) currency
        /// </summary>
        public double exchangeRate { set; get; }

        /// <summary>
        /// A human-readable message describing the transaction result(success or fail)
        /// </summary>
		public string message { set; get; }
    }
}