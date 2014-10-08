using System;
using System.Xml.Serialization;

namespace XmlModifier
{
    [Serializable,XmlRoot(ElementName ="Config")]
    public class MyConfig
    {
        private string _ip = "115.236.0.69:8680";
        private string _com = "8";
        private string _roleCode = "";
        private string _roleName = "";
        private string _userID = "";
        private string _userName = "";
        private string _pwd = "";
        private string _displayName = "";

        [XmlElement(ElementName ="URL")]
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        [XmlElement(ElementName = "PrintPort")]
        public string COM
        {
            get { return _com; }
            set { _com = value; }
        }
        [XmlIgnore]
        public string RoleName
        {
            get { 
                return _roleName;
            }
            set { _roleName =  value; }
        }
        [XmlIgnore]
        public string RoleCode
        {
            get
            {
                return _roleCode;
            }
            set { _roleCode = value; }
        }
        [XmlIgnore]
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        [XmlIgnore]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [XmlIgnore]
        public string Password
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        [XmlIgnore]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
}
