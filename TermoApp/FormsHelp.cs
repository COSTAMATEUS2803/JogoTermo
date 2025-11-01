using TermoLib;

namespace TermoApp
{
    public partial class FormsHelp : Form
    {
        private termo termo;

        public FormsHelp(termo termoInstancia)
        {
            InitializeComponent();
            this.termo = termoInstancia;
            MudarModoForms();
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
            this.BackColor = Color.Black;
            Color foreColor = SystemColors.ButtonFace;
            Color backColor = Color.FromArgb(24, 24, 24);

            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = foreColor;
                }
            }

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.ForeColor = foreColor;
                    btn.FlatAppearance.BorderColor = backColor;

                    if (btn.BackColor != ColorTranslator.FromHtml("#8f9044") && btn.BackColor != ColorTranslator.FromHtml("#f8a523"))
                    {
                        btn.BackColor = backColor;
                        btn.ForeColor = foreColor;
                    }
                }
            }
            btnHelp7.ForeColor = Color.FromArgb(53, 47, 61);
            btnHelp10.ForeColor = Color.FromArgb(53, 47, 61);
            btnHelp13.ForeColor = Color.FromArgb(53, 47, 61);
            lblHelp5.Text = "Preto indica que a letra não faz parte da palavra!";
        }

        public void MudarModoClaro()
        {
            this.BackColor = Color.White;
            Color foreColor = Color.FromArgb(18, 18, 18);
            Color backColor = Color.FromArgb(230, 223, 237);

            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = foreColor;
                }
            }

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.ForeColor = foreColor;
                    btn.FlatAppearance.BorderColor = backColor;

                    if (btn.BackColor != ColorTranslator.FromHtml("#8f9044") && btn.BackColor != ColorTranslator.FromHtml("#f8a523"))
                    {
                        btn.BackColor = backColor;
                    }
                }
            }

            btnHelp7.ForeColor = Color.FromArgb(191, 191, 191);
            btnHelp10.ForeColor = Color.FromArgb(191, 191, 191);
            btnHelp13.ForeColor = Color.FromArgb(191, 191, 191);
            lblHelp5.Text = "Cinza indica que a letra não faz parte da palavra!";
        }
    }
}
