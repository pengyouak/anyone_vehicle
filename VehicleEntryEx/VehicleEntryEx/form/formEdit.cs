using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VehicleEntryEx
{
    public partial class formEdit : Form
    {
        private bool _isChargeEdit=false;
        public bool IsChargeEdit { set { _isChargeEdit = value; } }
        bool _isConnected = true;
        WebReference.EnterService _service = new WebReference.EnterService();
        public Ticket _ticket = new Ticket();
        public formEdit(Ticket ticket)
        {
            InitializeComponent();
            InitComBoxValue();
            _ticket = ticket;
            
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
                        cboSubType.Items.Clear();
                        cboDetail.Items.Clear();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }
        private void Init(Ticket ticket)
        {
            txtShopId.Text = ticket.ShopId;
            lblOwner.Text = ticket.Owner;
            txtTrafficId.Text = ticket.TrafficId;

            if (cboUnit.Items.Contains(_ticket.Unit))
                cboUnit.SelectedItem = _ticket.Unit;
            else
                cboUnit.SelectedItem = null;

            if (cboType.Items.Contains(_ticket.ParentClass))
            {
                cboType.SelectedItem = _ticket.ParentClass;
            }
            if (cboSubType.Items.Contains(_ticket.SubClass))
            { 
                cboSubType.SelectedItem = _ticket.SubClass;
            }
            if(_ticket.Detailed != string.Empty)
                cboDetail.Visible = true;
            if (_ticket.Detailed != string.Empty && cboDetail.Items.Contains(_ticket.Detailed))
                cboDetail.SelectedItem = _ticket.Detailed;

            cboBrand.Text = ticket.Brand;
            cboOrigin.Text = ticket.Origin;
            

            txtWholeWeight.Text = ticket.WholeWeight;
            txtGrossWeight.Text = ticket.GrossWeight;
            txtQuantity.Text = ticket.Quantity;
            txtDeposit.Text = ticket.Deposit;
            if (_isChargeEdit)
            {
                txtShopId.Enabled = false;
                txtTrafficId.Enabled = false;
                cboUnit.Enabled = false;
                cboType.Enabled = false;
                cboSubType.Enabled = false;
                cboDetail.Enabled = false;
                cboBrand.Enabled = false;
                cboOrigin.Enabled = false;
                txtWholeWeight.Enabled = false;
                txtGrossWeight.Enabled = false;
                txtQuantity.Enabled = false;
                txtDeposit.Enabled = false;
                txtFees.ReadOnly = false;
                txtCharges.ReadOnly = false;
            }

            txtFees.Text = ticket.Fees;
            txtCharges.Text = ticket.Charges;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            if (cboType.SelectedItem == null)
            {
                MessageBox.Show("请选择品种!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboSubType.SelectedItem == null)
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
            _ticket.Quantity = txtQuantity.Text.Trim();
            _ticket.Charges = txtCharges.Text.Trim();
            _ticket.Brand = cboBrand.Text;
            _ticket.Origin = cboOrigin.Text;
            _ticket.TrafficId = txtTrafficId.Text.Trim();
            _ticket.WholeWeight = txtWholeWeight.Text.Trim();
            _ticket.GrossWeight = txtGrossWeight.Text.Trim();
            _ticket.Deposit = txtDeposit.Text.Trim();
            _ticket.Fees = txtFees.Text.Trim();
            _ticket.Charges = txtCharges.Text.Trim();
            _ticket.Unit = cboUnit.SelectedItem.ToString();

            _ticket.ParentClass = cboType.SelectedItem.ToString();
            _ticket.SubClass = cboSubType.SelectedItem.ToString();
            if (cboDetail.Visible)
                _ticket.Detailed = cboDetail.SelectedItem.ToString();
            else
                _ticket.Detailed = "";
            panel1.Enabled = false;
            //使用接口更新数据库
            try
            {
                string tmpType = _ticket.Detailed == string.Empty ? _ticket.SubClass : _ticket.Detailed;
                string result = _service.ModifyData(_ticket.BatchId, _ticket.ShopId, _ticket.Owner, _ticket.TrafficId, tmpType
                    ,_ticket.Brand,_ticket.Origin,_ticket.WholeWeight,_ticket.GrossWeight,_ticket.Quantity,_ticket.Unit,_ticket.Deposit);
                var json = (JObject)JsonConvert.DeserializeObject(result);
                if (json["status"] != null && json["status"].ToString().Contains("true"))
                {
                    MessageBox.Show("更新成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    _ticket.QuantityP = json["data"].ToString();
                    _service.Abort();
                    _service.Dispose();
                    Close();
                }
                else
                    MessageBox.Show("接口ModifyData异常!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("接口ModifyData调用异常!\r\n"+ex.Message);
            }
            finally { panel1.Enabled = true; }
        }

        private void txtQuantity_LostFocus(object sender, EventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
                return;
            if (!txtQuantity.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtQuantity.Text = "";
            }
        }

        private void txtCharges_LostFocus(object sender, EventArgs e)
        {
            if (txtCharges.Text == string.Empty)
                return;
            if (!txtCharges.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtCharges.Text = "";
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboDetail.Visible = false;
                cboDetail.Items.Clear();
                cboSubType.Items.Clear();
                cboBrand.Items.Clear();
                if (cboType.SelectedItem == null)
                    return;
                if (string.IsNullOrEmpty(cboType.SelectedItem.ToString()))
                    return;
                if (!_isConnected)
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
                            cboSubType.Items.Add(v.ToString().Trim('\"'));
                        }
                    }
                    else
                        MessageBox.Show("接口ReturnSubClass异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口ReturnSubClass调用异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }

        private void cboSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboBrand.Items.Clear();
                cboDetail.Items.Clear();
                if (string.IsNullOrEmpty(cboSubType.SelectedItem.ToString()))
                    return;
                if (!_isConnected)
                    return;

                //加载明细
                string detail = _service.ReturnDetailedList(cboSubType.SelectedItem.ToString());
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
                string brand = _service.ReturnBrand(cboSubType.SelectedItem.ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
        }
        private void ConnectErrorShow(bool issuccess)
        {
            _isConnected = issuccess;
            if (!_isConnected)
            {
                lblStatus.BackColor = Color.Red;
                if (_service != null)
                {
                    _service.Abort();
                    _service.Dispose();
                    _service = null;
                }
            }
            else
                lblStatus.BackColor = Color.Green;
        }
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

        private void formEdit_Load(object sender, EventArgs e)
        {
            Init(_ticket);
        }

        private void txtDeposit_LostFocus(object sender, EventArgs e)
        {
            if (txtDeposit.Text == string.Empty)
                return;
            if (!txtDeposit.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtDeposit.Text = "";
            }
        }

        private void txtFees_LostFocus(object sender, EventArgs e)
        {
            if (txtFees.Text == string.Empty)
                return;
            if (!txtFees.Text.Trim().IsDoubleValue())
            {
                MessageBox.Show("请输入数值型数据!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtFees.Text = "";
            }
        }
    }
}