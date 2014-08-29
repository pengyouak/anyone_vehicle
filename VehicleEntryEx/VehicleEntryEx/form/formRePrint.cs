using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace VehicleEntryEx
{
    public partial class formRePrint : Form
    {
        BluetoothPrinter btp;

        public formRePrint()
        {
            InitializeComponent();
            btp = new BluetoothPrinter();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void LoadDocuments()
        {
            lstDocuments.Items.Clear();
            try
            {
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);

                string  newPath = "";
                if (ConfigMethod._config.RoleCode=="1")
                    newPath = path + "\\FailePrint\\";
                else
                    newPath = path + "\\SaleFailePrint\\";
                if (!System.IO.Directory.Exists(newPath))
                {
                    MessageBox.Show("没有可打印的文档!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                var directorys = System.IO.Directory.GetFiles(newPath,"*.txt");
                foreach (var file in directorys)
                {
                    var item = new ListBoxItem(file.Substring(file.LastIndexOf('\\') + 1), file);
                    lstDocuments.Items.Add(item);
                }
                if(lstDocuments.Items.Count<=0)
                    MessageBox.Show("没有可打印的文档!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch { }
        }

        private string GetPrintStr(string path)
        {
            string _printModel = "";
            try
            {
                using (var sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    while (sr.Peek() >= 0)
                    {
                        _printModel += sr.ReadLine().ToString() + "\r\n";
                    }
                }
                return _printModel;
            }
            catch { return _printModel; }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lstDocuments.SelectedItem == null)
            {
                MessageBox.Show("请选择一个未打印的批次来重打!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                return;
            }
            string str = GetPrintStr(((ListBoxItem)lstDocuments.SelectedItem).FilePath);
            if (str != string.Empty)
            {
                if (btp.Print(str))
                {
                    try
                    {
                        System.IO.File.Delete(((ListBoxItem)lstDocuments.SelectedItem).FilePath);
                    }
                    catch { }
                    MessageBox.Show("重打成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    LoadDocuments();
                }
                else
                { 
                    //打印失败
                }
            }
            else
            {
                MessageBox.Show("文件内容为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            
        }
    }

    public class ListBoxItem
    {
        private string _fileName = "";
        private string _filePath = "";

        public ListBoxItem(string name, string path)
        {
            _fileName = name;
            _filePath = path;
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public override string ToString()
        {
            return _fileName;
        }
    }
}