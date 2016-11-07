using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TECHMOBI_BUSINESS_SERVICES_API.Models
{
    public class Paga
    {
        private string baseUrl = ConfigurationManager.AppSettings.Get("pagaRestAPIBaseUrl").ToString();

        public String GetBaseUrl()
        {
            return baseUrl;
        }
    }
    /// <summary>
    /// The Register Customer operation allows 3rd Parties to register customers on Paga. 
    /// New customers will be contacted to setup their authentication credentials.
    /// Service Method: /registerCustomer
    /// </summary>
    public class RegisterCustomer
    {
        /// <summary>
        /// A unique reference number provided, identifying the transaction. 
        /// This reference number will be preserved on the Paga platform to reconcile the operation 
        /// across systems and will be returned in the response. This value should be a valid alpha-numeric string
        /// Service Method:registerCustomer
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The identifying credential (principal) for the customer (eg. phone number, username). 
        /// This will be checked against the Paga system to determine if the account belongs to an existing user
        /// </summary>
        [Required]
        public string customerPrincipal { set; get; }

        /// <summary>
        /// The Customer’s credentials which is a valid phone number 
        /// </summary>
        [Required]
        public string customerCredentials { set; get; }


        /// <summary>
        /// The first name of the customer. A valid personal name with no number and special characters. 
        /// </summary>
        [Required]
        public string customerFirstName { set; get; }

        /// <summary>
        /// The last name of the customer. A valid personal name with no number and special characters. 
        /// </summary>
        [Required]
        public string customerLastName { set; get; }

        /// <summary>
        /// Birth date of the customer. A valid date in dd/mm/yyyy format
        /// </summary>
        [Required]
        public string customerDateOfBirth { set; get; }

        /// <summary>
        /// Additional optional account details provided by customer, to be specified in a format indicated by the 3rd party
        /// </summary>
        public string accountDetails { set; get; }


    }

    /// <summary>
    /// The Money Transfer operation enables an integrated 3rd party to utilize the Paga platform to transfer funds from a variety of sources to another party.
    /// The funds transfer may be executed from the accounts of the integrated 3rd party themselves, or on behalf of another customer with the appropriate authentication. 
    /// The source of funds may be the sender's Paga account or another source that the sender has pre-registered on the Paga platform.
    /// </summary>
    public class PagaMoneyTransfer
    {
        /// <summary>
        /// A unique reference number provided, identifying the transaction. 
        /// This reference number will be preserved on the Paga platform to reconcile the operation 
        /// across systems and will be returned in the response. This value should be a valid alpha-numeric string
        /// Service Method: /moneyTransfer
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The amount of money to transfer to the recipient
        /// </summary>
        [Required]
        public double amount { set; get; }

        /// <summary>
        /// The currency of the operation, if being executed in a foreign currency
        /// </summary>
        public double currency { set; get; }

        /// <summary>
        /// The account identifier for the recipient receiving the money transfer. 
        /// This account identifier may be a phone number, account nickname, or any other unique
        /// account identifier supported by the Paga platform. 
        /// If destinationBank is specified, this is the bank account number
        /// </summary>
        [Required]
        public string destinationAccount { set; get; }

        /// <summary>
        /// For money transfers to a bank account, this is the destination bank code
        /// </summary>
        public string destinationBank { set; get; }

        /// <summary>
        /// The authentication principal for the user sending money if the money is being sent on behalf of a user.
        /// If null, the money transfer will be processed from the 3rd parties own account.
        /// </summary>
        public string senderPrincipal { set; get; }

        /// <summary>
        /// The authentication credentials for the user sending money if the money is being sent on behalf of a user.
        /// </summary>
        public string senderCredentials { set; get; }

        /// <summary>
        /// If the cash is being sent on behalf of the third party itself (i.e. sender principal is null), 
        /// then this indicates whether confirmation messages for funds sent to non Paga customers will include 
        /// the withdrawal code in the message (true) or omit it (false). If false, then the withdrawal code will be returned 
        /// in the withdrawalCode response parameter. For funds sent to Paga customers,
        /// the funds are deposited directly into the customer's account so no withdrawal code is necessary. Defaults to true
        /// </summary>
        public Boolean sendWithdrawalCode { set; get; }

        /// <summary>
        /// The name of a source account for funds. If null, the source sender's Paga account will be used as the funding source.
        /// </summary>
        public string sourceOfFunds { set; get; }

        /// <summary>
        /// Additional transfer-specific reference information that may be required for transfer processing
        /// </summary>
        public string transferReference { set; get; }

        /// <summary>
        /// Whether to prevent sending an SMS to the recipient of the money transfer. 
        /// This can be used in cases where the business wishes to perform their own messaging. 
        /// Defaults to false, meaning that messages are NOT suppressed.
        /// </summary>
        public Boolean suppressRecipientMessage { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string locale { set; get; }


        /// <summary>
        /// If the cash is being sent on behalf of the third party itself (i.e. sender principal is null),
        /// then an alternative name-of-sender can be specified here for use in the message sent to the money transfer recipient. 
        /// This field is ignored if money transfer is sent on behalf of another user. This can be 16 characters in length.
        /// </summary>
        public string alternateSenderName { set; get; }

      
    }


    /// <summary>
    /// The Airtime Purchase operation enables an integrated 3rd party to utilize the 
    /// Paga platform to purchase airtime for any phone number on any of the major networks.
    /// The purchase can be funded by the integrated 3rd party themselves, or on behalf of another
    /// customer with the appropriate authentication. The source of funds may be the purchaser's 
    /// Paga account or another source that the sender has pre-registered on the Paga platform.
    /// Service Method:/airtimePurchase
    /// </summary>
    public class AirtimePurchase
    {
        /// <summary>
        /// A unique reference number provided, identifying the transaction. 
        /// This reference number will be preserved on the Paga platform to reconcile the operation 
        /// across systems and will be returned in the response. This value should be a valid alpha-numeric string
        /// Service Method: /moneyTransfer
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The amount of money to transfer to the recipient
        /// </summary>
        [Required]
        public double amount { set; get; }

        /// <summary>
        /// The currency of the operation, if being executed in a foreign currency
        /// </summary>
        public double currency { set; get; }

        /// <summary>
        /// The phone number for which airtime is being purchased. If null, and ­­­­Principal is specified, 
        /// then the airtime will be purchased for the phone number of the purchaserPrincipal. 
        /// Must be provided if the purchaserPrincipal is null
        /// </summary>
        public string destinationPhoneNumber { set; get; }

        /// <summary>
        /// The authentication principal for the user purchasing airtime if the airtime is being purchased on behalf of a user. 
        /// If null, the airtime will be processed from the 3rd parties own account.
        /// </summary>
        public string purchaserPrincipal { set; get; }

        /// <summary>
        /// The authentication credentials for the user purchasing the airtime if the airtime is being purchased on behalf of a user.
        /// </summary>
        public string purchaserCredentials { set; get; }

        /// <summary>
        /// The name of a source account for funds. If null, the source purchaser's Paga account will be used as the funding source.
        /// </summary>
        public string sourceOfFunds { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string locale { set; get; }


    }


    /// <summary>
    /// The Merchant Payment operation enables an integrated 3rd party to utilize the Paga platform to make payments to registered merchants.
    /// The purchase can be funded by the integrated 3rd party themselves, or on behalf of another customer with the appropriate authentication. 
    /// The source of funds may be the purchaser's Paga account or another source that the sender has pre-registered on the Paga platform.
    /// Service Method: merchantPayment
    /// </summary>
    public class MerchantPayment
    {
        /// <summary>
        /// A unique reference number provided by the business, identifying the transaction. This reference number will be preserved 
        /// on the Paga platform to reconcile the operation across systems and will be returned in the response
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The amount of the merchant payment
        /// </summary>
        [Required]
        public double Amount { set; get; }

        /// <summary>
        /// The currency of the operation, if being executed in a foreign currency
        /// </summary>
        public double Currency { set; get; }


        /// <summary>
        /// The account number identifying the merchant (eg. merchant Id, UUID)
        /// </summary>
        [Required]
        public string merchantAccount { set; get; }

        /// <summary>
        /// The account/reference number identifying the customer on the merchant's system
        /// </summary>
        [Required]
        public string merchantReferenceNumber { set; get; }

        /// <summary>
        /// The list of merchant service codes specifying which of the merchant's services are being paid for
        /// </summary>
        [Required]
        public string merchantService { set; get; }

        /// <summary>
        /// The authentication principal for the user paying the merchant if the payment is being made on behalf of a user. 
        /// If null, the payment will be processed from the 3rd parties own account
        /// </summary>
        public string purchaserPrincipal { set; get; }


        /// <summary>
        /// The authentication credentials for the user paying the merchant if the payment is being made on behalf of a user.
        /// </summary>
        public string purchaserCredentials { set; get; }


        /// <summary>
        /// The name of a source account for funds. If null, the source purchaser's Paga account will be used as the funding source.
        /// </summary>
        public string sourceOfFunds { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string locale { set; get; }


    }

    /// <summary>
    /// The Validate Deposit To Bank operation enables an integrated 3rd party to pre-validate a potential deposit to bank operation using similar
    /// parameters that would be provided for the actual deposit to bank operation. This will return a result indicating whether the actual deposit 
    /// to bank operation using the same parameters is likely to be successful or not, and if not, why not. This will also validate the bank account
    /// number for the bank provided and return the account holder name for that account as stored at the bank. This will also return any fees that 
    /// would be charged as part of the actual deposit to bank operation.
    /// Service Method: validateDepositToBank
    /// </summary>
    public class PreValidateDepositToBankAccount
    {
        /// <summary>
        /// A unique reference number provided by the business, identifying the transaction. This reference number will be preserved 
        /// on the Paga platform to reconcile the operation across systems and will be returned in the response
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The amount of the merchant payment
        /// </summary>
        [Required]
        public double Amount { set; get; }

        /// <summary>
        /// The currency of the operation, if being executed in a foreign currency
        /// </summary>
        public double Currency { set; get; }

        /// <summary>
        /// The Paga bank UUID identifying the bank to which the deposit will be made. In order to get the list of supported banks and bank UUIDs,
        /// execute the getBanks operation defined in this document. 
        /// Bank codes will not change though additional banks may be added to the list in the future.
        /// </summary>
        [Required]
        public string destinationBankUUID { set; get; }

        /// <summary>
        /// The ten digit NUBAN bank account number for the account to which the deposit will be made. 
        /// This number should be a valid account number for the destination 
        /// bank as specified by the destinationBankCode parameter above. 
        /// Executing operation will validate this number and if valid, 
        /// return the account holder name as stored at the bank for this account.
        /// </summary>
        [Required]
        public string destinationBankAccountNumber { set; get; }

        /// <summary>
        /// The mobile phone number of the recipient of the deposit to bank transaction. 
        /// Either one or both of this parameter and the recipientEmail parameter must be provided. 
        /// If this parameter is provided, this operation will validate that it is a valid phone number.
        /// </summary>
        public string recipientPhoneNumber { set; get; }

        /// <summary>
        /// Ignored if recipientPhoneNumber parameter is not provided. This describes the mobile operator that the 
        /// recipientPhoneNumber belongs to. If recipientPhoneNumber is provided, but this parameter is not, a default 
        /// mobile operator will selected based on the phone number pattern, but this may not be correct due to number portability 
        /// of mobile phone numbers and may result in delayed or failed delivery of any SMS messages to the recipient.
        /// </summary>
        public string recipientMobileOperatorCode { set; get; }


        /// <summary>
        /// The email address of the recipient of the deposit to bank transaction. Either one or both of this parameter
        /// and the recipientPhoneNumber parameter must be provided. 
        /// If this parameter is provided, this operation will validate that it is a valid email address format.
        /// </summary>
        public string recipientEmail { set; get; }

        /// <summary>
        /// The name of the recipient. This parameter is currently bot validated.
        /// </summary>
        public string recipientName { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string locale { set; get; }




    }


    /// <summary>
    /// The Deposit To Bank operation enables an integrated 3rd party to utilize the Paga platform to deposit funds to any bank account. 
    /// The funds will be deposited from the businesses Paga account to the bank and bank account specified in the operation parameters.
    /// Service Method: depositToBank
    /// </summary>
    public class DepositToBankAccount
    {
        /// <summary>
        /// A unique reference number provided by the business, identifying the transaction. This reference number will be preserved 
        /// on the Paga platform to reconcile the operation across systems and will be returned in the response
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The amount of money to deposit to the destination bank and bank account provided. Your Paga account must contain sufficient
        /// funds to cover this amount plus any fees.
        /// </summary>
        [Required]
        public double Amount { set; get; }

        /// <summary>
        /// The currency of the operation, if being executed in a foreign currency. The currency must be one of the currencies supported
        /// by the platform. For supported currencies, check with Paga integration operations support.
        /// </summary>
        public double Currency { set; get; }

        /// <summary>
        /// The Paga bank UUID identifying the bank to which the deposit will be made. In order to get the list of supported banks and bank UUIDs,
        /// execute the getBanks operation defined in this document. 
        /// Bank codes will not change though additional banks may be added to the list in the future.
        /// </summary>
        [Required]
        public string destinationBankUUID { set; get; }

        /// <summary>
        /// The ten digit NUBAN bank account number for the account to which the deposit will be made. 
        /// This number should be a valid account number for the destination 
        /// bank as specified by the destinationBankCode parameter above. 
        /// Executing operation will validate this number and if valid, 
        /// return the account holder name as stored at the bank for this account.
        /// </summary>
        [Required]
        public string destinationBankAccountNumber { set; get; }

        /// <summary>
        /// The mobile phone number of the recipient of the deposit to bank transaction. 
        /// Either one or both of this parameter and the recipientEmail parameter must be provided. 
        /// If this parameter is provided, this operation will validate that it is a valid phone number.
        /// </summary>
        public string recipientPhoneNumber { set; get; }

        /// <summary>
        /// Ignored if recipientPhoneNumber parameter is not provided. This describes the mobile operator that the 
        /// recipientPhoneNumber belongs to. If recipientPhoneNumber is provided, but this parameter is not, a default 
        /// mobile operator will selected based on the phone number pattern, but this may not be correct due to number portability 
        /// of mobile phone numbers and may result in delayed or failed delivery of any SMS messages to the recipient.
        /// </summary>
        public string recipientMobileOperatorCode { set; get; }


        /// <summary>
        /// The email address of the recipient of the deposit to bank transaction. Either one or both of this parameter
        /// and the recipientPhoneNumber parameter must be provided. 
        /// If this parameter is provided, this operation will validate that it is a valid email address format.
        /// </summary>
        public string recipientEmail { set; get; }

        /// <summary>
        /// The name of the recipient. This parameter is currently nsot validated.
        /// </summary>
        public string recipientName { set; get; }

        /// <summary>
        /// In notifications sent to the recipient, your business display name (if set), or business name (if display name not set) 
        /// is included. If you wish notifications to indicate the deposit to bank as coming from an alternate name, you may set the alternate name in this parameter. This parameter length is limited to 20 characters and will be truncated if longer.
        /// </summary>
        public string alternateSenderName { set; get; }

        /// <summary>
        /// If this field is set to true, no notification message (SMS or email) will be sent to the recipient. 
        /// IF omitted or set to false, an email or SMS will be sent to recipient as described above.
        /// </summary>
        public string suppressRecipientMessage { set; get; }

        /// <summary>
        /// Additional bank transfer remarks that you may wish to appear on your bank statement record for this transaction. 
        /// Remarks are limited to 30 characters and will be truncated if longer.
        /// </summary>
        public string Remarks { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string locale { set; get; }




    }

    /// <summary>
    /// The Withdrawal operation enables an integrated 3rd party to request a funds withdrawal for themselves or on behalf of 
    /// Paga customers with the appropriate authentication. IF requesting on behalf of a Paga customer, withdrawal details will be sent 
    /// to the customer. If the business is requesting for itself --
    /// Service Method: withdrawal
    /// </summary>
    public class Withdrawal
    {
        /// <summary>
        /// A unique reference number provided by the business, identifying the transaction. This reference number will be preserved 
        /// on the Paga platform to reconcile the operation across systems and will be returned in the response
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The amount of the withdrawal being made
        /// </summary>
        [Required]
        public double amount { set; get; }

        /// <summary>
        /// The currency of the operation, if being executed in a foreign currency
        /// </summary>
        public double currency { set; get; }

        /// <summary>
        /// The name of a source account pre-configured on Paga from which to withdraw funds. If null, 
        /// the Paga account is assumed to be the source.
        /// </summary>
        public string sourceOfFunds { set; get; }

        /// <summary>
        /// The authentication principal for the user from who's account withdrawal is made, if the inquiry is being 
        /// made on behalf of a user. If null, the withdrawal will be processed from the 3rd parties own account.
        /// </summary>
        public string accountPrincipal { set; get; }

        /// <summary>
        /// The authentication credentials from who's account withdrawal is made, if the withdrawal is being made on behalf of a user.
        /// </summary>
        public string accountCredentials { set; get; }

        /// <summary>
        /// If not null, the account identifier for the destination for the withdrawn funds.If null, then a withdrawal code is 
        /// issued for cashing out the withdrawal.If destinationBank is specified, this is the bank account number.
        /// </summary>
        public string destinationAccount { set; get; }

        /// <summary>
        /// For withdrawals to a bank account, this is the destination bank code
        /// </summary>
        public string destinationBank { set; get; }

        /// <summary>
        ///  Additional transfer-specific reference information that may be required for transfer processing
        /// </summary>
        public string transferReference { set; get; }

        /// <summary>
        /// The id of the agent at which the withdrawal will be processed.
        /// </summary>
        public string agentId { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string locale { set; get; }

    }

    /// <summary>
    /// The Account Balance operation enables an integrated 3rd party to utilize the Paga platform to check the balance of a
    /// Paga account or any other account type pre-registered on the Paga platform, which support balance inquiries. The account 
    /// balance check may be executed for the account(s) of the integrated 3rd party themselves, or on behalf of another customer 
    /// with the appropriate authentication.
    /// Service Method: accountBalance
    /// </summary>
    public class AccountBalance
    {
        /// <summary>
        /// A unique reference number provided by the business, identifying the transaction. 
        /// This reference number will be preserved on the Paga platform to reconcile the operation across systems and will be returned in the response
        /// </summary>
        [Required]
        public string referenceNumber { set; get; }

        /// <summary>
        /// The authentication principal for the user who's balance is being inquired, if the inquiry is being made on behalf of a user.
        /// If null, the balance inquiry will be processed from the 3rd parties own account.
        /// </summary>
        public string accountPrincipal { set; get; }

        /// <summary>
        /// The authentication credentials for the user who's balance is being inquired, if the inquiry is being made on behalf of a user.
        /// </summary>
        public string accountCredentials { set; get; }

        /// <summary>
        /// The name of a source account on which to check the balance. If null, the Paga account balance with be retrieved.
        /// </summary>
        public string sourceOfFunds { set; get; }

        /// <summary>
        /// The language/locale to be used in messaging. If provided, this must conform to the IETF language tag standard
        /// </summary>
        public string Locale { set; get; }

    }

    /// <summary>
    /// The Transaction History operation enables an integrated 3rd party to utilize the Paga platform to check the transaction history 
    /// of their Paga account between selected date ranges. The account balance check may be executed for the account(s) of the 
    /// integrated 3rd party themselves, or on behalf of another customer with the appropriate authentication. Transactions results 
    /// are limited to them most recent 10,000 results
    /// Service Method: transactionHistory
    /// </summary>
    public class TransactionHistory
    {

    }


    /// <summary>
    /// The Recent Transaction History operation enables an integrated 3rd party to utilize the Paga platform to check the last 5 transactions on their Paga account. The account balance check may be executed for the account(s) of the integrated 3rd party themselves or on behalf of another customer with the appropriate authentication.
    /// Service Method: recentTransactionHistory
    /// </summary>
    public class RecentTransactionHistory
    {

    }




}