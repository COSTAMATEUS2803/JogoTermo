namespace TermoApp
{
    partial class FormsPlacar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormsPlacar));
            lblPlacar = new Label();
            lblQtdWins = new Label();
            lblQntLoses = new Label();
            lblQtdTentativas = new Label();
            lblEmojiWin = new Label();
            lblEmojiLose = new Label();
            lblDerrotas = new Label();
            lblVitorias = new Label();
            lblTentativas = new Label();
            SuspendLayout();
            // 
            // lblPlacar
            // 
            lblPlacar.AutoSize = true;
            lblPlacar.BackColor = Color.Transparent;
            lblPlacar.Font = new Font("Franklin Gothic Medium", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlacar.ForeColor = Color.WhiteSmoke;
            lblPlacar.Location = new Point(250, 28);
            lblPlacar.Name = "lblPlacar";
            lblPlacar.Size = new Size(267, 81);
            lblPlacar.TabIndex = 33;
            lblPlacar.Text = "PLACAR";
            // 
            // lblQtdWins
            // 
            lblQtdWins.AutoSize = true;
            lblQtdWins.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQtdWins.ForeColor = Color.WhiteSmoke;
            lblQtdWins.Location = new Point(38, 137);
            lblQtdWins.Name = "lblQtdWins";
            lblQtdWins.Size = new Size(298, 24);
            lblQtdWins.TabIndex = 34;
            lblQtdWins.Text = "Qtd. Palavras acertadas:";
            // 
            // lblQntLoses
            // 
            lblQntLoses.AutoSize = true;
            lblQntLoses.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQntLoses.ForeColor = Color.WhiteSmoke;
            lblQntLoses.Location = new Point(428, 137);
            lblQntLoses.Name = "lblQntLoses";
            lblQntLoses.Size = new Size(274, 24);
            lblQntLoses.TabIndex = 35;
            lblQntLoses.Text = "Qtd. Palavras erradas:";
            // 
            // lblQtdTentativas
            // 
            lblQtdTentativas.AutoSize = true;
            lblQtdTentativas.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQtdTentativas.ForeColor = Color.WhiteSmoke;
            lblQtdTentativas.Location = new Point(250, 344);
            lblQtdTentativas.Name = "lblQtdTentativas";
            lblQtdTentativas.Size = new Size(202, 24);
            lblQtdTentativas.TabIndex = 36;
            lblQtdTentativas.Text = "Qtd. tentativas:";
            // 
            // lblEmojiWin
            // 
            lblEmojiWin.AutoSize = true;
            lblEmojiWin.Font = new Font("Consolas", 70F, FontStyle.Bold);
            lblEmojiWin.ForeColor = Color.WhiteSmoke;
            lblEmojiWin.Location = new Point(12, 172);
            lblEmojiWin.Name = "lblEmojiWin";
            lblEmojiWin.Size = new Size(156, 110);
            lblEmojiWin.TabIndex = 37;
            lblEmojiWin.Text = "\U0001f947";
            // 
            // lblEmojiLose
            // 
            lblEmojiLose.AutoSize = true;
            lblEmojiLose.Font = new Font("Consolas", 70F, FontStyle.Bold);
            lblEmojiLose.ForeColor = Color.WhiteSmoke;
            lblEmojiLose.Location = new Point(390, 172);
            lblEmojiLose.Name = "lblEmojiLose";
            lblEmojiLose.Size = new Size(156, 110);
            lblEmojiLose.TabIndex = 38;
            lblEmojiLose.Text = "💀";
            // 
            // lblDerrotas
            // 
            lblDerrotas.AutoSize = true;
            lblDerrotas.Font = new Font("Consolas", 70F, FontStyle.Bold);
            lblDerrotas.ForeColor = Color.WhiteSmoke;
            lblDerrotas.Location = new Point(546, 172);
            lblDerrotas.Name = "lblDerrotas";
            lblDerrotas.Size = new Size(99, 110);
            lblDerrotas.TabIndex = 39;
            lblDerrotas.Text = "0";
            // 
            // lblVitorias
            // 
            lblVitorias.AutoSize = true;
            lblVitorias.Font = new Font("Consolas", 70F, FontStyle.Bold);
            lblVitorias.ForeColor = Color.WhiteSmoke;
            lblVitorias.Location = new Point(155, 172);
            lblVitorias.Name = "lblVitorias";
            lblVitorias.Size = new Size(99, 110);
            lblVitorias.TabIndex = 40;
            lblVitorias.Text = "0";
            // 
            // lblTentativas
            // 
            lblTentativas.AutoSize = true;
            lblTentativas.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTentativas.ForeColor = Color.WhiteSmoke;
            lblTentativas.Location = new Point(458, 344);
            lblTentativas.Name = "lblTentativas";
            lblTentativas.Size = new Size(22, 24);
            lblTentativas.TabIndex = 41;
            lblTentativas.Text = "0";
            // 
            // FormsPlacar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 12);
            ClientSize = new Size(750, 400);
            Controls.Add(lblTentativas);
            Controls.Add(lblVitorias);
            Controls.Add(lblDerrotas);
            Controls.Add(lblEmojiLose);
            Controls.Add(lblEmojiWin);
            Controls.Add(lblQtdTentativas);
            Controls.Add(lblQntLoses);
            Controls.Add(lblQtdWins);
            Controls.Add(lblPlacar);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormsPlacar";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Termo";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlacar;
        private Label lblQtdWins;
        private Label lblQntLoses;
        private Label lblQtdTentativas;
        private Label lblEmojiWin;
        private Label lblEmojiLose;
        private Label lblDerrotas;
        private Label lblVitorias;
        private Label lblTentativas;
    }
}