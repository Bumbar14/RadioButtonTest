using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadioButtonTest.Model
{
    public class Transaction
    {
        [PrimaryKey]
        public string FlowID { get; set; }
        public string FlowCloudKey{ get; set; }
        public DateTime FlowDate {get; set;}
        public string FlowPayee { get; set; }
        public int FlowCategory { get; set; }
        public decimal FlowAmount { get; set; }
        public string FlowType { get; set; }
        public string FlowAccount{ get; set; }
        public string FlowComment { get; set; }
        public int FlowDeleted { get; set; }
        public double TransactionLastTimeModified { get; set; }

    }
   
    public class Category
    {
        [PrimaryKey]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string FlowType { get; set; }
        public int TransactionFlowID { get; set;}
        public string CategoryCloudKey { get; set; }
    }

    public class FlowType
    {
        [PrimaryKey]
        public int FlowTypeID { get; set; }
        public string FlowTypeName { get; set; }
    }
    public class Account
    {
        [PrimaryKey]
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
    }

    public class UserProfile
    {
        [PrimaryKey]
        public string UserID { get; set; }
        public string UserName { get; set; }
    }
   
}
