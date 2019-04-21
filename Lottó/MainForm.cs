using System;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Globalization;
using System.Collections.Generic;
using MessageBoxes;

namespace Lottó
{
	public partial class MainForm : Form
	{
		private string fileName;

		public MainForm()
		{
			InitializeComponent();
			cb_StatisticsFile.SelectedIndex = 0;
		}

		private void cb_StatisticsFile_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cb_StatisticsFile.SelectedIndex)
			{
				case 0:
					nud_MaxValue.Value = 90;
					nud_NumberCount.Value = 5;
					break;
				case 1:
					nud_MaxValue.Value = 45;
					nud_NumberCount.Value = 6;
					break;
			}
		}

		private void btn_Download_Click(object sender, EventArgs e)
		{
			fileName = Path.Combine(Application.StartupPath, cb_StatisticsFile.Text.Substring(cb_StatisticsFile.Text.LastIndexOf('/') + 1));
            FileDownloader.DownloadFileAsync(cb_StatisticsFile.Text, fileName, Completed);
		}

		private void Completed(object sender, AsyncCompletedEventArgs e)
		{
			GetStatistics((byte)nud_MinValue.Value, (byte)nud_MaxValue.Value, (byte)nud_NumberCount.Value);
		}

		private void btn_Statistics_Click(object sender, EventArgs e)
		{
			fileName = Path.Combine(Application.StartupPath, cb_StatisticsFile.Text.Substring(cb_StatisticsFile.Text.LastIndexOf('/') + 1));
			GetStatistics((byte)nud_MinValue.Value, (byte)nud_MaxValue.Value, (byte)nud_NumberCount.Value);
		}

		private void GetStatistics(byte min_value, byte max_value, byte number_count)
		{
			try
			{
				var drawings = new List<Drawing>();
                var rows = FileReader.GetFileContent(fileName).SplitOnNewLines();
				for (int i = 0; i < rows.Length; i++)
				{
					if ((rows[i] != null) && (rows[i] != String.Empty))
					{
						string[] values = rows[i].Split(';');

						var hitDetails = new List<HitDetail>();
                        for (int j = 1; j < number_count; j++)
                        {
                            var amount = values[2 * j + 2].Remove("Ft").Remove(" ");
                            hitDetails.Add(new HitDetail(Convert.ToInt32(values[2 * j + 1]), Convert.ToDecimal(amount)));
                        }

						var numbers = new List<byte>();
                        for (int j = 1; j <= number_count; j++)
                        {
                            numbers.Add(Convert.ToByte(values[number_count * 2 + j]));
                        }

						Drawing draw;
                        if (values[2] == String.Empty)
                        {
                            draw = new Drawing(Convert.ToInt16(values[0]), Convert.ToByte(values[1]), null, hitDetails, numbers);
                        }
                        else
                        {
                            draw = new Drawing(Convert.ToInt16(values[0]), Convert.ToByte(values[1]), Convert.ToDateTime(values[2], new CultureInfo("hu-HU")), hitDetails, numbers);
                        }

						drawings.Add(draw);
					}
				}

				var stats = new Statistics(min_value, max_value, drawings);
				rtb_LeastFrequentNumbers.Text = stats.LeastFrequentNumbers;

				nud_Even.Value = stats.Even;
				nud_Odd.Value = stats.Odd;
				if (nud_Even.Value + 5 > nud_Odd.Value) chk_Even.CheckState = CheckState.Unchecked;
				else if (nud_Even.Value > nud_Odd.Value) chk_Even.CheckState = CheckState.Indeterminate;
				else chk_Even.CheckState = CheckState.Checked;

				nud_DivisibleByThree.Value = stats.DivisibleByThree;
				nud_NotDivisibleByThree.Value = stats.NotDivisibleByThree;
				if (2 * nud_DivisibleByThree.Value + 5 > nud_NotDivisibleByThree.Value) chk_DivisibleByThree.CheckState = CheckState.Unchecked;
				else if (2 * nud_DivisibleByThree.Value > nud_NotDivisibleByThree.Value) chk_DivisibleByThree.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByThree.CheckState = CheckState.Checked;

				nud_DivisibleByFour.Value = stats.DivisibleByFour;
				nud_NotDivisibleByFour.Value = stats.NotDivisibleByFour;
				if (3 * nud_DivisibleByFour.Value + 5 > nud_NotDivisibleByFour.Value) chk_DivisibleByFour.CheckState = CheckState.Unchecked;
				else if (3 * nud_DivisibleByFour.Value > nud_NotDivisibleByFour.Value) chk_DivisibleByFour.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByFour.CheckState = CheckState.Checked;

				nud_DivisibleByFive.Value = stats.DivisibleByFive;
				nud_NotDivisibleByFive.Value = stats.NotDivisibleByFive;
				if (4 * nud_DivisibleByFive.Value + 5 > nud_NotDivisibleByFive.Value) chk_DivisibleByFive.CheckState = CheckState.Unchecked;
				else if (4 * nud_DivisibleByFive.Value > nud_NotDivisibleByFive.Value) chk_DivisibleByFive.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByFive.CheckState = CheckState.Checked;

				nud_DivisibleBySix.Value = stats.DivisibleBySix;
				nud_NotDivisibleBySix.Value = stats.NotDivisibleBySix;
				if (5 * nud_DivisibleBySix.Value + 5 > nud_NotDivisibleBySix.Value) chk_DivisibleBySix.CheckState = CheckState.Unchecked;
				else if (5 * nud_DivisibleBySix.Value > nud_NotDivisibleBySix.Value) chk_DivisibleBySix.CheckState = CheckState.Indeterminate;
				else chk_DivisibleBySix.CheckState = CheckState.Checked;

				nud_DivisibleBySeven.Value = stats.DivisibleBySeven;
				nud_NotDivisibleBySeven.Value = stats.NotDivisibleByFive;
				if (6 * nud_DivisibleBySeven.Value + 5 > nud_NotDivisibleBySeven.Value) chk_DivisibleBySeven.CheckState = CheckState.Unchecked;
				else if (6 * nud_DivisibleBySeven.Value > nud_NotDivisibleBySeven.Value) chk_DivisibleBySeven.CheckState = CheckState.Indeterminate;
				else chk_DivisibleBySeven.CheckState = CheckState.Checked;

				nud_DivisibleByEight.Value = stats.DivisibleByEight;
				nud_NotDivisibleByEight.Value = stats.NotDivisibleByEight;
				if (7 * nud_DivisibleByEight.Value + 5 > nud_NotDivisibleByEight.Value) chk_DivisibleByEight.CheckState = CheckState.Unchecked;
				else if (7 * nud_DivisibleByEight.Value > nud_NotDivisibleByEight.Value) chk_DivisibleByEight.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByEight.CheckState = CheckState.Checked;

				nud_DivisibleByNine.Value = stats.DivisibleByNine;
				nud_NotDivisibleByNine.Value = stats.NotDivisibleByNine;
				if (8 * nud_DivisibleByNine.Value + 5 > nud_NotDivisibleByNine.Value) chk_DivisibleByNine.CheckState = CheckState.Unchecked;
				else if (8 * nud_DivisibleByNine.Value > nud_NotDivisibleByNine.Value) chk_DivisibleByNine.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByNine.CheckState = CheckState.Checked;
			}
			catch (Exception ex)
			{
				ErrorBox.Show(ex);
			}
		}
	}
}
