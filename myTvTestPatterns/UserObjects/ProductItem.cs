using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTvTestPatterns.UserObjects
{
    public class ProductItem
    {
        private string _marker;
        private DateTime _transactionDate;
        private DateTime _expirationDate;
        private string _sessionID;
        private string _emailAddress;
        private string _password;
        private string _itemNumber;
        private string _itemName;
        private string _price;
        private string _updateOption;
        private string _clientIP;
        private string _deal;
        private string _securityQuestion;
        private string _answer;
        private string _browser;
        private DateTime _originalTransactionDate;
        private string _originalSessionID;

        // Constructor for "new" objects
        public ProductItem()
        {
            Marker = "";
            TransactionDate = new DateTime();
            ExpirationDate = new DateTime();
            SessionID = "";
            EmailAddress = "";
            Password = "";
            ItemNumber = "";
            ItemName = "";
            Price = "";
            UpdateOption = "";
            ClientIP = "";
            Deal = "";
            SecurityQuestion = "";
            Answer = "";
            Browser = "";
            OriginalTransactionDate = new DateTime();
            OriginalSessionID = "";
        }

        public string Marker
        {
            // This is a utility variable used for indicating where the object was previously, 
            // or what happened to it previously
            get
            {
                return _marker;
            }
            set
            {
                _marker = value;
            }
        }
        public DateTime TransactionDate
        {
            // Date of the current visit
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = value;
            }
        }
        public DateTime ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                _expirationDate = value;
            }
        }
        public string SessionID
        {
            // Current Session ID
            get
            {
                return _sessionID;
            }
            set
            {
                _sessionID = value;
            }
        }
        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string ItemNumber
        {
            get
            {
                return _itemNumber;
            }
            set
            {
                _itemNumber = value;
            }
        }
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public string UpdateOption
        {
            get
            {
                return _updateOption;
            }
            set
            {
                _updateOption = value;
            }
        }
        public string ClientIP
        {
            get
            {
                return _clientIP;
            }
            set
            {
                _clientIP = value;
            }
        }
        public string Deal
        {
            get
            {
                return _deal;
            }
            set
            {
                _deal = value;
            }
        }
        public string SecurityQuestion
        {
            get
            {
                return _securityQuestion;
            }
            set
            {
                _securityQuestion = value;
            }
        }
        public string Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                _answer = value;
            }
        }
        public string Browser
        {
            get
            {
                return _browser;
            }
            set
            {
                _browser = value;
            }
        }
        public DateTime OriginalTransactionDate
        {
            get
            {
                return _originalTransactionDate;
            }
            set
            {
                _originalTransactionDate = value;
            }
        }
        public string OriginalSessionID
        {
            get
            {
                return _originalSessionID;
            }
            set
            {
                _originalSessionID = value;
            }
        }
    }
}