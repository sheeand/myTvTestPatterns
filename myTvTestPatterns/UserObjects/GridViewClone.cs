using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myTvTestPatterns.UserObjects
{
    public class GridViewClone
    {
        private string[] _sessionID = new string[20];
        private string[] _itemName = new string[20];
        private string[] _status = new string[20];
        private TimeSpan[] _remaining = new TimeSpan[20];

        // Constructor for "new" Items
        public GridViewClone()
        {
            for (int i = 0; i < 20; i++)
            {
                SessionID[i] = "";
                ItemName[i] = "";
                ItemName[i] = "";
                Remaining[i] = new TimeSpan();
            }
        }

        public string[] SessionID
        {
            get
            {
                return _sessionID;
            }
            set
            {
                _sessionID = value;
            }
        }
        public string[] ItemName
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
        public string[] Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public TimeSpan[] Remaining
        {
            get
            {
                return _remaining;
            }
            set
            {
                _remaining = value;
            }
        }
    }
}