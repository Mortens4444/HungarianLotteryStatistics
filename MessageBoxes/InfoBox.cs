using System;
using System.Text;
using System.Windows.Forms;
using Consts;
using System.Threading;

namespace MessageBoxes
{
	public partial class InfoBox : BaseBox
	{
		protected InfoBox() { }

		InfoBox(string title, string message, int interval_in_milliseconds)
		{
			InitializeComponent();
			btn_Ok.Text = OK;
			Text = String.Concat(Application.ProductName, ": ", title);
			rtb_Message.Text = message;
			t_Close.Enabled = false;
			if (interval_in_milliseconds != Timeout.Infinite) t_Close.Interval = interval_in_milliseconds;
			else
			{
				btn_Pin.Visible = false;
				btn_Unpin.Visible = false;
			}
			t_DecrementSecondsLeft.Enabled = false;
		}

		public override sealed string Text
		{
			get { return base.Text; }
			set { base.Text = value; }
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
			btn_Unpin.Visible = true;
			tt_Hint.SetToolTip(btn_Unpin, EnableAutomaticMessageClosing);
			btn_Ok.Text = OK;
		}

		void UnpinMessage()
		{
			btn_Pin.Visible = true;
			btn_Unpin.Visible = false;
			tt_Hint.SetToolTip(btn_Pin, DisableAutomaticMessageClosing);
			t_Close.Start();
			t_DecrementSecondsLeft.Start();
			seconds_left = (int)(Math.Truncate((decimal)t_Close.Interval / 1000));
			ShowMessageOnOKButton();
		}

		void ShowMessageOnOKButton()
		{
			var ok_seconds_left = new StringBuilder(OK);
			ok_seconds_left.AppendFormat(" ({0})", seconds_left);
			btn_Ok.Text = ok_seconds_left.ToString();
		}

		void t_DecrementSecondsLeft_Tick(object sender, EventArgs e)
		{
			seconds_left--;
			ShowMessageOnOKButton();
		}

		static DialogResult Show(InfoBox ib)
		{
			if (ib.parent != null)
			{
				ib.Left = ib.parent.Left + (ib.parent.Width - ib.Width) / 2;
				ib.Top = ib.parent.Top + (ib.parent.Height - ib.Height) / 2;
			}
			else ib.StartPosition = FormStartPosition.CenterScreen;
			return ib.ShowDialog();
		}

		public static DialogResult Show(string title, string message, int interval_in_milliseconds)
		{
			return Show(null, title, message, interval_in_milliseconds);
		}

		public static DialogResult Show(string title, string message)
		{
			return Show(null, title, message, Constants.MILLISECONDS_LEFT);
		}

		public static DialogResult Show(Form parent, string title, string message)
		{
			return Show(parent, title, message, Constants.MILLISECONDS_LEFT);
		}

		public static DialogResult Show(Form parent, string title, string message, int interval_in_milliseconds)
		{
			var ib = new InfoBox(title, message, interval_in_milliseconds)
				{
					parent = parent
				};
			if (interval_in_milliseconds != Timeout.Infinite) ib.UnpinMessage();
			return Show(ib);
		}

		void t_Close_Tick(object sender, EventArgs e)
		{
			Close();
		}

		void InfoBox_Shown(object sender, EventArgs e)
		{
			rtb_Message.Select(0, 0);
		}
	}
}
