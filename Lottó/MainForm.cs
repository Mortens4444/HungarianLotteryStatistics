using System;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Globalization;
using System.Collections.Generic;
using MessageBoxes;
using System.Linq;
using System.Drawing;

namespace Lottó
{
	public partial class MainForm : Form
	{
		private string fileName;
		private Statistics statistics;

		public MainForm()
		{
			InitializeComponent();
			cb_StatisticsFile.SelectedIndex = 0;
		}

		private void Cb_StatisticsFile_SelectedIndexChanged(object sender, EventArgs e)
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

		private void Btn_Download_Click(object sender, EventArgs e)
		{
			fileName = Path.Combine(Application.StartupPath, cb_StatisticsFile.Text.Substring(cb_StatisticsFile.Text.LastIndexOf('/') + 1));
            FileDownloader.DownloadFileAsync(cb_StatisticsFile.Text, fileName, Completed);
		}

		private void Completed(object sender, AsyncCompletedEventArgs e)
		{
			GetStatistics((byte)nud_MinValue.Value, (byte)nud_MaxValue.Value, (byte)nud_NumberCount.Value);
		}

		private void Btn_Statistics_Click(object sender, EventArgs e)
		{
			fileName = Path.Combine(Application.StartupPath, cb_StatisticsFile.Text.Substring(cb_StatisticsFile.Text.LastIndexOf('/') + 1));
			GetStatistics((byte)nud_MinValue.Value, (byte)nud_MaxValue.Value, (byte)nud_NumberCount.Value);
		}

		private void GetStatistics(byte min_value, byte max_value, byte number_count)
		{
			try
			{
				lvDrawings.Items.Clear();
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
						var item = new ListViewItem(draw.DrawingDate.ToShortDateString());
						foreach (var number in draw.Numbers)
						{
							item.SubItems.Add(number.ToString());
						}
						lvDrawings.Items.Add(item);
					}
				}

				statistics = new Statistics(min_value, max_value, drawings);

				nud_Even.Value = statistics.Even;
				nud_Odd.Value = statistics.Odd;
				if (nud_Even.Value + 5 > nud_Odd.Value) chk_Even.CheckState = CheckState.Unchecked;
				else if (nud_Even.Value > nud_Odd.Value) chk_Even.CheckState = CheckState.Indeterminate;
				else chk_Even.CheckState = CheckState.Checked;

				nud_DivisibleByThree.Value = statistics.DivisibleByThree;
				nud_NotDivisibleByThree.Value = statistics.NotDivisibleByThree;
				if (2 * nud_DivisibleByThree.Value + 5 > nud_NotDivisibleByThree.Value) chk_DivisibleByThree.CheckState = CheckState.Unchecked;
				else if (2 * nud_DivisibleByThree.Value > nud_NotDivisibleByThree.Value) chk_DivisibleByThree.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByThree.CheckState = CheckState.Checked;

				nud_DivisibleByFour.Value = statistics.DivisibleByFour;
				nud_NotDivisibleByFour.Value = statistics.NotDivisibleByFour;
				if (3 * nud_DivisibleByFour.Value + 5 > nud_NotDivisibleByFour.Value) chk_DivisibleByFour.CheckState = CheckState.Unchecked;
				else if (3 * nud_DivisibleByFour.Value > nud_NotDivisibleByFour.Value) chk_DivisibleByFour.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByFour.CheckState = CheckState.Checked;

				nud_DivisibleByFive.Value = statistics.DivisibleByFive;
				nud_NotDivisibleByFive.Value = statistics.NotDivisibleByFive;
				if (4 * nud_DivisibleByFive.Value + 5 > nud_NotDivisibleByFive.Value) chk_DivisibleByFive.CheckState = CheckState.Unchecked;
				else if (4 * nud_DivisibleByFive.Value > nud_NotDivisibleByFive.Value) chk_DivisibleByFive.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByFive.CheckState = CheckState.Checked;

				nud_DivisibleBySix.Value = statistics.DivisibleBySix;
				nud_NotDivisibleBySix.Value = statistics.NotDivisibleBySix;
				if (5 * nud_DivisibleBySix.Value + 5 > nud_NotDivisibleBySix.Value) chk_DivisibleBySix.CheckState = CheckState.Unchecked;
				else if (5 * nud_DivisibleBySix.Value > nud_NotDivisibleBySix.Value) chk_DivisibleBySix.CheckState = CheckState.Indeterminate;
				else chk_DivisibleBySix.CheckState = CheckState.Checked;

				nud_DivisibleBySeven.Value = statistics.DivisibleBySeven;
				nud_NotDivisibleBySeven.Value = statistics.NotDivisibleByFive;
				if (6 * nud_DivisibleBySeven.Value + 5 > nud_NotDivisibleBySeven.Value) chk_DivisibleBySeven.CheckState = CheckState.Unchecked;
				else if (6 * nud_DivisibleBySeven.Value > nud_NotDivisibleBySeven.Value) chk_DivisibleBySeven.CheckState = CheckState.Indeterminate;
				else chk_DivisibleBySeven.CheckState = CheckState.Checked;

