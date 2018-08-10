using Nest;
using System;

//Please add references
namespace GateWay.Model
{
    /// <summary>
    /// t_business_airorders:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [ElasticsearchType(IdProperty = "Id", Name = "ESOrder")]
    public partial class ESOrder
    {
        public ESOrder()
        { }

        #region Model

        private long _id;
        private string _orderid = "";
        private string _orderno = "";
        private string _parentorderno = "";
        private string _orderst = "DZF";
        private string _paymentst = "WZF";
        private string _businesstype = "";
        private string _mercode = "";
        private string _entcode = "";
        private string _bookingman = "";
        private string _cardtype = "";
        private string _cardid = "";
        private string _tkdate="";
        private string _bldate="";
        private string _zfdate;
        private string _qxdate="";
        private DateTime _modifydate;
        private decimal _orderamount;
        private DateTime _creatdate;
        private string _remark = "";
        private string _hkstatus = "";
        private string _merblcode = "";
        private string _entblcode = "";
        private string _entname = "";
        private string _mername = "";
        private string _oldorderno = "";
        private int _paytype;
        private string _kbcode = "";
        private string _batchnumber = "";
        private string  _productflag;
        private string _jsdate;
        private string _errorcode = "";
        private string _errorinfo = "";
        private string _channelno = "";
        private string _orgcode = "";
        private string _merplatform = "";
        private string _soncode = "";
        private decimal? _counterfee;
        private int _validitynum;
        private string _callbackurl = "";
        private string _showurl = "";
        private string _secretkey = "";

        /// <summary>
        /// auto_increment
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        ///
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ParentOrderNo
        {
            set { _parentorderno = value; }
            get { return _parentorderno; }
        }

        /// <summary>
        ///
        /// </summary>
        public string OrderSt
        {
            set { _orderst = value; }
            get { return _orderst; }
        }

        /// <summary>
        ///
        /// </summary>       
        public string PayMentSt
        {
            set { _paymentst = value; }
            get { return _paymentst; }
        }

        /// <summary>
        ///
        /// </summary>
        public string BusinessType
        {
            set { _businesstype = value; }
            get { return _businesstype; }
        }

        /// <summary>
        ///
        /// </summary>
        public string MerCode
        {
            set { _mercode = value; }
            get { return _mercode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string EntCode
        {
            set { _entcode = value; }
            get { return _entcode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string BookingMan
        {
            set { _bookingman = value; }
            get { return _bookingman; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CardType
        {
            set { _cardtype = value; }
            get { return _cardtype; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string TKDate
        {
            set { _tkdate = value; }
            get { return _tkdate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string BLDate
        {
            set { _bldate = value; }
            get { return _bldate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ZFDate
        {
            set { _zfdate = value; }
            get { return _zfdate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string QXDate
        {
            set { _qxdate = value; }
            get { return _qxdate; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime ModifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }

        /// <summary>
        ///
        /// </summary>
        public decimal OrderAmount
        {
            set { _orderamount = value; }
            get { return _orderamount; }
        }

        /// <summary>
        ///
        /// </summary>
        
        public DateTime CreatDate
        {
            set { _creatdate = value; }
            get { return _creatdate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        ///
        /// </summary>
        public string HKStatus
        {
            set { _hkstatus = value; }
            get { return _hkstatus; }
        }

        /// <summary>
        ///
        /// </summary>
        public string MerBlCode
        {
            set { _merblcode = value; }
            get { return _merblcode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string EntBlCode
        {
            set { _entblcode = value; }
            get { return _entblcode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string EntName
        {
            set { _entname = value; }
            get { return _entname; }
        }

        /// <summary>
        ///
        /// </summary>
        public string MerName
        {
            set { _mername = value; }
            get { return _mername; }
        }

        /// <summary>
        ///
        /// </summary>
        [Obsolete("OldOrderNo已过时", true)]
        public string OldOrderNo
        {
            set { _oldorderno = value; }
            get { return _oldorderno; }
        }

        /// <summary>
        ///
        /// </summary>
        public int PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }

        /// <summary>
        ///
        /// </summary>
        public string KBCode
        {
            set { _kbcode = value; }
            get { return _kbcode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string BatchNumber
        {
            set { _batchnumber = value; }
            get { return _batchnumber; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ProductFlag
        {
            set { _productflag = value; }
            get { return _productflag; }
        }

        /// <summary>
        ///
        /// </summary>
        public string JSDate
        {
            set { _jsdate = value; }
            get { return _jsdate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ErrorCode
        {
            set { _errorcode = value; }
            get { return _errorcode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ErrorInfo
        {
            set { _errorinfo = value; }
            get { return _errorinfo; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ChannelNo
        {
            set { _channelno = value; }
            get { return _channelno; }
        }

        /// <summary>
        ///
        /// </summary>
        public string OrgCode
        {
            set { _orgcode = value; }
            get { return _orgcode; }
        }

        /// <summary>
        ///
        /// </summary>
        public string MerPlatform
        {
            set { _merplatform = value; }
            get { return _merplatform; }
        }

        /// <summary>
        ///
        /// </summary>
        public string soncode
        {
            set { _soncode = value; }
            get { return _soncode; }
        }

        /// <summary>
        ///
        /// </summary>
        public decimal? CounterFee
        {
            set { _counterfee = value; }
            get { return _counterfee; }
        }

        /// <summary>
        ///
        /// </summary>
        public int validityNum
        {
            set { _validitynum = value; }
            get { return _validitynum; }
        }

        /// <summary>
        ///
        /// </summary>
        public string callbackUrl
        {
            set { _callbackurl = value; }
            get { return _callbackurl; }
        }

        /// <summary>
        ///
        /// </summary>
        public string showUrl
        {
            set { _showurl = value; }
            get { return _showurl; }
        }

        /// <summary>
        ///
        /// </summary>
        public string secretKey
        {
            set { _secretkey = value; }
            get { return _secretkey; }
        }

        #endregion Model
    }
}