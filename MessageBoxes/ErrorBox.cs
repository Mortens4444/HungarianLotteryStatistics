using Consts;
using Enums;
using SourceInfo;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MessageBoxes
{
	public sealed partial class ErrorBox : BaseBox
	{
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

		ErrorBox(string title, string message, int interval_in_milliseconds)
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

			tt_Hint_2.SetToolTip(btn_SendToClipboard, CopyToClipboard);
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

		static DialogResult Show(ErrorBox eb)
		{
			if (eb.parent != null)
			{
				eb.Left = eb.parent.Left + (eb.parent.Width - eb.Width) / 2;
				eb.Top = eb.parent.Top + (eb.parent.Height - eb.Height) / 2;
			}
			else eb.StartPosition = FormStartPosition.CenterScreen;

			Console.Beep(440, 200);
			try
			{
				return eb.ShowDialog();
			}
			catch { return DialogResult.None; }
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

		public static void ShowLastWin32Error()
		{
			Show(new Win32Exception(Marshal.GetLastWin32Error()));
		}
        
		public static void ShowFileNotFound(string filename)
		{
			Show(Constants.GENERAL_ERROR, String.Concat(Constants.FILE_NOT_FOUND, filename));
		}
		
		public static void ShowLastWin32ErrorIfNotSuccess()
		{
			var error_code = Marshal.GetLastWin32Error();
			if (error_code != 0) Show(new Win32Exception(error_code));
		}

		public static DialogResult Show(Exception ex)
		{
			var ed = new ExceptionDetails(ex);
			return Show(null, ed.ExceptionType, ed.Details, Constants.MILLISECONDS_LEFT);
		}

		public static DialogResult ShowServiceNotification(Exception ex)
		{
			return MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
		}

		public static DialogResult Show(Exception ex, int interval_in_milliseconds)
		{
			var ed = new ExceptionDetails(ex);
			return Show(null, ed.ExceptionType, ed.Details, interval_in_milliseconds);
		}

		public static DialogResult Show(Form parent, Exception ex)
		{
			var ed = new ExceptionDetails(ex);
			return Show(parent, ed.ExceptionType, ed.Details, Constants.MILLISECONDS_LEFT);
		}

		public static DialogResult Show(Form parent, string title, Exception ex)
		{
			return Show(parent, title, ex.GetDetails(), Constants.MILLISECONDS_LEFT);
		}

		public static DialogResult Show(string title, Exception ex)
		{
			return Show(null, title, ex.GetDetails(), Constants.MILLISECONDS_LEFT);
		}

		public static DialogResult Show(string title, Exception ex, int interval_in_milliseconds)
		{
			return Show(null, title, ex.GetDetails(), interval_in_milliseconds);
		}

		public static DialogResult Show(Form parent, string title, string message, int interval_in_milliseconds)
		{
			var eb = new ErrorBox(title, message, interval_in_milliseconds)
				{
					parent = parent
				};
			if (interval_in_milliseconds != Timeout.Infinite) eb.UnpinMessage();
			return Show(eb);
		}

		void t_Close_Tick(object sender, EventArgs e)
		{
			Close();
		}

		void ErrorBox_Shown(object sender, EventArgs e)
		{
			rtb_Message.Select(0, 0);
		}

		void ErrorBox_Load(object sender, EventArgs e)
		{
			//SetWindowLong(this.Handle, (int)GetWindowLongParam.GWL_EXSTYLE, (WinAPI.GetWindowLong(this.Handle, GetWindowLongParam.GWL_EXSTYLE) | (int)ExtendedWindowStyles.WS_EX_TOPMOST));
			SetWindowPos(Handle, new IntPtr(-1), 0, 0, 0, 0, SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.IgnoreMove); // Set TOP_MOST
		}

		void tsmi_Copy_Click(object sender, EventArgs e)
		{
			ToClipboard();
		}

		void btn_SendToClipboard_Click(object sender, EventArgs e)
		{
			ToClipboard();
		}

		void ToClipboard()
		{
			try
			{
				/*Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
				Clipboard.SetText(rtb_Message.Text);*/
				rtb_Message.SelectAll();
				rtb_Message.Focus();
				//Clipboard.SetText(rtb_Message.Text);
				SendKeys.Send("^(C)");
				//rtb_Message.Select(0, 0);
			}
			catch (Exception ex)
			{
				Show(ex);
			}
		}
	}
}
