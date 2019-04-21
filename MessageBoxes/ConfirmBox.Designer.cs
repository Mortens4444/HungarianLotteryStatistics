namespace MessageBoxes
{
	partial class ConfirmBox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmBox));
			this.p_Main = new System.Windows.Forms.Panel();
			this.rtb_Message = new System.Windows.Forms.RichTextBox();
			this.btn_Unpin = new System.Windows.Forms.Button();
			this.btn_Pin = new System.Windows.Forms.Button();
			this.btn_No = new System.Windows.Forms.Button();
			this.btn_Yes = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tt_Hint = new System.Windows.Forms.ToolTip(this.components);
			this.t_Close = new System.Windows.Forms.Timer(this.components);
			this.t_DecrementSecondsLeft = new System.Windows.Forms.Timer(this.components);
			this.p_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// p_Main
			// 
			this.p_Main.Controls.Add(this.rtb_Message);
			this.p_Main.Controls.Add(this.btn_Unpin);
			this.p_Main.Controls.Add(this.btn_Pin);
			this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p_Main.Location = new System.Drawing.Point(0, 0);
			this.p_Main.Name = "p_Main";
			this.p_Main.Size = new System.Drawing.Size(403, 107);
			this.p_Main.TabIndex = 0;
			// 
			// rtb_Message
			// 
			this.rtb_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtb_Message.BackColor = System.Drawing.SystemColors.Control;
			this.rtb_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtb_Message.Location = new System.Drawing.Point(48, 10);
			this.rtb_Message.Name = "rtb_Message";
			this.rtb_Message.ReadOnly = true;
			this.rtb_Message.Size = new System.Drawing.Size(344, 62);
			this.rtb_Message.TabIndex = 0;
			this.rtb_Message.TabStop = false;
			this.rtb_Message.Text = "";
			// 
			// btn_Unpin
			// 
			this.btn_Unpin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Unpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_Unpin.Image = ((System.Drawing.Image)(resources.GetObject("btn_Unpin.Image")));
			this.btn_Unpin.Location = new System.Drawing.Point(371, 78);
			this.btn_Unpin.Name = "btn_Unpin";
			this.btn_Unpin.Size = new System.Drawing.Size(21, 21);
			this.btn_Unpin.TabIndex = 1;
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
			this.btn_Pin.TabIndex = 2;
			this.btn_Pin.UseVisualStyleBackColor = true;
			this.btn_Pin.Visible = false;
			this.btn_Pin.Click += new System.EventHandler(this.btn_Pin_Click);
			// 
			// btn_No
			// 
			this.btn_No.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_No.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btn_No.Location = new System.Drawing.Point(203, 76);
			this.btn_No.Name = "btn_No";
			this.btn_No.Size = new System.Drawing.Size(75, 23);
			this.btn_No.TabIndex = 2;
			this.btn_No.Text = "No";
			this.btn_No.UseVisualStyleBackColor = true;
			// 
			// btn_Yes
			// 
			this.btn_Yes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_Yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btn_Yes.Location = new System.Drawing.Point(122, 76);
			this.btn_Yes.Name = "btn_Yes";
			this.btn_Yes.Size = new System.Drawing.Size(75, 23);
			this.btn_Yes.TabIndex = 1;
			this.btn_Yes.Text = "Yes";
			this.btn_Yes.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(10, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// t_Close
			// 
			this.t_Close.Tick += new System.EventHandler(this.t_Close_Tick);
			// 
			// t_DecrementSecondsLeft
			// 
			this.t_DecrementSecondsLeft.Enabled = true;
			this.t_DecrementSecondsLeft.Interval = 1000;
			this.t_DecrementSecondsLeft.Tick += new System.EventHandler(this.t_DecrementSecondsLeft_Tick);
			// 
			// ConfirmBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 107);
			this.Controls.Add(this.btn_No);
			this.Controls.Add(this.btn_Yes);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.p_Main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(411, 131);
			this.Name = "ConfirmBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "ConfirmBox";
			this.Shown += new System.EventHandler(this.ConfirmBox_Shown);
			this.p_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btn_Pin;
		private System.Windows.Forms.Button btn_Unpin;
		private System.Windows.Forms.Button btn_No;
		private System.Windows.Forms.Button btn_Yes;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolTip tt_Hint;
		private System.Windows.Forms.Timer t_Close;
		private System.Windows.Forms.Timer t_DecrementSecondsLeft;
		private System.Windows.Forms.RichTextBox rtb_Message;
	}
}