using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFramework.DbModel
{
    [Serializable()]
    public class Customers : ISerializable 
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string BusinessPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string CountryRegion { get; set; }
        public string WebPage { get; set; }
        public string Notes { get; set; }

        [XmlIgnore]
        public byte[] Attachments { get; set; }

        [XmlIgnore]
        public virtual ICollection<Orders> Orders { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // throw new NotImplementedException();
            info.AddValue("Id", Id);
            info.AddValue("Company", Company);
            info.AddValue("LastName", LastName);
            info.AddValue("FirstName", FirstName);
            info.AddValue("EmailAddress", EmailAddress);
            info.AddValue("JobTitle", JobTitle);
            info.AddValue("BusinessPhone", BusinessPhone);
            info.AddValue("HomePhone", HomePhone);
            info.AddValue("MobilePhone", MobilePhone);
            info.AddValue("FaxNumber", FaxNumber);
            info.AddValue("Address", Address);
            info.AddValue("City", City);
            info.AddValue("StateProvince", StateProvince);
            info.AddValue("ZipPostalCode", ZipPostalCode);
            info.AddValue("CountryRegion", CountryRegion);
            info.AddValue("WebPage", WebPage);
            info.AddValue("Notes", Notes);
        }
    }
}
