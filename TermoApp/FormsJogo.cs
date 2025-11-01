using System.Media;
using TermoLib;

namespace TermoApp
{
    public partial class FormsJogo : Form
    {

        private Dictionary<string, Stream> soundMap;
        private FormsPlacar formsPlacar;
        private FormsHelp formsHelp;
        public termo termo;
        int coluna = 1;

        public FormsJogo()
        {
            InitializeComponent();
            GPBteclado.Paint += GroupBox_Paint;
            GPBbutton.Paint += GroupBox_Paint;
            InicializarSons();
            termo = new termo();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BtnTeclado_KeyDown);

        }

        #region Tabuleiro e Teclado
        private Button RetornaBotao(string name)
        {
            var found = Controls.Find(name, true);
            if (found.Length == 0)
            {
                return null;
            }
            return found[0] as Button;
        }

        private void AtualizaTabuleiro()
        {
            if (termo.palavraAtual < 2) return;

            int linhaIndex = termo.palavraAtual - 2;
            if (linhaIndex < 0 || linhaIndex >= termo.tabuleiro.Count) return;

            for (int col = 1; col <= 5; col++)
            {
                var letra = termo.tabuleiro[linhaIndex][col - 1];

                var nomeBotaoTab = $"btn{termo.palavraAtual - 1}{col}";
                var botaoTab = RetornaBotao(nomeBotaoTab);
                if (botaoTab == null) continue;

                var nomeBotaoKey = $"btn{letra.Caracter}";
                var botaoKey = RetornaBotao(nomeBotaoKey);

                if (letra.Cor == 'V')
                {
                    botaoTab.BackColor = ColorTranslator.FromHtml("#8f9044");
                    if (botaoKey != null) botaoKey.BackColor = ColorTranslator.FromHtml("#8f9044");
                }
                else if (letra.Cor == 'A')
                {
                    botaoTab.BackColor = ColorTranslator.FromHtml("#f8a523");
                    if (botaoKey != null && botaoKey.BackColor != ColorTranslator.FromHtml("#8f9044"))
                        botaoKey.BackColor = ColorTranslator.FromHtml("#f8a523");
                }
                else
                {
                    botaoTab.BackColor = BtnHelp.BackColor;
                    if (botaoKey != null && BtnHelp.ForeColor == Color.FromArgb(18, 18, 18))
                    {
                        botaoKey.ForeColor = Color.FromArgb(191, 191, 191);
                    }
                    else
                    {
                        botaoKey.ForeColor = ColorTranslator.FromHtml("#352f3d");
                    }
                }
            }
        }

        private void BtnTeclado_KeyDown(object sender, KeyEventArgs e)
        {

            if (termo.JogoFinalizado)
            {
                e.SuppressKeyPress = true;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Button btnEnterVirtual = RetornaBotao("btnENTER");
                if (btnEnterVirtual != null)
                {
                    BtnENTER_Click(btnEnterVirtual, EventArgs.Empty);
                }
            }
            if (e.KeyCode == Keys.Back)
            {
                BtnDelete_Click(btnDelete, EventArgs.Empty);
            }
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                PressionarBotaoVirtual(e.KeyCode);
            }

