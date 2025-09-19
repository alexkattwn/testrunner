using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TestRunner.Tests;

namespace TestRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbTests.Items.Add("Первый тест");
            cmbTests.Items.Add("Второй тест");
            cmbTests.Items.Add("Третий тест");
            cmbTests.SelectedIndex = 0;

            UpdateStatus("Ожидается ввод");

            btnStop.Enabled = false;
        }

        private ITest CreateTestByIndex(int index)
        {
            switch (index)
            {
                case 0: return new FirstTest();
                case 1: return new SecondTest();
                case 2: return new ThirdTest();
                default: return null;
            }
        }

        private CancellationTokenSource _cts;

        private void UpdateStatus(string text) => lblStatus.Text = "Статус: " + text;


        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbProductId.Text))
            {
                MessageBox.Show("Введите ID изделия");
                return;
            }

            var test = CreateTestByIndex(cmbTests.SelectedIndex);
            if (test == null) return;

            _cts = new CancellationTokenSource();

            lblStatus.Text = "Идет тестирование...";     
            progressBar.Value = 0;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            txbProductId.Enabled = false;
            cmbTests.Enabled = false;
            txbLog.Clear();

            var log = new Progress<string>(msg => txbLog.AppendText(msg + Environment.NewLine));
            var prog = new Progress<int>(p => progressBar.Value = p);

            var result = await test.RunAsync(txbProductId.Text, _cts.Token, log, prog);

            if (result.Cancelled)
            {
                lblStatus.Text = "Тест отменён";
            }
            else
            {
                lblStatus.Text = result.Success ? "Тест успешен" : "Ошибка в тесте";
                SaveResultToFile(result, txbProductId.Text);
            }

            btnStop.Enabled = false;
            btnStart.Enabled = true;
            txbProductId.Enabled = true;
            cmbTests.Enabled = true;
        }

        private void SaveResultToFile(TestResult result, string productId)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
            Directory.CreateDirectory(dir);
            string path = Path.Combine(dir, $"{productId}.txt");

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine($"Тест: {result.TestName}");
                sw.WriteLine($"Начало: {result.Start}");
                sw.WriteLine($"Окончание: {result.End}");
                sw.WriteLine($"Результат: {(result.Success ? "Успешно" : "Ошибка")}");
                if (!result.Success) sw.WriteLine($"Ошибка: {result.ErrorName}");
                sw.WriteLine("Данные:");
                foreach (var kv in result.Data)
                    sw.WriteLine($"  {kv.Key}: {kv.Value}");
            }
        }
    }
}
