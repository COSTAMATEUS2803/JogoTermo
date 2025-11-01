namespace TermoLib
{
    public class Letra
    {
        public Letra(char caracter, char cor)
        {
            Caracter = caracter;
            Cor = cor;
        }
        public char Caracter;
        public char Cor;
    }

    public class termo
    {
        public List<string> palavras;
        public string palavraSorteada;
        public List<List<Letra>> tabuleiro;
        public Dictionary<char, char> teclado;
        public int palavraAtual;
        public bool JogoFinalizado;
        public int contadorErros;
        public int contadorAcertos;
        public int contadorTentativas;
        public bool isDarkMode = true;

        
        public termo()
        {
            CarregaPalavras("Palavras.txt");
            SorteiaPalavra();
            palavraAtual = 1;
            JogoFinalizado = false;
            tabuleiro = new List<List<Letra>>();
            teclado = new Dictionary<char, char>();
            for(int i = 65; i <= 90; i++)
            {
                // Cinza - NÃO DIGITADO | Verde - POSIÇÃO CORRETA 
                // Amarelo - NA PALAVRA | Preto - NÃO FAZ PARTE  
                teclado.Add((char)i, 'C');
            }
        }

        #region Palavra
        public void CarregaPalavras(string fileName)
        {

            palavras = File.ReadAllLines(fileName).ToList();

        }
        
        public void SorteiaPalavra()
        {
            Random rdn = new Random();
            var index = rdn.Next(0, palavras.Count() - 1);
            palavraSorteada = palavras[index];
        }

        public void ChecaPalavra(string palavra){
            if (palavra == palavraSorteada){
                JogoFinalizado = true;
            }

            if (palavra.Length != 5){
                throw new Exception("Palavra com tamanho incorreto!");
            }
                // Adicionando palavra na matriz do tabuleiro
                var palavraTabuleiro = new List<Letra>();
                char cor;
                for (int i = 0; i < palavra.Length; i++)
                {
                    if (palavra[i] == palavraSorteada[i])
                    {
                        cor = 'V';
                    }
                    else if (palavraSorteada.Contains(palavra[i]))
                    {
                        cor = 'A';
                    }
                    else
                    {
                        cor = 'P';
                    }
                    palavraTabuleiro.Add(new Letra(palavra[i], cor));
                    teclado[palavra[i]] = cor;
                }
                tabuleiro.Add(palavraTabuleiro);
                palavraAtual++;
                contadorTentativas++;
        }
        #endregion

        public void ReiniciarJogo()
        {
            palavraAtual = 1;
            JogoFinalizado = false;
            tabuleiro.Clear();
            teclado.Clear();
            SorteiaPalavra();

            for (int i = 65; i <= 90; i++)
            {
                teclado.Add((char)i, 'C');
            }
        }
    }
}
