using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Jungo.wdapi_dotnet;
using Jungo.pci_0228_lib;
using wdc_err = Jungo.wdapi_dotnet.WD_ERROR_CODES;
using DWORD = System.UInt32;
using BOOL = System.Boolean;
using BYTE = System.Byte;

namespace Jungo.pci_0228_diag
{
    public class CfgTransfersForm : System.Windows.Forms.Form
    {
        private Exception m_excp;
        private PCI_0228_Device m_device;
        private RW m_direction;
        private DWORD m_dwOffset;
        private DWORD m_dwBytes;
        private IntPtr m_pData;
        private byte[] m_buff;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtBytes;
        private System.Windows.Forms.Label lblBytes;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btWrite;
        private System.Windows.Forms.Button btLog;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.ComponentModel.Container components = null;

        public CfgTransfersForm(PCI_0228_Device dev)
        {
            InitializeComponent();

            m_device = dev;                                                
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.btRead = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.txtBytes = new System.Windows.Forms.TextBox();
            this.lblBytes = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btWrite = new System.Windows.Forms.Button();
            this.btLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // txtOffset
            this.txtOffset.Location = new System.Drawing.Point(24, 32);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(96, 20);
            this.txtOffset.TabIndex = 0;
            this.txtOffset.Text = "";
            // txtData
            this.txtData.AutoSize = false;
            this.txtData.Location = new System.Drawing.Point(16, 136);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(208, 88);
            this.txtData.TabIndex = 8;
            this.txtData.Text = "";
            // lblOffset
            this.lblOffset.Location = new System.Drawing.Point(16, 8);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(88, 16);
            this.lblOffset.TabIndex = 2;
            this.lblOffset.Text = "Offset (hex):";
            // lblData
            this.lblData.Location = new System.Drawing.Point(16, 112);
            this.lblData.Name = "lblData";
            this.lblData.TabIndex = 3;
            this.lblData.Text = "Data:";
            // btRead
            this.btRead.Location = new System.Drawing.Point(24, 240);
            this.btRead.Name = "btRead";
            this.btRead.TabIndex = 4;
            this.btRead.Text = "Read";
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // btExit
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(232, 192);
            this.btExit.Name = "btExit";
            this.btExit.TabIndex = 7;
            this.btExit.Text = "Exit";
            // txtBytes
            this.txtBytes.Location = new System.Drawing.Point(152, 32);
            this.txtBytes.Name = "txtBytes";
            this.txtBytes.TabIndex = 2;
            this.txtBytes.Text = "";
            // lblBytes
            this.lblBytes.Location = new System.Drawing.Point(152, 8);
            this.lblBytes.Name = "lblBytes";
            this.lblBytes.Size = new System.Drawing.Size(120, 16);
            this.lblBytes.TabIndex = 6;
            this.lblBytes.Text = "Number of Bytes (hex):";
            // txtInput
            this.txtInput.Location = new System.Drawing.Point(168, 72);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(128, 20);
            this.txtInput.TabIndex = 3;
            this.txtInput.Text = "";
            // label1
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Input for Write Transactions (hex):";
            // btWrite
            this.btWrite.Location = new System.Drawing.Point(128, 240);
            this.btWrite.Name = "btWrite";
            this.btWrite.TabIndex = 5;
            this.btWrite.Text = "Write";
            this.btWrite.Click += new System.EventHandler(this.btWrite_Click);
            // btLog
            this.btLog.Location = new System.Drawing.Point(232, 152);
            this.btLog.Name = "btLog";
            this.btLog.TabIndex = 6;
            this.btLog.Text = "Clear Log";
            this.btLog.Click += new System.EventHandler(this.btLog_Click);
            // label2
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "0x";
            // label3
            this.label3.Location = new System.Drawing.Point(136, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "0x";
            // label4
            this.label4.Location = new System.Drawing.Point(152, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "0x";
            // CfgTransfersForm
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(328, 277);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btLog);
            this.Controls.Add(this.btWrite);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBytes);
            this.Controls.Add(this.lblBytes);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtOffset);
            this.Name = "CfgTransfersForm";
            this.StartPosition = 
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read/Write Cfg Space By Offset";
            this.ResumeLayout(false);

        }
#endregion