				nud_DivisibleByEight.Value = statistics.DivisibleByEight;
				nud_NotDivisibleByEight.Value = statistics.NotDivisibleByEight;
				if (7 * nud_DivisibleByEight.Value + 5 > nud_NotDivisibleByEight.Value) chk_DivisibleByEight.CheckState = CheckState.Unchecked;
				else if (7 * nud_DivisibleByEight.Value > nud_NotDivisibleByEight.Value) chk_DivisibleByEight.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByEight.CheckState = CheckState.Checked;

				nud_DivisibleByNine.Value = statistics.DivisibleByNine;
				nud_NotDivisibleByNine.Value = statistics.NotDivisibleByNine;
				if (8 * nud_DivisibleByNine.Value + 5 > nud_NotDivisibleByNine.Value) chk_DivisibleByNine.CheckState = CheckState.Unchecked;
				else if (8 * nud_DivisibleByNine.Value > nud_NotDivisibleByNine.Value) chk_DivisibleByNine.CheckState = CheckState.Indeterminate;
				else chk_DivisibleByNine.CheckState = CheckState.Checked;

				RecolorItems();
			}
			catch (Exception ex)
			{
				ErrorBox.Show(ex);
			}
		}

		private void RecolorItems()
		{
			if (statistics == null)
			{
				return;
			}

			rtb_LeastFrequentNumbers.Text = Statistics.ArrayToString(statistics.LeastFrequentNumbers);
			var count = (int)nudGroupCount.Value;
			var index = rtb_LeastFrequentNumbers.Text.XThIndexOf(',', count);
			rtb_LeastFrequentNumbers.Text = rtb_LeastFrequentNumbers.Text.Insert(index, $"{Environment.NewLine}{Environment.NewLine}");

			index = rtb_LeastFrequentNumbers.Text.XThIndexOf(',', 2 * count);
			rtb_LeastFrequentNumbers.Text = rtb_LeastFrequentNumbers.Text.Insert(index, $"{Environment.NewLine}{Environment.NewLine}");

			index = rtb_LeastFrequentNumbers.Text.XThIndexOf(',', (statistics.LeastFrequentNumbers.Length) - 2 * count);
			rtb_LeastFrequentNumbers.Text = rtb_LeastFrequentNumbers.Text.Insert(index, $"{Environment.NewLine}{Environment.NewLine}");

			index = rtb_LeastFrequentNumbers.Text.XThIndexOf(',', (statistics.LeastFrequentNumbers.Length) - count);
			rtb_LeastFrequentNumbers.Text = rtb_LeastFrequentNumbers.Text.Insert(index, $"{Environment.NewLine}{Environment.NewLine}");

			var groups = rtb_LeastFrequentNumbers.Text.SplitOnNewLines(StringSplitOptions.RemoveEmptyEntries);
			foreach (var group in groups)
			{
				rtb_LeastFrequentNumbers.Text = rtb_LeastFrequentNumbers.Text.Replace(group, group.Trim(',', ' '));
			}

			var leastFrequentNumbers = statistics.LeastFrequentNumbers.Take(count).ToList();
			var leastFrequentNumbers2 = statistics.LeastFrequentNumbers.Skip(count).Take(count).ToList();
			var frequentNumbers = statistics.LeastFrequentNumbers.Skip(statistics.LeastFrequentNumbers.Length - count).ToList();
			var frequentNumbers2 = statistics.LeastFrequentNumbers.Skip(statistics.LeastFrequentNumbers.Length - (2 * count)).Take(count).ToList();

			foreach (ListViewItem item in lvDrawings.Items)
			{
				for (int i = 1; i < item.SubItems.Count; i++)
				{
					var number = Convert.ToByte(item.SubItems[i].Text);
					if (frequentNumbers.Contains(number))
					{
						item.SubItems[i].BackColor = Color.Red;
						item.SubItems[i].ForeColor = Color.White;
					}
					else if (leastFrequentNumbers.Contains(number))
					{
						item.SubItems[i].BackColor = Color.Blue;
						item.SubItems[i].ForeColor = Color.White;
					}
					else if (frequentNumbers2.Contains(number))
					{
						item.SubItems[i].BackColor = Color.Orange;
						item.SubItems[i].ForeColor = Color.White;
					}
					else if (leastFrequentNumbers2.Contains(number))
					{
						item.SubItems[i].BackColor = Color.Green;
						item.SubItems[i].ForeColor = Color.White;
					}
					else
					{
						item.SubItems[i].BackColor = lvDrawings.BackColor;
						item.SubItems[i].ForeColor = lvDrawings.ForeColor;
					}
					item.UseItemStyleForSubItems = false;
				}
			}
		}

		private void Nud_MaxValue_ValueChanged(object sender, EventArgs e)
		{
			nudGroupCount.Maximum = Math.Truncate(nud_MaxValue.Value / 4);
			nudGroupCount.Value = nudGroupCount.Maximum;
		}

		private void NudGroupCount_ValueChanged(object sender, EventArgs e)
		{
			RecolorItems();
		}
	}
}
