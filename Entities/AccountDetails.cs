using System;

namespace Busysoft.Entities
{
    public class AccountDetails
    {
        public long FormNo { get; set; }
        public DateTime FormFillingDateTime { get; set; }
        public TimeSpan FormFillingTime { get; set; }
        public int CustTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Sex { get; set; }
        public DateTime DOB { get; set; }
        public int Cust_age { get; set; }
        public string Cust_std_code { get; set; }
        public string Cust_telephone { get; set; }
        public string Cust_mobile { get; set; }
        public string Cust_email_id { get; set; }
        public long Cust_state_code { get; set; }
        public string CustStatename { get; set; }
        public long Cust_city_code { get; set; }
        public string Cust_city_name { get; set; }
        public long Cust_branch_code { get; set; }
        public string Cust_branch_name { get; set; }
        public int Cust_account_type { get; set; }
        public long Cust_preferred_language { get; set; }

    }
}