using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBGLibrary.Models
{
    internal class Transactions
    {
         public int TransactionID { get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public void CalculateOverDueFees(DateTime dueDate)
        {
            if(ReturnDate.Value > dueDate)
            {
                Member.OverDueFees += 10;
            }
            
        }

    }
}
