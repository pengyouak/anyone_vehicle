using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;
using System.Drawing;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VehicleEntryEx
{
    public partial class formKeeper : Form
    {
        WebReference.EnterService _service;
        DES _des = new DES();
        string _printModel = "";
        string _brand = "";
        string _origin = "";
        BluetoothPrinter btp = new BluetoothPrinter();

        public formKeeper()
        {
            InitializeComponent();
            lblOwner.Text = string.Empty;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region 输入校验
            if(txtShopId.Text==string.Empty)
            {
                MessageBox.Show("请输入门店号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (lblOwner.Text.Trim() == string.Empty)
            {
                MessageBox.Show("没有找到该门店号的经营户名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txtTrafficId.Text == string.Empty)
            {
                MessageBox.Show("请输入车船号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if(cboType.SelectedItem==null)
            {
                MessageBox.Show("请选择品种!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboSub.SelectedItem == null)
            {
                MessageBox.Show("请选择品种小类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboDetail.Visible == true && cboDetail.SelectedItem == null)
            {
                MessageBox.Show("请选择品种明细!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboBrand.Text == "请选择或输入品牌")
            {
                MessageBox.Show("请选择或输入品牌!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboOrigin.Text == "请选择或输入产地")
            {
                MessageBox.Show("请选择或输入产地!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            //if (txtWholeWeight.Text == string.Empty)
            //{
            //    MessageBox.Show("请输入整重!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            //if (txtGrossWeight.Text == string.Empty)
            //{
            //    MessageBox.Show("请输入毛重!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            if (txtQuantity.Text == string.Empty)
            {
                MessageBox.Show("请输入数量!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboUnit.SelectedItem==null)
            {
                MessageBox.Show("请选择单位!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            //if (txtDeposit.Text == string.Empty)
            //{
            //    MessageBox.Show("请输入押金!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            //if (txtFees.Text == string.Empty)
            //{
            //    MessageBox.Show("请输入应收费用!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            //if (lblCharges.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("没有计算出实收金额,请重新填写应收费!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    return;
            //}
            #endregion

            //检测角色是否合法
            var roleG = this.Text.Split('-');
            if (roleG!=null&&roleG.Length >= 2 && roleG[1].Contains("未知"))
            {
                MessageBox.Show("该角色不支持此操作", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            btnPrint.Enabled = false;
            try
            {
                _brand = cboBrand.Text;
                _origin = cboOrigin.Text;
                //_checkThread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadCheckField));
                //_checkThread.Start();
                ThreadCheckField();
                var tmpParam = GetRegistDateAndBatchId();
                string batchID = "";
                string registDate = "";
                if (tmpParam == null)
                {
                    MessageBox.Show("接口GetRegistDateAndBatchId异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    registDate = tmpParam[0];
                    batchID = tmpParam[1];
                }
                if (!ConfigMethod._isConnected)
                {
                    ConnectErrorShow(false);
                    return;
                }
                //明细
                string tmpDetail = "";
                if (cboDetail.Visible == true)
                    tmpDetail = cboDetail.SelectedItem.ToString();
                else
                    tmpDetail = cboSub.SelectedItem.ToString();

                string result = InsertData(registDate, batchID, txtShopId.Text.Trim()
                    , lblOwner.Text, txtTrafficId.Text.Trim(), tmpDetail, cboBrand.Text
                    , cboOrigin.Text, txtWholeWeight.Text.Trim(), txtGrossWeight.Text.Trim()
                    , txtQuantity.Text.Trim(), cboUnit.SelectedItem.ToString(), txtDeposit.Text.Trim());//, txtFees.Text.Trim(), lblCharges.Text.Trim()
                if (result != string.Empty)
                {
                    var jsonResult = (JObject)JsonConvert.DeserializeObject(result);
                    if (jsonResult["status"] != null && jsonResult["status"].ToString().ToLower().Contains("true"))
                    {
                        string quantity = "";
                        //if (jsonResult["data"] == null || string.IsNullOrEmpty(jsonResult["data"].ToString()))
                        //{
                        //    MessageBox.Show("单位转换获取失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //    quantity = txtQuantity.Text.Trim();
                        //}
                        //else
                        quantity = jsonResult["data"].ToString().Replace("\"", "");
                        MessageBox.Show("数据提交成功,开始打印." + Environment.NewLine + "批次号:" + batchID, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        ReadPrintModel();
                        SetPrintModelParams(registDate, batchID, txtShopId.Text.Trim()
                            , lblOwner.Text, txtTrafficId.Text.Trim(), tmpDetail, cboBrand.Text
                            , cboOrigin.Text, txtWholeWeight.Text.Trim(), txtGrossWeight.Text.Trim()
                            , quantity, "吨", txtDeposit.Text.Trim());//, txtFees.Text.Trim(), lblCharges.Text.Trim()
                        if (!btp.Print(_printModel))
                        {
                            //打印失败
                            WritePrintData(batchID, _printModel);
                            MessageBox.Show("打印失败,请连接好蓝牙打印机后,进入重打管理重打该批次!\r\n批次号为:{0}".ToFormatString(batchID), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        InitControlValue();
                    }
                    else
                    {
                        MessageBox.Show("数据提交失败".ToFormatString(batchID), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("数据提交失败".ToFormatString(batchID), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
            finally { btnPrint.Enabled = true; }
        }

        #region 自定义方法

        #region 打印相关

        /// <summary>
        /// 将打印失败的数据保存到本地
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        private void WritePrintData(string name,string value)
        {
            try
            {
                string _p = "";
                if(ConfigMethod._config.RoleCode=="1")
                    _p = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\FailePrint";
                else
                    _p = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\SaleFailePrint";
                if (!Directory.Exists(_p))
                    Directory.CreateDirectory(_p);
                using (var writer = new StreamWriter(_p + "\\" + name + ".txt", false, Encoding.Default))
                {
                    writer.Write(value);
                }
            }
            catch { MessageBox.Show("重打文件写入失败,批次号为{0}".ToFormatString(name), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }
        }

        /// <summary>
        /// 读取打印模板
        /// </summary>
        private void ReadPrintModel()
        {
            try
            {
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\modelKeeper.prn";

                if (System.IO.File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                    while (sr.Peek() >= 0)
                    {
                        _printModel = _printModel + sr.ReadLine().ToString() + "\r\n";
                    }
                }
                else
                {
                    _printModel = DefaultData.PrintModelStr1;
                }
            }
            catch {
                _printModel = DefaultData.PrintModelStr1;
            }
        }

        /// <summary>
        /// 给模板赋值
        /// </summary>
        private void SetPrintModelParams(string registDate, string batchId, string shopId, string owner, string trafficId
            , string type, string brand, string origin, string wholeWeight, string grossWeight, string quantity,string unit, string deposit)//, string fees, string charges
        {
            _printModel = _printModel.Replace("registerDate", registDate)
                                     .Replace("batchID", batchId)
                                     .Replace("shopID", shopId)
                                     .Replace("owner", owner)
                                     .Replace("trafficID", trafficId)
                                     .Replace("type", type)
                                     .Replace("brand", brand)
                                     .Replace("origin", origin)
                                     .Replace("wholeWeight",wholeWeight )
                                     .Replace("grossWeight", grossWeight)
                                     .Replace("quantity", quantity)
                                     .Replace("unit", unit)
                                     .Replace("deposit", deposit);
                                     //.Replace("fees", fees)
                                     //.Replace("charges", charges);
            _printModel = _printModel.Replace("role", ConfigMethod._config.RoleName + ":" + ConfigMethod._config.DisplayName);
            //_printModel = _printModel.Replace("name", ConfigMethod._config.DisplayName);
        }
        #endregion

        /// <summary>
        /// 使用线程异步检查字段
        /// </summary>
        private void ThreadCheckField()
        {
            AddNewBrand(_brand);
            AddNewOrigin(_origin);
        }

        /// <summary>
        /// 检查添加新的产地
        /// </summary> 
        /// <param name="origin"></param>
        private void AddNewOrigin(string origin)
        {
            try
            {
                bool rr = false;
                bool ss = false;
                if (!cboOrigin.Items.Contains(origin))
                {
                    cboOrigin.Items.Add(origin);
                    _service.CheckOrigin(origin, out rr, out ss);
                    if(!rr)
                        _service.AddNewOrigin(origin, out rr, out ss);
                }
            }
            catch
            {
                ConnectErrorShow(false);
            }
        }

        /// <summary>
        /// 检查添加新的品牌
        /// </summary>
        /// <param name="brand"></param>
        private void AddNewBrand(string brand)
        {
            try
            {
                bool rr = false;
                bool ss = false;
                if (!cboBrand.Items.Contains(brand))
                {
                    cboBrand.Items.Add(brand);
                    _service.CheckBrand(cboSub.Text,brand, out rr, out ss);
                    if(!rr)
                        _service.AddNewBrand(cboSub.Text, brand, out rr, out ss);
                }
            }
            catch {
                ConnectErrorShow(false);
            }
        }

        /// <summary>
        /// 初始化控件的值
        /// </summary>
        private void InitControlValue()
        {
            txtShopId.Text = string.Empty;
            lblOwner.Text = string.Empty;
            txtTrafficId.Text = string.Empty;
            txtWholeWeight.Text = string.Empty;
            txtGrossWeight.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDeposit.Text = string.Empty;
            txtFees.Text = string.Empty;
            lblCharges.Text = string.Empty;
            cboOrigin.Text = "请选择或输入产地";
            cboBrand.Text = "请选择或输入品牌";
            cboSub.Items.Clear();
            cboType.SelectedItem = null;
            //cboUnit.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化下拉框的子项
        /// </summary>
        private void InitComBoxValue()
        {
            try
            {
                //加载产地
                string origin = _service.TraversalOrigin();
                if (!string.IsNullOrEmpty(origin))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(origin);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var tmpOrgin = json["data"];
                        cboOrigin.Items.Clear();
                        cboOrigin.Text = "请选择或输入产地";
                        foreach (var v in tmpOrgin.Values())
                        {
                            cboOrigin.Items.Add(v.ToString().Trim('\"'));
                        }
                        
                    }
                    else
                        MessageBox.Show("接口TraversalOrigin异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口TraversalOrigin调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
                //加载品牌
                //string brand = _service.TraversalBrand();
                //if (!string.IsNullOrEmpty(brand))
                //{
                //    var json = (JObject)JsonConvert.DeserializeObject(brand);
                //    if (json["status"].ToString().Contains("true"))
                //    {
                //        var tmpBrand = json["data"];
                //        cboBrand.Items.Clear();
                //        cboBrand.Text = "请选择或输入品牌";
                //        foreach (var v in tmpBrand.Values())
                //        {
                //            cboBrand.Items.Add(v.ToString().Trim('\"'));
                //        }
                //    }
                //    else
                //        MessageBox.Show("接口TraversalBrand异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //}
                //else
                //    MessageBox.Show("接口TraversalBrand调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                //加载品种
                string type = _service.ReturnParentClass();
                if (!string.IsNullOrEmpty(type))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(type);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var tmpType = json["data"];
                        cboType.Items.Clear();
                        cboSub.Items.Clear();
                        cboType.Text = string.Empty;
                        foreach (var v in tmpType.Values())
                        {
                            cboType.Items.Add(v.ToString().Trim('\"'));
                        }
                    }
                    else
                        MessageBox.Show("接口ReturnParentClass异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口ReturnParentClass调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                //加载单位
                string unit = _service.TraversalUnit();
                if (!string.IsNullOrEmpty(unit))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(unit);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var tmpUnit = json["data"];
                        cboUnit.Items.Clear();
                        cboUnit.Text = string.Empty;
                        foreach (var v in tmpUnit.Values())
                        {
                            cboUnit.Items.Add(v.ToString().Trim('\"'));
                        }
                        
                        if (cboUnit.Items.Count > 0)
                            cboUnit.SelectedIndex = 0;
                    }
                    else
                        MessageBox.Show("接口TraversalBrand异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口TraversalBrand调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }

        /// <summary>
        /// 获取登记日期和批次号[0]是登记日期，[1]是批号
        /// </summary>
        /// <returns></returns>
        private string[] GetRegistDateAndBatchId()
        {
            try
            {
                string result = _service.CreateRegistDateAndBatchId();
                if(!string.IsNullOrEmpty(result))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(result);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var str=new string[2];
                        str[0] = json["data"][0].ToString().Trim('\"');
                        str[1] = json["data"][1].ToString().Trim('\"');
                        return str;
                    }
                }
                return null;
            }
            catch
            {
                ConfigMethod._isConnected = false;
                return null;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="registDate">日期</param>
        /// <param name="batchId">批次号</param>
        /// <param name="shopId">门店号</param>
        /// <param name="owner">门户名称</param>
        /// <param name="trafficId">车船号</param>
        /// <param name="type">品种</param>
        /// <param name="brand">品牌</param>
        /// <param name="origin">产地</param>
        /// <param name="wholeWeight">整重</param>
        /// <param name="grossWeight">毛重</param>
        /// <param name="quantity">数量</param>
        /// <param name="deposit">押金</param>
        /// <param name="fees">应收费</param>
        /// <param name="charges">实收费</param>
        /// <returns></returns>
        private string InsertData(string registDate, string batchId, string shopId, string owner, string trafficId
            , string type, string brand, string origin, string wholeWeight, string grossWeight, string quantity, string unit, string deposit)//,string fees,string charges
        {
            try
            {
                return _service.InsertData(registDate, batchId, shopId, owner, trafficId, type, brand, origin
                    , wholeWeight, grossWeight, quantity, unit, deposit,ConfigMethod._config.UserID);//, fees, charges
            }
            catch(Exception e) {
                MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ConfigMethod._isConnected=false;
                return "";
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                _service = new WebReference.EnterService();
                string tmp = System.Text.RegularExpressions.Regex.Match(_service.Url, @"\d+\.\d+\.\d+\.\d+:\d+").Value;
                _service.Url = _service.Url.Replace(tmp, ConfigMethod._config.IP);
                string conStr = _service.TestConnection();
                if (conStr.Equals("A-A"))
                {
                    this.Text = "车辆入场登记";
                    InitComBoxValue();

                    ConnectErrorShow(true);
                }
                else
                {
                    ConnectErrorShow(false);
                }
            }
            catch(Exception ee) {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ConnectErrorShow(false);
            }
        }

        #region 品种联动设置
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboDetail.Visible = false;
                cboDetail.Items.Clear();
                cboSub.Items.Clear();
                cboBrand.Items.Clear();
                if (cboType.SelectedItem == null)
                    return;
                if (string.IsNullOrEmpty(cboType.SelectedItem.ToString()))
                    return;
                if (!ConfigMethod._isConnected)
                    return;
                //加载小类
                string sub = _service.ReturnSubClass(cboType.SelectedItem.ToString());
                if (!string.IsNullOrEmpty(sub))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(sub);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var tmpSub = json["data"];
                        foreach (var v in tmpSub.Values())
                        {
                            cboSub.Items.Add(v.ToString().Trim('\"'));
                            
                        }
                    }
                    else
                        MessageBox.Show("接口ReturnSubClass异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口ReturnSubClass调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }

        private void cboSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboBrand.Items.Clear();
                cboDetail.Items.Clear();
                if (string.IsNullOrEmpty(cboSub.SelectedItem.ToString()))
                    return;
                if (!ConfigMethod._isConnected)
                    return;

                //加载明细
                string detail = _service.ReturnDetailedList(cboSub.SelectedItem.ToString());
                if (!string.IsNullOrEmpty(detail))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(detail);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var tmpDeatil = json["data"];
                        foreach (var v in tmpDeatil.Values())
                        {
                            cboDetail.Items.Add(v.ToString().Trim('\"'));
                        }
                    }
                    else
                        MessageBox.Show("接口ReturnDetailedList异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口ReturnDetailedList调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                if (cboDetail.Items.Count != 0)
                    cboDetail.Visible = true;
                else
                    cboDetail.Visible = false;

                //筛选品牌信息
                string brand = _service.ReturnBrand(cboSub.SelectedItem.ToString());
                if (!string.IsNullOrEmpty(brand))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(brand);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var tmpBrand = json["data"];
                        foreach (var v in tmpBrand.Values())
                        {
                            cboBrand.Items.Add(v.ToString().Trim('\"'));
                        }
                    }
                    else
                        MessageBox.Show("接口ReturnBrand异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口ReturnBrand调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }
        #endregion

        private void txtShopId_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtShopId.Text))
                    return;
                if (!ConfigMethod._isConnected)
                    return;
                string owner = _service.SearchOwner(txtShopId.Text.Trim());
                if (!string.IsNullOrEmpty(owner))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(owner);
                    if (json["status"].ToString().Contains("true"))
                    {
                        if (json["data"]!=null&&json["data"].ToString().Trim('\"') != string.Empty)
                            lblOwner.Text = json["data"].ToString().Trim('\"');
                        else
                        {
                            MessageBox.Show("该门店号不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            txtShopId.Focus();
                        }
                    }
                    else
                        MessageBox.Show("接口SearchOwner异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口SearchOwner调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }

        #region 数值格式检测
        private void txtWholeWeight_LostFocus(object sender, EventArgs e)
        {
            if (txtWholeWeight.Text == string.Empty)
                return;
            if (!txtWholeWeight.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtWholeWeight.Text = "";
                txtWholeWeight.Focus();
            }
        }

        private void txtGrossWeight_LostFocus(object sender, EventArgs e)
        {
            if (txtGrossWeight.Text == string.Empty)
                return;
            if (!txtGrossWeight.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtGrossWeight.Text = "";
            }
        }

        private void txtQuantity_LostFocus(object sender, EventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
                return;
            if (!txtQuantity.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtQuantity.Text = "";
                txtQuantity.Focus();
            }
        }

        private void txtDeposit_LostFocus(object sender, EventArgs e)
        {
            if (txtDeposit.Text == string.Empty)
                return;
            if (!txtDeposit.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtDeposit.Text = "";
                txtDeposit.Focus();
            }
        }
        #endregion

        private void mnuReConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_service != null)
                {
                    _service.Abort();
                    _service.Dispose();
                    _service = null;
                }
                _service = new WebReference.EnterService();
                string tmp=System.Text.RegularExpressions.Regex.Match(_service.Url,@"\d+\.\d+\.\d+\.\d+:\d+").Value;
                _service.Url = _service.Url.Replace(tmp, ConfigMethod._config.IP);
                string conStr = _service.TestConnection();
                if (conStr.Equals("A-A"))
                {
                    this.Text = "车辆入场登记";
                    InitComBoxValue();
                    ConnectErrorShow(true);
                }
                else
                {
                    ConnectErrorShow(false);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ConnectErrorShow(false);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if(_service!=null)
                _service.Dispose();
            if (ConfigMethod._config.RoleCode == "1")
                Application.Exit();
            else
                this.Close();
        }

        #region 下拉框友好提示
        private void cboBrand_GotFocus(object sender, EventArgs e)
        {
            if (cboBrand.Text == "请选择或输入品牌")
            {
                cboBrand.Text = string.Empty;
            }
        }

        private void cboBrand_LostFocus(object sender, EventArgs e)
        {
            if (cboBrand.Text == string.Empty)
            {
                cboBrand.Text = "请选择或输入品牌";
            }
        }

        private void cboOrigin_GotFocus(object sender, EventArgs e)
        {
            if (cboOrigin.Text == "请选择或输入产地")
            {
                cboOrigin.Text = string.Empty;
            }
        }

        private void cboOrigin_LostFocus(object sender, EventArgs e)
        {
            if (cboOrigin.Text == string.Empty)
            {
                cboOrigin.Text = "请选择或输入产地";
            }
        }
        #endregion

        private void menuItem2_Click(object sender, EventArgs e)
        {
            var formPrint = new formRePrint();
            formPrint.ShowDialog();
        }

        private void ConnectErrorShow(bool issuccess)
        {
            ConfigMethod._isConnected = issuccess;
            if (!ConfigMethod._isConnected)
            {
                if (InvokeRequired)
                {
                    Action a = new Action(() => { lblStatus.BackColor = Color.Red; });
                    a.Invoke();
                }
                else
                    lblStatus.BackColor = Color.Red;
                if (_service != null)
                {
                    _service.Abort();
                    _service.Dispose();
                    _service = null;
                }
            }
            else
            {
                if (InvokeRequired)
                {
                    Action a = new Action(() => { lblStatus.BackColor = Color.Green; });
                    a.Invoke();}
                else
                    lblStatus.BackColor = Color.Green;
            }
        }
        

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_service != null)
            {
                _service.Abort();
                _service.Dispose();
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            var edit = new formKeeperManage();
            edit.ShowDialog();
        }
    }
}