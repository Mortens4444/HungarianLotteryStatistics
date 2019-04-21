using System;
using System.Text;
using System.Windows.Forms;
using Enums;
using System.Threading;

namespace MessageBoxes
{
	public partial class ConfirmBox : BaseBox
	{
		readonly bool default_choose;
		readonly bool show_autoclose_buttons;

		protected ConfirmBox() { }

		protected ConfirmBox(string title, string message, int interval_in_milliseconds, Decide default_choose)
		{
			InitializeComponent();
			btn_Yes.Text = Yes;
			btn_No.Text = No;
			Text = String.Concat(Application.ProductName, ": ", title);
			rtb_Message.Text = message;
			t_Close.Enabled = false;
			this.default_choose = Decide.Yes == default_choose;
			
			show_autoclose_buttons = interval_in_milliseconds != Timeout.Infinite;
			if (show_autoclose_buttons) t_Close.Interval = interval_in_milliseconds;
			t_DecrementSecondsLeft.Enabled = false;
		}

		public override sealed string Text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		void FocusAcceptButton()
		{
			if (default_choose) btn_Yes.Focus();
			else btn_No.Focus();
		}

		void btn_Pin_Click(object sender, EventArgs e)
		{
			PinMessage();
		}

		void btn_Unpin_Click(object sender, EventArgs e)
		{
			UnpinMessage();
		}

		void PinMessage()
		{
			t_Close.Stop();
			t_DecrementSecondsLeft.Stop();
			btn_Pin.Visible = false;
			btn_Unpin.Visible = show_autoclose_buttons;
			tt_Hint.SetToolTip(btn_Unpin, EnableAutomaticMessageClosing);
			btn_Yes.Text = Yes;
			btn_No.Text = No;
			FocusAcceptButton();
		}

		void UnpinMessage()
		{
			btn_Pin.Visible = true;
			btn_Unpin.Visible = false;
			tt_Hint.SetToolTip(btn_Pin, DisableAutomaticMessageClosing);
			t_Close.Start();
			t_DecrementSecondsLeft.Start();
			seconds_left = (int)(Math.Truncate((decimal)t_Close.Interval / 1000));
			ShowMessageOnDefaultButton();
		}

		void ShowMessageOnDefaultButton()
		{
			var ok_seconds_left = new StringBuilder();
			ok_seconds_left.Append(default_choose ? Yes : No);
			ok_seconds_left.AppendFormat(" ({0})", seconds_left);
			if (default_choose) btn_Yes.Text = ok_seconds_left.ToString();
			else btn_No.Text = ok_seconds_left.ToString();
		}

		void t_DecrementSecondsLeft_Tick(object sender, EventArgs e)
		{
			seconds_left--;
			ShowMessageOnDefaultButton();
		}

		static DialogResult Show(ConfirmBox cb)
		{
			if (cb.parent != null)
			{
				cb.Left = cb.parent.Left + (cb.parent.Width - cb.Width) / 2;
				cb.Top = cb.parent.Top + (cb.parent.Height - cb.Height) / 2;
			}
			else cb.StartPosition = FormStartPosition.CenterScreen;
			return cb.ShowDialog();
		}

		public static DialogResult Show(string title, string message, int interval_in_milliseconds, Decide default_choose)
		{
			return Show(null, title, message, interval_in_milliseconds, default_choose);
		}

		/*public static bool Show(string title, string message, Decide default_choose)
		{
			return Show(null, title, message, Timeout.Infinite, default_choose) == DialogResult.Yes;
		}*/

		public static DialogResult Show(string title, string message, Decide default_choose)
		{
			return Show(null, title, message, Timeout.Infinite, default_choose);
		}

		public static DialogResult Show(Form parent, string title, string message, Decide default_choose)
		{
			return Show(parent, title, message, Timeout.Infinite, default_choose);
		}

		public static DialogResult Show(Form parent, string title, string message, int interval_in_milliseconds, Decide default_choose)
		{
			var cb = new ConfirmBox(title, message, interval_in_milliseconds, default_choose)
				{
					parent = parent
				};
			if (interval_in_milliseconds == Timeout.Infinite) cb.PinMessage();
			else cb.UnpinMessage();
			return Show(cb);
		}

		void t_Close_Tick(object sender, EventArgs e)
		{
			AcceptButton.PerformClick();
		}

		void ConfirmBox_Shown(object sender, EventArgs e)
		{
			rtb_Message.Select(0, 0);
			AcceptButton = default_choose ? btn_Yes : btn_No;
			CancelButton = btn_No;
			FocusAcceptButton();
		}
	}
}
