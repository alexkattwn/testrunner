namespace TestRunner
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbTests = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txbProductId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txbLog = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTests
            // 
            this.cmbTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbTests.FormattingEnabled = true;
            this.cmbTests.Location = new System.Drawing.Point(264, 72);
            this.cmbTests.Name = "cmbTests";
            this.cmbTests.Size = new System.Drawing.Size(356, 28);
            this.cmbTests.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(478, 369);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(142, 44);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Остановить";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txbProductId
            // 
            this.txbProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbProductId.Location = new System.Drawing.Point(264, 31);
            this.txbProductId.Name = "txbProductId";
            this.txbProductId.Size = new System.Drawing.Size(356, 27);
            this.txbProductId.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(156, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID изделия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(210, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Тест";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(160, 369);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 44);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(160, 119);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 23);
            this.progressBar.TabIndex = 9;
            // 
            // txbLog
            // 
            this.txbLog.Location = new System.Drawing.Point(160, 246);
            this.txbLog.Name = "txbLog";
            this.txbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txbLog.Size = new System.Drawing.Size(460, 96);
            this.txbLog.TabIndex = 10;
            this.txbLog.Text = "";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(156, 185);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 20);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Статус";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txbLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbProductId);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.cmbTests);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование изделий";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTests;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txbProductId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RichTextBox txbLog;
        private System.Windows.Forms.Label lblStatus;
    }
}

