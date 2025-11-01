using TermoLib;

namespace TermoApp
{
    public partial class FormsPlacar : Form
    {
        private termo termo;

        public FormsPlacar(termo termoInstancia)
        {
            InitializeComponent();
            this.termo = termoInstancia;
            MudarModoForms();
        }

        public void AtualizarPlacar(int vitorias, int derrotas, int tentativas)
        {
            lblVitorias.Text = vitorias.ToString();
            lblDerrotas.Text = derrotas.ToString();
            lblTentativas.Text = tentativas.ToString();
        }

        public void MudarModoForms()
        {
            if (termo.isDarkMode != true)
            {
                MudarModoClaro();
            }
            else
            {
                MudarModoEscuro();
            }
        }

        public void MudarModoEscuro()
        {
            Color foreColor = SystemColors.ButtonFace;
            this.BackColor = Color.Black;
            lblVitorias.ForeColor = foreColor;
            lblDerrotas.ForeColor = foreColor;
            lblTentativas.ForeColor = foreColor;
            lblPlacar.ForeColor = foreColor;
            lblQntLoses.ForeColor = foreColor;
            lblQtdWins.ForeColor = foreColor;
            lblEmojiWin.ForeColor = foreColor;
            lblEmojiLose.ForeColor = foreColor;
            lblQtdTentativas.ForeColor = foreColor;
        }

        public void MudarModoClaro()
        {

            Color foreColor = Color.FromArgb(18, 18, 18);
            this.BackColor = Color.White;
            lblVitorias.ForeColor = foreColor;
            lblDerrotas.ForeColor = foreColor;
            lblTentativas.ForeColor = foreColor;
            lblPlacar.ForeColor = foreColor;
            lblQntLoses.ForeColor = foreColor;
            lblQtdWins.ForeColor = foreColor;
            lblEmojiWin.ForeColor = foreColor;
            lblEmojiLose.ForeColor = foreColor;
            lblQtdTentativas.ForeColor = foreColor;
        }
    }
}