        public bool GetInput()
        {
            DialogResult result = DialogResult.Retry;

            while((result = ShowDialog()) == DialogResult.Retry);

            return true;                
        }

        private void btClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.None;
            try
            {
                TranslateInput();
            }
            catch
            {
                MessageBox.Show(m_excp.Message,"Input Entry Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.Retry;
            }    
        }

        private void btRead_Click(object sender, System.EventArgs e)
        {
            m_direction = RW.READ;
            btClick(sender, e);                        
        }

        private void btWrite_Click(object sender, System.EventArgs e)
        {
            m_direction = RW.WRITE;
            btClick(sender, e);
        }        

        private void TranslateInput()
        {
            DWORD dwStatus;
            BOOL bIsRead = m_direction == RW.READ;
            m_excp = new Exception("Enter the offset. Entered value should " +
                "be a hex number");
            m_dwOffset = (DWORD)Convert.ToInt32(txtOffset.Text,16);

            m_excp = new Exception("Enter the number of bytes. " + 
                "Entered value should be a hex number");
            m_dwBytes = (DWORD)Convert.ToInt32(txtBytes.Text,16);

            m_pData = Marshal.AllocHGlobal((int)m_dwBytes);
            if(m_pData == IntPtr.Zero)
                return;                        

            m_buff = new byte[m_dwBytes];

            if(!bIsRead)
            {
                if(txtInput.Text == "")
                {
                    m_excp = new Exception("You must enter the data to be " +
                        "written");
                    throw m_excp;
                }

                string str = diag_lib.PadBuffer(txtInput.Text, 
                    (DWORD)txtInput.Text.Length,(DWORD)2*m_dwBytes);

                m_excp = new Exception("The data you've entered is invalid. "
                    + "please try again (hex)");
                for(int i=0; i<m_dwBytes; ++i)
                    m_buff[i] = Convert.ToByte(str.Substring(2*i,2),16);

                Marshal.Copy(m_buff, 0 , m_pData, (int)m_dwBytes);

                dwStatus = wdc_lib_decl.WDC_PciWriteCfg(m_device.Handle, 
                    m_dwOffset, m_pData, m_dwBytes);                                 
            }
            else //READ
            {
                dwStatus = wdc_lib_decl.WDC_PciReadCfg(m_device.Handle, 
                    m_dwOffset, m_pData, m_dwBytes);

                if(dwStatus == (DWORD)wdc_err.WD_STATUS_SUCCESS)
                    Marshal.Copy(m_pData, m_buff, 0, (int)m_dwBytes);
            }

            TraceLog(bIsRead, (wdc_err)dwStatus);
        }

        private void btLog_Click(object sender, System.EventArgs e)
        {
            txtData.Clear();
        }

        private void TraceLog(BOOL bIsRead, wdc_err status)
        {
            string sData = "";
            string sInfo = "";
            if(status == wdc_err.WD_STATUS_SUCCESS)
            {
                sData = (bIsRead? "R: " : "W: ") +
                    diag_lib.DisplayHexBuffer(m_buff, m_dwBytes);
                sInfo = (bIsRead? " from " : " to ") + "offset " +
                    m_dwOffset.ToString("X") + "(" + m_device.ToString(false)
                    + ")";

                Log.TraceLog("CfgTransfersForm: " + sData + sInfo);
            }
            else
            {
                sData = "failed to " + (bIsRead? "read from" : "write to") +
                    " offset " + m_dwOffset.ToString("X") + " status 0x" +
                    status.ToString("X") + ": " + utils.Stat2Str((DWORD)status);
                sInfo = "(" + m_device.ToString(false) + ")";

                Log.ErrLog("CfgTransfersForm: " + sData + sInfo);
            }

            txtData.Text += sData + Environment.NewLine;            
        }
    }
}