            e.SuppressKeyPress = true;
        }

        private void PressionarBotaoVirtual(Keys tecla)
        {
            string letra = tecla.ToString();

            foreach (Control c in GPBteclado.Controls)
            {
                if (c is Button btn && btn.Name == "btn" + letra)
                {
                    btn.PerformClick();
                    break;
                }
            }
        }

        private void BtnTeclado_Click(object sender, EventArgs e)
        {
            if (termo.JogoFinalizado) return;

            var button = (Button)sender;
            var nomeButton = $"btn{termo.palavraAtual}{coluna}";
            var buttonTabuleiro = RetornaBotao(nomeButton);

            if(buttonTabuleiro.Text == "")
            {
                buttonTabuleiro.Text = button.Text;
            } 

            if (coluna < 5)
            {
                coluna++;
            }
        }

        private void btnTabuleiro_Click(object sender, EventArgs e)
        {
            var botaoClicado = (Button)sender;
            var nomeBotao = botaoClicado.Name;

            int linhaDesejada = int.Parse(nomeBotao.Substring(3, 1));
            int colunaDesejada = int.Parse(nomeBotao.Substring(4, 1));

            if (linhaDesejada == termo.palavraAtual)
            {
                coluna = colunaDesejada;
                botaoClicado.Focus();
            }
        }

        #endregion

        #region Botões
        private void BtnENTER_Click(object sender, EventArgs e)
        {
            lblAvisos.Visible = false;
            var palavra = string.Empty;
            bool todosPreenchidos = true;

            for (int i = 1; i <= 5; i++)
            {
                var nomeBotao = $"btn{termo.palavraAtual}{i}";
                var botao = RetornaBotao(nomeBotao);
                if (botao == null || string.IsNullOrWhiteSpace(botao.Text))
                {
                    todosPreenchidos = false;
                    break;
                }
                palavra += botao.Text;
            }

            if (!todosPreenchidos)
            {
                TocarSom("Error");
                lblAvisos.Text = "Digite uma palavra válida com 5 letras";
                lblAvisos.Visible = true;
                return;
            }

            try
            {
                termo.ChecaPalavra(palavra);
            }
            catch (Exception ex)
            {
                TocarSom("Error");
                lblAvisos.Text = ex.Message.Contains("dicionário")
            ? "Palavra inválida! Não está no dicionário."
            : "Erro ao checar palavra: " + ex.Message;
                lblAvisos.Visible = true;
                return;
            }

            AtualizaTabuleiro();
            TocarSom("Click");
            coluna = 1;

            if (termo.JogoFinalizado)
            {
                AparecerAvisos();
                termo.contadorAcertos++;
            }
            else if (termo.palavraAtual > 6)
            {
                AparecerAvisos();
                termo.contadorErros++;
            }
            else
            {
                RetornaBotao($"btn{termo.palavraAtual}{coluna}").Focus();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            if (termo.JogoFinalizado) return;

            var botaoUltimo = RetornaBotao($"btn{termo.palavraAtual}{5}");

            if (coluna == 1 && botaoUltimo != null && !string.IsNullOrWhiteSpace(botaoUltimo.Text))
            {
                coluna = 5;
            }

            if (coluna < 1) return;

            var nomeBotao = $"btn{termo.palavraAtual}{coluna}";
            var botao = RetornaBotao(nomeBotao);

            if (!string.IsNullOrWhiteSpace(botao.Text))
            {
                botao.Text = "";
                botao.Focus();

                if (coluna > 1)
                {
                    coluna--;
                }
            }
            else if (coluna > 1)
            {
                coluna--;
                nomeBotao = $"btn{termo.palavraAtual}{coluna}";
                botao = RetornaBotao(nomeBotao);
                botao.Text = "";
                botao.Focus();
            }
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            lblAvisos.Visible = false;
            pictureBoxWin1.Visible = false;
            pictureBoxWin2.Visible = false;
            termo.ReiniciarJogo();
            for (int linha = 1; linha <= 6; linha++)
            {
                for (int col = 1; col <= 5; col++)
                {
                    var nomeBotao = $"btn{linha}{col}";
                    var btn = RetornaBotao(nomeBotao);
                    btn.Text = "";
                    btn.BackColor = BtnHelp.BackColor;
                    btn.ForeColor = BtnHelp.ForeColor;
                    btn.FlatAppearance.BorderColor = BtnHelp.BackColor;
                }
            }

            foreach (Control c in GPBteclado.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = BtnHelp.BackColor;
                    btn.ForeColor = BtnHelp.ForeColor;
                    btn.FlatAppearance.BorderColor = BtnHelp.BackColor;
                }
            }
            RetornaBotao("btn11").Focus();
        }

        private void BtnPlacar_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            if (formsPlacar == null || formsPlacar.IsDisposed)
            {
                formsPlacar = new FormsPlacar(this.termo);
                formsPlacar.Show();
                formsPlacar.AtualizarPlacar(termo.contadorAcertos, termo.contadorErros, termo.contadorTentativas);
                formsPlacar.Activate();
            }

            else
            {
                formsPlacar.Close();
                formsPlacar = null;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            if (formsHelp == null || formsHelp.IsDisposed)
            {
                formsHelp = new FormsHelp(this.termo);
                formsHelp.Show();
                formsHelp.Activate();
            }
            else
            {
                formsHelp.Close();
                formsHelp = null;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            this.Close();
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = ColorTranslator.FromHtml("#ff2c2c");
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = BtnHelp.BackColor;
        }

        private void BtnLightMode_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            MudarModoClaro();
        }

        private void BtnDarkMode_Click(object sender, EventArgs e)
        {
            TocarSom("Click");
            MudarModoEscuro();
        }
        #endregion

        #region Sons e Modos
        private void AparecerAvisos()
        {
            TocarSom("Error");
            if (termo.JogoFinalizado == true)
            {

                pictureBoxWin1.Image = Properties.Resources.Win;
                pictureBoxWin2.Image = Properties.Resources.Win;
                pictureBoxWin1.Visible = true;
                pictureBoxWin2.Visible = true;
                lblAvisos.Text = "Parabéns! Você acertou a palavra e deixou o Valtemir feliz! Clique em 🗘 para jogar novamente!";
                lblAvisos.Visible = true;
                TocarSom("Win");
            }
            else if (termo.palavraAtual > 6)
            {
                pictureBoxWin1.Image = Properties.Resources.Lose;
                pictureBoxWin2.Image = Properties.Resources.Lose;
                pictureBoxWin1.Visible = true;
                pictureBoxWin2.Visible = true;
                lblAvisos.Text = $"Que pena, Você errou e decepcionou o Murilo! A palavra sorteada era {termo.palavraSorteada}! Clique em 🗘 para jogar novamente!";
                lblAvisos.Visible = true;
                TocarSom("Lose");
            }
        }

        private void InicializarSons()
        {
            soundMap = new Dictionary<string, Stream>
            {
            {"Win",   Properties.Resources.Win_sound},
            {"Lose",  Properties.Resources.Lose_sound},
            {"Click", Properties.Resources.a},
            {"Error", Properties.Resources.Error_sound }
            };
        }

        public void TocarSom(string key)
        {
            if (soundMap.TryGetValue(key, out Stream stream))
            {
                if (stream.CanSeek)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                }

                using SoundPlayer player = new(stream);
                player.Stream = stream;
                player.Play();
            }
        }

        private void MudarModoClaro()
        {
            termo.isDarkMode = false;
            BtnDarkMode.Enabled = true;
            Color foreColor = Color.FromArgb(18, 18, 18);
            Color backColor = Color.FromArgb(230, 223, 237);
            
            //componentes soltos do formsjogo
            this.BackColor = SystemColors.ButtonFace;
            lblTitulo.ForeColor = foreColor;
            lblAvisos.ForeColor = foreColor;
            lblAvisos.BackColor = backColor;

            BtnHelp.ForeColor = foreColor;
            BtnHelp.BackColor = backColor;
            BtnHelp.FlatAppearance.BorderColor = backColor;

            BtnPlacar.ForeColor = foreColor;
            BtnPlacar.BackColor = backColor;
            BtnPlacar.FlatAppearance.BorderColor = backColor;

            BtnReiniciar.ForeColor = foreColor;
            BtnReiniciar.BackColor = backColor;
            BtnReiniciar.FlatAppearance.BorderColor = backColor;

            btnClose.ForeColor = foreColor;
            btnClose.BackColor = backColor;
            btnClose.FlatAppearance.BorderColor = backColor;

            BtnDarkMode.ForeColor = foreColor;
            BtnDarkMode.BackColor = Color.Transparent;
            BtnDarkMode.FlatAppearance.BorderColor = backColor;
            BtnDarkMode.Text = "🌙";

            BtnLightMode.ForeColor = foreColor;
            BtnLightMode.BackColor = backColor;
            BtnLightMode.FlatAppearance.BorderColor = backColor;
            BtnLightMode.Text = string.Empty;
            BtnLightMode.Enabled = false;

            //botões dos groupbox
            foreach (Control c in GPBteclado.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.BackColor != ColorTranslator.FromHtml("#8f9044") && btn.BackColor != ColorTranslator.FromHtml("#f8a523"))
                    {
                        btn.BackColor = backColor;
                    } 
                    else
                    {
                        btn.BackColor = btn.BackColor;
                    }

                    if(btn.ForeColor == ColorTranslator.FromHtml("#352f3d"))
                    {
                        btn.ForeColor = Color.FromArgb(191, 191, 191);
                    }
                    else
                    {
                        btn.ForeColor = foreColor;
                    }
                    btn.FlatAppearance.BorderColor = btn.BackColor;
                }
            }

            foreach (Control c in GPBbutton.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.BackColor != ColorTranslator.FromHtml("#8f9044") && btn.BackColor != ColorTranslator.FromHtml("#f8a523"))
                    {
                        btn.BackColor = backColor;
                    }
                    else
                    {
                        btn.BackColor = btn.BackColor;
                    }

                    if (btn.ForeColor == ColorTranslator.FromHtml("#352f3d"))
                    {
                        btn.ForeColor = Color.FromArgb(191, 191, 191);
                    }
                    else
                    {
                        btn.ForeColor = foreColor;
                    }
                    btn.FlatAppearance.BorderColor = btn.BackColor;
                }
            }

            //forms diferentes
            if (formsPlacar != null && !formsPlacar.IsDisposed)
            {
                formsPlacar.MudarModoForms();
            }

            if (formsHelp != null && !formsHelp.IsDisposed)
            {
                formsHelp.MudarModoForms();
            }
        }

        private void MudarModoEscuro()
        {
            termo.isDarkMode = true;
            BtnLightMode.Enabled = true;
            Color foreColor = SystemColors.ButtonFace;
            Color backColor = Color.FromArgb(24, 24, 24);
            Color formBackColor = Color.FromArgb(18, 18, 18);

            this.BackColor = formBackColor;
            lblTitulo.ForeColor = foreColor;
            lblAvisos.ForeColor = foreColor;
            lblAvisos.BackColor = backColor;

            BtnHelp.ForeColor = foreColor;
            BtnHelp.BackColor = backColor;
            BtnHelp.FlatAppearance.BorderColor = backColor;

            BtnPlacar.ForeColor = foreColor;
            BtnPlacar.BackColor = backColor;
            BtnPlacar.FlatAppearance.BorderColor = backColor;

            BtnReiniciar.ForeColor = foreColor;
            BtnReiniciar.BackColor = backColor;
            BtnReiniciar.FlatAppearance.BorderColor = backColor;

            btnClose.ForeColor = foreColor;
            btnClose.BackColor = backColor; ;
            btnClose.FlatAppearance.BorderColor = backColor;

            BtnDarkMode.ForeColor = foreColor;
            BtnDarkMode.BackColor = backColor;
            BtnDarkMode.Enabled = false;
            BtnDarkMode.Text = string.Empty;
            BtnDarkMode.BackColor = backColor;
            BtnDarkMode.FlatAppearance.BorderColor = backColor;

            BtnLightMode.ForeColor = foreColor;
            BtnLightMode.BackColor = formBackColor;
            BtnLightMode.BackColor = formBackColor;
            BtnLightMode.Text = "💡";
            BtnLightMode.FlatAppearance.BorderColor = backColor;

            foreach (Control c in GPBteclado.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.BackColor != ColorTranslator.FromHtml("#8f9044") && btn.BackColor != ColorTranslator.FromHtml("#f8a523"))
                    {
                        btn.BackColor = backColor;
                    }
                    else
                    {
                        btn.BackColor = btn.BackColor;
                    }

                    if (btn.ForeColor == Color.FromArgb(191, 191, 191))
                    {
                        btn.ForeColor = ColorTranslator.FromHtml("#352f3d");
                    }
                    else
                    {
                        btn.ForeColor = foreColor;
                    }
                    btn.FlatAppearance.BorderColor = btn.BackColor;
                }
            }

            foreach (Control c in GPBbutton.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.BackColor != ColorTranslator.FromHtml("#8f9044") && btn.BackColor != ColorTranslator.FromHtml("#f8a523"))
                    {
                        btn.BackColor = backColor;
                    }
                    else
                    {
                        btn.BackColor = btn.BackColor;
                    }

                    if (btn.ForeColor == Color.FromArgb(191, 191, 191))
                    {
                        btn.ForeColor = ColorTranslator.FromHtml("#352f3d");
                    }
                    else
                    {
                        btn.ForeColor = foreColor;
                    }
                    btn.FlatAppearance.BorderColor = btn.BackColor;
                }
            }

            //forms diferentes
            if (formsPlacar != null && !formsPlacar.IsDisposed)
            {
                formsPlacar.MudarModoForms();
            }

            if (formsHelp != null && !formsHelp.IsDisposed)
            {
                formsHelp.MudarModoForms();
            }
        }

        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = (GroupBox)sender;
            e.Graphics.Clear(this.BackColor);

            TextRenderer.DrawText(
               e.Graphics,
               box.Text,
               box.Font,
               new Point(10, 0),
               box.ForeColor
           );
        }
        #endregion
    }
}
