namespace MessageBoxes
{
	sealed partial class ErrorBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorBox));
			this.p_Main = new System.Windows.Forms.Panel();
			this.btn_SendToClipboard = new System.Windows.Forms.Button();
			this.rtb_Message = new System.Windows.Forms.RichTextBox();
			this.cms_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Unpin = new System.Windows.Forms.Button();
			this.btn_Pin = new System.Windows.Forms.Button();
			this.pb_Error = new System.Windows.Forms.PictureBox();
			this.btn_Ok = new System.Windows.Forms.Button();
			this.t_DecrementSecondsLeft = new System.Windows.Forms.Timer(this.components);
			this.t_Close = new System.Windows.Forms.Timer(this.components);
			this.tt_Hint = new System.Windows.Forms.ToolTip(this.components);
			this.tt_Hint_2 = new System.Windows.Forms.ToolTip(this.components);
			this.p_Main.SuspendLayout();
			this.cms_Menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_Error)).BeginInit();
			this.SuspendLayout();
			// 
			// p_Main
			// 
			this.p_Main.Controls.Add(this.btn_SendToClipboard);
			this.p_Main.Controls.Add(this.rtb_Message);
			this.p_Main.Controls.Add(this.btn_Unpin);
			this.p_Main.Controls.Add(this.btn_Pin);
			this.p_Main.Controls.Add(this.pb_Error);
			this.p_Main.Controls.Add(this.btn_Ok);
			this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p_Main.Location = new System.Drawing.Point(0, 0);
			this.p_Main.Name = "p_Main";
			this.p_Main.Size = new System.Drawing.Size(403, 107);
			this.p_Main.TabIndex = 0;
			// 
			// btn_SendToClipboard
			// 
			this.btn_SendToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SendToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_SendToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btn_SendToClipboard.Image")));
			this.btn_SendToClipboard.Location = new System.Drawing.Point(344, 78);
			this.btn_SendToClipboard.Name = "btn_SendToClipboard";
			this.btn_SendToClipboard.Size = new System.Drawing.Size(21, 21);
			this.btn_SendToClipboard.TabIndex = 11;
			this.btn_SendToClipboard.UseVisualStyleBackColor = true;
			this.btn_SendToClipboard.Click += new System.EventHandler(this.btn_SendToClipboard_Click);
			// 
			// rtb_Message
			// 
			this.rtb_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtb_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtb_Message.ContextMenuStrip = this.cms_Menu;
			this.rtb_Message.Location = new System.Drawing.Point(48, 10);
			this.rtb_Message.Name = "rtb_Message";
			this.rtb_Message.ReadOnly = true;
			this.rtb_Message.Size = new System.Drawing.Size(344, 62);
			this.rtb_Message.TabIndex = 9;
			this.rtb_Message.Text = "";
			// 
			// cms_Menu
			// 
			this.cms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Copy});
			this.cms_Menu.Name = "contextMenuStrip1";
			this.cms_Menu.Size = new System.Drawing.Size(100, 26);
			// 
			// tsmi_Copy
			// 
			this.tsmi_Copy.Image = global::MessageBoxes.Resource.copy;
			this.tsmi_Copy.Name = "tsmi_Copy";
			this.tsmi_Copy.Size = new System.Drawing.Size(99, 22);
			this.tsmi_Copy.Text = "Copy";
			this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
			// 
			// btn_Unpin
			// 
			this.btn_Unpin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Unpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Unpin.Image = ((System.Drawing.Image)(resources.GetObject("btn_Unpin.Image")));
			this.btn_Unpin.Location = new System.Drawing.Point(371, 78);
			this.btn_Unpin.Name = "btn_Unpin";
			this.btn_Unpin.Size = new System.Drawing.Size(21, 21);
			this.btn_Unpin.TabIndex = 2;
			this.btn_Unpin.UseVisualStyleBackColor = true;
			this.btn_Unpin.Visible = false;
			this.btn_Unpin.Click += new System.EventHandler(this.btn_Unpin_Click);
			// 
			// btn_Pin
			// 
			this.btn_Pin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Pin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Pin.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pin.Image")));
			this.btn_Pin.Location = new System.Drawing.Point(371, 78);
			this.btn_Pin.Name = "btn_Pin";
			this.btn_Pin.Size = new System.Drawing.Size(21, 21);
			this.btn_Pin.TabIndex = 3;
			this.btn_Pin.UseVisualStyleBackColor = true;
			this.btn_Pin.Visible = false;
			this.btn_Pin.Click += new System.EventHandler(this.btn_Pin_Click);
			// 
			// pb_Error
			// 
			this.pb_Error.Image = ((System.Drawing.Image)(resources.GetObject("pb_Error.Image")));
			this.pb_Error.Location = new System.Drawing.Point(10, 10);
			this.pb_Error.Name = "pb_Error";
			this.pb_Error.Size = new System.Drawing.Size(32, 32);
			this.pb_Error.TabIndex = 8;
			this.pb_Error.TabStop = false;
			// 
			// btn_Ok
			// 
			this.btn_Ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_Ok.Location = new System.Drawing.Point(165, 76);
			this.btn_Ok.Name = "btn_Ok";
			this.btn_Ok.Size = new System.Drawing.Size(75, 23);
			this.btn_Ok.TabIndex = 1;
			this.btn_Ok.Text = "OK";
			this.btn_Ok.UseVisualStyleBackColor = true;
			// 
			// t_DecrementSecondsLeft
			// 
			this.t_DecrementSecondsLeft.Enabled = true;
			this.t_DecrementSecondsLeft.Interval = 1000;
			this.t_DecrementSecondsLeft.Tick += new System.EventHandler(this.t_DecrementSecondsLeft_Tick);
			// 
			// t_Close
			// 
			this.t_Close.Tick += new System.EventHandler(this.t_Close_Tick);
			// 
			// ErrorBox
			// 
			this.AcceptButton = this.btn_Ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 107);
			this.Controls.Add(this.p_Main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(411, 131);
			this.Name = "ErrorBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Title";
			this.Load += new System.EventHandler(this.ErrorBox_Load);
			this.Shown += new System.EventHandler(this.ErrorBox_Shown);
			this.p_Main.ResumeLayout(false);
			this.cms_Menu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_Error)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btn_Unpin;
		private System.Windows.Forms.Button btn_Pin;
		private System.Windows.Forms.PictureBox pb_Error;
		private System.Windows.Forms.Button btn_Ok;
		private System.Windows.Forms.Timer t_DecrementSecondsLeft;
		private System.Windows.Forms.Timer t_Close;
		private System.Windows.Forms.ToolTip tt_Hint;
		private System.Windows.Forms.RichTextBox rtb_Message;
		private System.Windows.Forms.ContextMenuStrip cms_Menu;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
		private System.Windows.Forms.Button btn_SendToClipboard;
		private System.Windows.Forms.ToolTip tt_Hint_2;
	}
}