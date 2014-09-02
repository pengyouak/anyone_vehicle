using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace VehicleEntryEx
{
    public class BluetoothPrinter
    {
        private SoundPlayer beep;
        private SoundPlayer buzz;

        private PrintState _state = PrintState.UnInit;
        /// <summary>
        /// 获取打印状态
        /// </summary>
        public PrintState State
        {
            get { return _state; }
        }

        private System.IO.Ports.SerialPort _BTSerialPort;
        
        private System.IO.Ports.SerialPort BTSerialPort
        {
            get
            {
                if (_BTSerialPort == null)
                    return new System.IO.Ports.SerialPort();
                return _BTSerialPort;
            }
        }

        public BluetoothPrinter()
        {
            Init();
        }

        private void Init()
        {
            _BTSerialPort = new System.IO.Ports.SerialPort();
            _state = PrintState.Inited;
        }

        public bool Print(string msg)
        {
            byte[] _msg = System.Text.Encoding.Default.GetBytes(msg);
            return Print(_msg);
        }

        public bool Print(byte[] msg)
        {
            if (_state == PrintState.UnInit)
            {
                throw new Exception("尚未初始化打印控件!请使用Init方法初始化");
            }
            _state = PrintState.Printing;
            long filelen = msg.Length;
            if (!BTSerialPort.IsOpen)
            {
                try
                {
                    OpenBTPort();
                }
                catch (Exception ex)
                {
                    Buzz();
                    MessageBox.Show(@"打开蓝牙端口失败."+System.Environment.NewLine+ex.Message, "错误");
                    return false;
                }
            }
            try
            {
                BTSerialPort.DiscardInBuffer();
            }
            catch (Exception ee) {
                MessageBox.Show(@"蓝牙打印失败." + System.Environment.NewLine + ee.Message, "错误");
                return false;
            }
            Cursor.Current = Cursors.WaitCursor;
            _state = 0;
            try
            {
                long step = filelen / 3;
                long remain = filelen % 3;

                for (int i = 0; i < 3; ++i)
                {
                    BTSerialPort.Write(msg, i * (int)step, (int)step);
                    Beep();
                    System.Threading.Thread.Sleep(1000);
                }

                if (remain != 0) BTSerialPort.Write(msg, 3 * (int)step, (int)remain);

            }
            catch (Exception ex2)
            {
                Buzz();
                MessageBox.Show(@"向蓝牙端口发送数据失败." + System.Environment.NewLine + ex2.Message, "错误");
                return false;
            }

            _state = PrintState.Completed;
            Cursor.Current = Cursors.Default;
            return true;
        }

        private void OpenBTPort()
        {
            if (BTSerialPort.IsOpen) return;

            BTSerialPort.BaudRate = 57600;
            BTSerialPort.Parity = System.IO.Ports.Parity.None;
            BTSerialPort.StopBits = System.IO.Ports.StopBits.One;
            BTSerialPort.DataBits = 8;
            BTSerialPort.PortName = "COM8";
            //RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Bluetooth\\printui\\device");
            //BTSerialPort.PortName = key.GetValue("port").ToString();
            BTSerialPort.Open();
        }

        private void BTPrintSample_Closed(object sender, EventArgs e)
        {
            if (BTSerialPort.IsOpen)
            {
                try
                {
                    BTSerialPort.Close();
                }
                catch (Exception)
                { }
            }

            if (beep != null) beep.Dispose();
            if (buzz != null) buzz.Dispose();
        }

        private void Beep()
        {
            try
            {
                if (beep == null)
                {
                    Type t = GetType();
                    beep = new SoundPlayer(this.GetType().Assembly.GetManifestResourceStream(t.Namespace + ".beep.wav"));
                }

                beep.Play();
            }
            catch { }
        }

        private void Buzz()
        {
            try
            {
                if (buzz == null)
                {
                    Type t = GetType();
                    buzz = new SoundPlayer(this.GetType().Assembly.GetManifestResourceStream(t.Namespace + ".buzz.wav"));
                }

                buzz.Play();
            }
            catch { }
        }
    }

    /// <summary>
    /// 打印状态
    /// </summary>
    public enum PrintState
    { 
        /// <summary>
        /// 尚未初始化
        /// </summary>
        UnInit,
        /// <summary>
        /// 初始化完成
        /// </summary>
        Inited,
        /// <summary>
        /// 正在打印
        /// </summary>
        Printing,
        /// <summary>
        /// 打印完成
        /// </summary>
        Completed
    }
}
