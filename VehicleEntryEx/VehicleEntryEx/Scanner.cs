using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HandHeldProducts.Embedded.Decoding;
using HandHeldProducts.Embedded.Hardware;
using HandHeldProducts.Embedded.Utility;
using HandHeldProducts.SmartDevice.Component;
using System.Windows.Forms;
using System.Media;

namespace VehicleEntryEx
{
    public class Scanner
    {
		private DecodeAssembly oDecodeAssembly;
        private SoundPlayer _success;
        private SoundPlayer _failed;
		private bool m_ResumeAutoScan;
		private int m_DecodeStartTime;
		private int m_DecodeStopTime;
		private string m_RF_IP_Address;
		private string m_RF_TCP_Port;
		private bool m_RF_AutoSend;

        //public delegate void ScanedEvent(object sender, DecodeAssembly.DecodeEventArgs e);
        public event DecodeAssembly.DecodeEventHandler Scaned_DoEvent; 

        public enum ScanModeType
        {
            Automatic,
            Manual
        }

		public bool ResumeAutoScanFlag
		{
			get
			{
				return this.m_ResumeAutoScan;
			}
			set
			{
				this.m_ResumeAutoScan = value;
			}
		}

		public bool RF_AutoSend
		{
			get
			{
				return this.m_RF_AutoSend;
			}
			set
			{
				this.m_RF_AutoSend = value;
			}
		}

		public string RF_IP_Address
		{
			get
			{
				return this.m_RF_IP_Address;
			}
			set
			{
				this.m_RF_IP_Address = value;
			}
		}

		public string RF_TCP_Port
		{
			get
			{
				return this.m_RF_TCP_Port;
			}
			set
			{
				this.m_RF_TCP_Port = value;
			}
		}

        public void Decode_KeyDown()
        {
            try
            {
                this.m_DecodeStartTime = Environment.TickCount;
                this.oDecodeAssembly.ScanBarcode();
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Green, 0);
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Red, 1);

            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
            }
        }

        public void Decode_KeyUp()
        {
            try
            {
                if (this.oDecodeAssembly.ScanInProgress)
                {
                    this.oDecodeAssembly.CancelScanBarcode();
                }
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Red, 0);
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Green, 0);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
            }
        }

        public void Decode_Load()
        {
            try
            {
                this.DecodeAssemblyInitialize();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
            }
        }

        private void DecodeAssemblyInitialize()
        {
            try
            {
                this.oDecodeAssembly = new DecodeAssembly();
                string str = this.oDecodeAssembly.Device.Imager.EngineType.ToString();
                if (Scaned_DoEvent != null)
                    this.oDecodeAssembly.DecodeEvent += Scaned_DoEvent;
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Red, 0);
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Green, 0);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void DecodeAssemblyRelease()
        {
            try
            {
                if (Scaned_DoEvent != null)
                    this.oDecodeAssembly.DecodeEvent -= Scaned_DoEvent;
                this.oDecodeAssembly.Dispose();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        private void oDecodeAssembly_DecodeEvent(object sender, DecodeAssembly.DecodeEventArgs e)
        {
            try
            {
                this.m_DecodeStopTime = Environment.TickCount;
                int mDecodeStopTime = this.m_DecodeStopTime - this.m_DecodeStartTime;
                
                if (e.ResultCode == DecodeAssembly.ResultCodes.Success)
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch { }
        }
        public void Dispose(bool disposing)
        {
            try
            {
                this.oDecodeAssembly.CancelScanBarcode();
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Red, 0);
                this.oDecodeAssembly.Device.SetLED(Device.LedColor.Green, 0);
                if (_success != null) _success.Dispose();
                if (_failed != null) _failed.Dispose();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        public void Success()
        {
            try
            {
                if (_success == null)
                {
                    Type t = GetType();
                    _success = new SoundPlayer(this.GetType().Assembly.GetManifestResourceStream(t.Namespace + ".success.wav"));
                }

                _success.Play();
            }
            catch { }
        }

        public void Failed()
        {
            try
            {
                if (_failed == null)
                {
                    Type t = GetType();
                    _failed = new SoundPlayer(this.GetType().Assembly.GetManifestResourceStream(t.Namespace + ".buzz.wav"));
                }

                _failed.Play();
            }
            catch { }
        }
    }
}
