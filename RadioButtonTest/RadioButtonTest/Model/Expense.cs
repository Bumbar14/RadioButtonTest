using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadioButtonTest.Model
{
   
    public class Category
    {
        [PrimaryKey]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string FlowType { get; set; }
        public int TransactionFlowID { get; set;}
        public string CategoryCloudKey { get; set; }
    }
   
}
