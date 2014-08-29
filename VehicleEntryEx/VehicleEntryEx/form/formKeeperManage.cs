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
using System.Reflection;
using System.IO;

namespace VehicleEntryEx
{
    public partial class formKeeperManage : Form
    {
        BluetoothPrinter btp = new BluetoothPrinter();
        WebReference.EnterService _service = new VehicleEntryEx.WebReference.EnterService();
        string _printModel = "";
        public formKeeperManage()
        {
            InitializeComponent();
        }
        private void ConnectErrorShow(bool issuccess)
        {
            ConfigMethod._isConnected = issuccess;
            if (!ConfigMethod._isConnected)
            {
                lblStatus.BackColor = Color.Red;
                _service.Abort();
                _service.Dispose();
                _service = null;
            }
            else
                lblStatus.BackColor = Color.Green;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lsvDataList.SelectedIndices.Count <= 0)
                return;
            var ticket = (Ticket)lsvDataList.Items[lsvDataList.SelectedIndices[0]].Tag;
            var edit = new formEdit(ticket);
            edit.Closing += (oo, ee) =>
            {
                var item = lsvDataList.Items[lsvDataList.SelectedIndices[0]];
                item.SubItems[0].Text = edit._ticket.CreateTime;
                item.SubItems[1].Text = edit._ticket.BatchId;
                item.SubItems[2].Text = edit._ticket.ShopId;
                item.SubItems[3].Text = edit._ticket.Owner;
                item.SubItems[4].Text = edit._ticket.TrafficId;
                item.SubItems[5].Text = edit._ticket.Detailed == string.Empty ? edit._ticket.SubClass : edit._ticket.Detailed;
                item.SubItems[6].Text = edit._ticket.Brand;
                item.SubItems[7].Text = edit._ticket.Origin;
                item.SubItems[8].Text = edit._ticket.WholeWeight;
                item.SubItems[9].Text = edit._ticket.GrossWeight;
                item.SubItems[10].Text = edit._ticket.Quantity;
                item.SubItems[11].Text = edit._ticket.Unit;
                item.SubItems[12].Text = edit._ticket.Deposit;
                //item.SubItems[13].Text = edit._ticket.Fees;
                //item.SubItems[14].Text = edit._ticket.Charges;
                item.Tag = edit._ticket;
                lsvDataList.Refresh();
            };
            edit.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lsvDataList.Items.Clear();
            if (dtEnd.Value < dtStart.Value)
            {
                MessageBox.Show("起始日期大于结束日期,请正确输入区间");
                return;
            }
            if (!ConfigMethod._isConnected)
            {
                MessageBox.Show("请重新连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            panel1.Enabled = false;
            try
            {
                string result = _service.SearchData(dtStart.Value.ToString("yyyyMMdd-HH:mm:ss"), dtEnd.Value.ToString("yyyyMMdd-HH:mm:ss"));
                if (!string.IsNullOrEmpty(result))
                {
                    var json = (JObject)JsonConvert.DeserializeObject(result);
                    if (json["status"].ToString().Contains("true"))
                    {
                        var data = json["data"];
                        foreach (var v in data)
                        {
                            var ticket = new Ticket();

                            ticket.CreateTime = v["RegistDate"].ToString().Trim('\"');
                            ticket.BatchId = v["BatchId"].ToString().Trim('\"');
                            ticket.ShopId = v["ShopId"].ToString().Trim('\"');
                            ticket.Owner = v["Owner"].ToString().Trim('\"');
                            ticket.TrafficId = v["TrafficId"].ToString().Trim('\"');
                            ticket.ParentClass = v["ParentClass"].ToString().Trim('\"');
                            ticket.SubClass = v["SubClass"].ToString().Trim('\"');
                            ticket.Detailed = v["Detailed"] == null ? "" : v["Detailed"].ToString().Trim('\"');
                            ticket.Brand = v["Brand"].ToString().Trim('\"');
                            ticket.Origin = v["Origin"].ToString().Trim('\"');
                            ticket.WholeWeight = v["WholeWeight"] == null ? "" : v["WholeWeight"].ToString().Trim('\"');
                            ticket.GrossWeight = v["GrossWeight"] == null ? "" : v["GrossWeight"].ToString().Trim('\"');
                            ticket.Quantity = v["Quantity"].ToString().Trim('\"');
                            ticket.QuantityP = v["RealQuantity"].ToString().Trim('\"');
                            ticket.Unit = v["Unit"].ToString().Trim('\"');
                            ticket.UnitP = "吨";
                            ticket.Deposit = v["Deposit"] == null ? "" : v["Deposit"].ToString().Trim('\"');
                            //ticket.Fees = v["Fees"] == null ? "" : v["Fees"].ToString().Trim('\"');
                            //ticket.Charges = v["Charges"] == null ? "" : v["Charges"].ToString().Trim('\"');
                            ticket.Fees = "";
                            ticket.Charges = "";

                            #region 添加到列表
                            var item = new ListViewItem();
                            item.Tag = ticket;
                            item.SubItems.Add("RegistDate");
                            item.SubItems[0].Text = ticket.CreateTime;
                            item.SubItems.Add("BatchId");
                            item.SubItems[1].Text = ticket.BatchId;
                            item.SubItems.Add("ShopId");
                            item.SubItems[2].Text = ticket.ShopId;
                            item.SubItems.Add("Owner");
                            item.SubItems[3].Text = ticket.Owner;
                            item.SubItems.Add("TrafficId");
                            item.SubItems[4].Text = ticket.TrafficId;
                            item.SubItems.Add("Type");
                            item.SubItems[5].Text = ticket.Detailed == string.Empty ? ticket.SubClass : ticket.Detailed;
                            item.SubItems.Add("Brand");
                            item.SubItems[6].Text = ticket.Brand;
                            item.SubItems.Add("Origin");
                            item.SubItems[7].Text = ticket.Origin;
                            item.SubItems.Add("WholeWeight");
                            item.SubItems[8].Text = ticket.WholeWeight;
                            item.SubItems.Add("GrossWeight");
                            item.SubItems[9].Text = ticket.GrossWeight;
                            item.SubItems.Add("Quantity");
                            item.SubItems[10].Text = ticket.Quantity;
                            item.SubItems.Add("Unit");
                            item.SubItems[11].Text = ticket.Unit;
                            item.SubItems.Add("Deposit");
                            item.SubItems[12].Text = ticket.Deposit;
                            //item.SubItems.Add("Fees");
                            //item.SubItems[13].Text = ticket.Fees;
                            //item.SubItems.Add("Charges");
                            //item.SubItems[14].Text = ticket.Charges;
                            lsvDataList.Items.Add(item);
                            lsvDataList.Refresh();
                            #endregion
                        }
                        if (lsvDataList.Items.Count <= 0)
                        {
                            MessageBox.Show("没有查询到未打印的单据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                        MessageBox.Show("接口SearchData异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("接口SearchData调用异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ConnectErrorShow(false);
            }
            finally
            {
                panel1.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lsvDataList.SelectedIndices.Count <= 0)
                return;
            panel1.Enabled = false;
            try
            {
                var ticket = (Ticket)lsvDataList.Items[lsvDataList.SelectedIndices[0]].Tag;
                ReadPrintModel();
                SetPrintModelParams(ticket.CreateTime, ticket.BatchId, ticket.ShopId, ticket.Owner
                    , ticket.TrafficId, ticket.ParentClass, ticket.Brand, ticket.Origin, ticket.WholeWeight
                    , ticket.GrossWeight, ticket.QuantityP, ticket.UnitP, ticket.Deposit, ticket.Fees, ticket.Charges);

                if (!btp.Print(_printModel))
                {
                    //打印失败
                    WritePrintData(ticket.BatchId, _printModel);
                    MessageBox.Show("打印失败,请连接好蓝牙打印机后,进入重打管理重打该批次!\r\n批次号为:{0}".ToFormatString(ticket.BatchId), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                lsvDataList.Items.Remove(lsvDataList.Items[lsvDataList.SelectedIndices[0]]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                ConnectErrorShow(false);
            }
            finally
            {
                panel1.Enabled = true;
            }
        }
        #region 打印相关

        /// <summary>
        /// 将打印失败的数据保存到本地
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        private void WritePrintData(string name, string value)
        {
            try
            {
                string _p = "";
                if (ConfigMethod._config.RoleCode == "1")
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
                string path;
                path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + "\\modelSale.prn";

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
                    _printModel = DefaultData.SalePrintModelStr;
                }
            }
            catch
            {
                _printModel = DefaultData.SalePrintModelStr;
            }
        }

        /// <summary>
        /// 给模板赋值
        /// </summary>
        private void SetPrintModelParams(string registDate, string batchId, string shopId, string owner, string trafficId
            , string type, string brand, string origin, string wholeWeight, string grossWeight, string quantity, string unit, string deposit, string fees
            , string charges)
        {
            _printModel = _printModel.Replace("registerDate", registDate)
                                     .Replace("batchID", batchId)
                                     .Replace("shopID", shopId)
                                     .Replace("owner", owner)
                                     .Replace("trafficID", trafficId)
                                     .Replace("type", type)
                                     .Replace("brand", brand)
                                     .Replace("origin", origin)
                                     .Replace("wholeWeight", wholeWeight)
                                     .Replace("grossWeight", grossWeight)
                                     .Replace("quantity", quantity)
                                     .Replace("unit", unit)
                                     .Replace("deposit", deposit)
                                     .Replace("fees", fees)
                                     .Replace("charges", charges);
            _printModel = _printModel.Replace("role", ConfigMethod._config.RoleName + ":" + ConfigMethod._config.DisplayName);
           // _printModel = _printModel.Replace("name", ConfigMethod._config.DisplayName);
        }
        #endregion

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lsvDataList.SelectedIndices.Count <= 0)
                return;
            if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                //调用接口删除数据
                try
                {
                    bool rr = false;
                    bool ss = false;
                    _service.DeleteData(lsvDataList.Items[lsvDataList.SelectedIndices[0]].SubItems[1].Text, out rr, out ss);
                    if (rr)
                    {
                        lsvDataList.Items.Remove(lsvDataList.Items[lsvDataList.SelectedIndices[0]]);
                        lsvDataList.Refresh();
                    }
                    else
                    { MessageBox.Show("删除失败"); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); ConnectErrorShow(false); }
            }
        }
    }
}